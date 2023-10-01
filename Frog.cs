using Godot;
using System;
using System.Diagnostics;

public partial class Frog : CharacterBody2D
{
    public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    bool isChasing;
    bool isDead;
    float speed = 200;

    public override void _Ready()
    {
        isDead = false;
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Idle");
    }
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        if (!isDead)
        {
            if (isChasing)
            {
                GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Jump");
                Node2D body = GetParent().GetNode<Node2D>("Player");
                Vector2 direction = (body.Position - Position).Normalized();
                velocity.X = direction.X * speed;
                if (direction.X > 0)
                {
                    GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
                }
                else GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
            }
            else
            {
                velocity.X = 0;
                GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Idle");
            }

            // Add the gravity.
            if (!IsOnFloor())
                velocity.Y += gravity * (float)delta;
        }

        Velocity = velocity;
        MoveAndSlide();
    }
    void _on_player_detection_body_entered(Node2D body)
    {
        if (body.Name == "Player")
        {
            isChasing = true;
        }
    }

    void _on_frog_death_body_entered(Node2D body)
    {
        if (body.Name == "Player")
        {
            Death();
        }
        
    }

    void _on_player_collision_body_entered(Node2D body)
    {
        if (body.Name == "Player")
        {
            Player.player.health -= 10;
            Death();
        }
    }

    async void Death()
    {
        isDead = true;
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Death");
        await ToSignal(GetNode<AnimatedSprite2D>("AnimatedSprite2D"), "animation_finished");
        QueueFree();
    }
    void _on_player_detection_body_exited(Node2D body)
    {
        if (body.Name == "Player")
        {
            isChasing = false;
        }
    }
}

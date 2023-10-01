using Godot;
using System;

public partial class Cherry : Area2D
{
    void _on_body_entered(Node2D body)
    {
        if (body.Name == "Player")
        {
            Game.game.gold += 5;
            var tween = GetTree().CreateTween();
            var tween1 = GetTree().CreateTween();
            tween.TweenProperty(this, "position", Position - new Vector2(0, 50), 0.5);
            tween1.TweenProperty(this, "modulate:a", 0, 0.5);
            tween.TweenCallback(Callable.From(QueueFree));
        }
    }
}

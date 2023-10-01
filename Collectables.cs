using Godot;
using System;

public partial class Collectables : Node2D
{
    PackedScene Cherry = (PackedScene)ResourceLoader.Load("res://Collectables/Cherry.tscn");  
    void _on_timer_timeout()
    {
        Node2D cherryTemp = (Node2D)Cherry.Instantiate();
        AddChild(cherryTemp);
        var ran = new RandomNumberGenerator();
        //ran.Randomize();
        Vector2 randomPosition = new Vector2(ran.RandiRange(100,700), ran.RandiRange(50,210));
        cherryTemp.Position = randomPosition;
    }
}

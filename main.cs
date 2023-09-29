using Godot;
using System;


public partial class main : Node2D
{
    void _on_exit_pressed()
	{
		GetTree().Quit();
	}
    void _on_play_pressed()
    {
        GetTree().ChangeSceneToFile("res://world.tscn");
    }

}







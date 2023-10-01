using Godot;
using System;


public partial class main : Node2D
{
    public override void _Ready()
    {
        Util.util.SaveGame();
        Util.util.LoadGame();
    }
    void _on_exit_pressed()
	{
		GetTree().Quit();
	}
    void _on_play_pressed()
    {
        GetTree().ChangeSceneToFile("res://world.tscn");
    }

}







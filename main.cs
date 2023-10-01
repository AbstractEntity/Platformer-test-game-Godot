using Godot;
using System;


public partial class main : Node2D
{
    public override void _Ready()
    {
        //Util.SaveGame();
        //Util.LoadGame();
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







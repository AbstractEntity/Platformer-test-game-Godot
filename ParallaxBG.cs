using Godot;
using System;

public partial class ParallaxBG : ParallaxBackground
{
	float scrollingSpeed = 100;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ScrollOffset = new Vector2(ScrollOffset.X - (scrollingSpeed * (float)delta), 0);
	}
}

using Godot;
using System;
public partial class MouseManager : Node2D
{
	[Export] 
	private Godot.Collections.Array<Sprite2D> CrossHairSprites;
	[Export] 
	Godot.Collections.Array<float> CrossHairSmoothing;
	[Export] 
	Godot.Collections.Array<float> CrossHairRotationSec;

	public override void _Process(double delta)
	{
		for(int i = CrossHairSprites.Count - 1;i >= 0;i-- )
		{
			CrossHairSprites[i].GlobalPosition = MyMath.DeltaLerp(CrossHairSprites[i].GlobalPosition,GetGlobalMousePosition(),CrossHairSmoothing[i],delta);
			CrossHairSprites[i].Rotation += CrossHairRotationSec[i] * (float)delta;
		}   
	}
}

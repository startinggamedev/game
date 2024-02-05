using Godot;
using Godot.NativeInterop;
using System;
[GlobalClass]
public partial class TestMovementPath : Node2D
{
	[Export]
	public MovementPath MyPath;
	public override void _Ready()
	{
		MyPath.SetUp();
		base._Ready();
	}
	public override void _Process(double delta)
	{
		QueueRedraw();
		base._Process(delta);
	}
	public override void _Draw()
	{
		if(MyPath is null){return;}
		foreach(var CurrentMoment in MyPath.MyMoments)
		{
			DrawCircle(CurrentMoment.StartPoint,9f,new Color(0.2f,0.1f,0.8f));
			DrawCircle(CurrentMoment.EndPoint + CurrentMoment.StartPoint,9f,new Color(0.3f,0.2f,0.9f));
			foreach (var Point  in CurrentMoment.MyPath.MyPoints)
			{
				DrawCircle(Point.Position + CurrentMoment.StartPoint,5f,new Color(0.1f,0.05f,0.4f));
				DrawLine(Point.Position + CurrentMoment.StartPoint,Point.NextPoint + CurrentMoment.StartPoint,new Color(0.1f,0.05f,0.6f),2);
			}
		}
		base._Draw();
	}
}

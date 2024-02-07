using Godot;
using Godot.NativeInterop;
using System;
[GlobalClass]
public partial class TestMovementPath : Node2D
{
	[Export]
	public PathManager MyPathManager;
	float LengthTravelled = 0f;
	[Export]
	float TravelVelocity = 1;
	public override void _Ready()
	{
		MyPathManager.SetUp();
		base._Ready();
	}
	public override void _Process(double delta)
	{
		QueueRedraw();
		base._Process(delta);
	}
	public override void _Draw()
	{

		if(MyPathManager is null){return;}
		Vector2 MousePos = GetGlobalMousePosition();
		foreach(var CurrentPath in MyPathManager.MyPaths)
		{
			float NewLengthTravelled = CurrentPath.GetNearestSegmentTo(MousePos);
			if(NewLengthTravelled >  LengthTravelled)
			{
				LengthTravelled = Mathf.MoveToward(LengthTravelled,NewLengthTravelled,TravelVelocity);
			}
			DrawCircle(CurrentPath.Start,9f,new Color(0.2f,0.1f,0.8f));
			DrawCircle(CurrentPath.End,9f,new Color(0.3f,0.2f,0.9f));
			foreach (var Connection  in CurrentPath.MyConnections)
			{
				DrawLine(Connection.Position,Connection.End,new Color(0.1f,0.05f,0.6f),2);
				float MouseSegment = Connection.GetNearestSegmentTo(MousePos);
				DrawCircle(Connection.GetSegmentPosition(MouseSegment),3f,new Color(0.4f,0.0125f,0.1f));
				DrawCircle(Connection.Position,5f,new Color(0.1f,0.05f,0.4f));
			}
			DrawCircle(CurrentPath.GetSegmentPosition(LengthTravelled),7f,new Color(0.2f,0.6f,0.8f));
		}
		base._Draw();
	}
}

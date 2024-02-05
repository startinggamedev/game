using Godot;
using System;
[GlobalClass]
public partial class MomentPathPoint : Resource
{
	[Export]
	public Godot.Vector2 Position{get;protected set;}
	[Export]
	LineConnection MyConnection;
	public Godot.Vector2 NextPoint;
	public void SetUp(Godot.Vector2 next_point)
	{
		this.NextPoint = next_point;
		MyConnection.SetUp(Position,NextPoint);
	}
	public void Rotate(float Rotation)
	{
		Position = Position.Rotated(Rotation);
	}
	public void Offset(Godot.Vector2 Offset)
	{
		Position += Offset;
	}
	public void Scale(Godot.Vector2 Value)
	{
		Position *= Value;
	}
}

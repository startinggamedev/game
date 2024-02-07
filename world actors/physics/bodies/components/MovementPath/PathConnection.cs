using Godot;
using System;
[GlobalClass]
public abstract partial class PathConnection : Resource
{
	[Export]
	public Godot.Vector2 Position{get;protected set;} = Godot.Vector2.Zero;
    public Vector2 End {get; set;}
    public float Length {get; set;}
    public float LengthTravelled {get; set;}
	public abstract float GetNearestSegmentTo(Godot.Vector2 Position);
    public abstract float GetSegmentAngle(float Segment);
    public abstract Godot.Vector2 GetSegmentPosition(float Position);
    protected abstract float GetNewLength();
    public void SetUp(Godot.Vector2 End)
    {
		this.End = End; 
        Length = GetNewLength();
    }
	public void Rotate(float Rotation,Vector2 RotationAxis)
	{
		Godot.Vector2 AxiDifference = RotationAxis - Position;
		Position = RotationAxis + AxiDifference.Rotated(Rotation);
	}
	public void Offset(Godot.Vector2 Offset)
	{
		Position += Offset;
	}
	public void ScalePosition(Godot.Vector2 Scaling,Vector2 ScaleAxis)
	{
		Vector2 AxisDifference = ScaleAxis - Position;
		Position = ScaleAxis + (AxisDifference * Scaling);
	}
}

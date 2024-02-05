using Godot;
using System;
[GlobalClass]
public abstract partial class PointConnection : Resource
{
    protected Godot.Vector2 Start {get;private set;}
    protected Godot.Vector2 End{get;private set;}
    public float Length;
    public abstract float GetNearestPointRelativeTo(Godot.Vector2 Position);
    public abstract float GetPointAngle(float Point);
    public abstract Godot.Vector2 GetPoint(float Position);
    protected abstract float GetNewLength();
    public void SetUp(Godot.Vector2 start,Godot.Vector2 end)
    {
        this.Start = start;
        this.End = end;

        Length = GetNewLength();
    }
}
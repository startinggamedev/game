using Godot;
using System;
using System.Drawing;
using System.Text;
[GlobalClass]
public partial class LineConnection  : PointConnection
{
    Godot.Vector2 Line = new Godot.Vector2();
    Godot.Vector2 NormalizedLine = new Godot.Vector2();
    float LineAngle = 0f;
    float LineLength = 0f;
    protected override float GetNewLength()
    {
        Line =End - Start;
        LineAngle = Line.Angle();
        NormalizedLine = Line.Normalized();
        LineLength = Line.Length();
        return LineLength;
    }
    public override float GetPointAngle(float Point)
    {
        return LineAngle;
    }

    public override float GetNearestPointRelativeTo(Vector2 Position)
    {
        return Math.Clamp(NormalizedLine.Dot(Position - Start),0f,LineLength);
    }

    public override Vector2 GetPoint(float Position)
    {
        return Start + (Line / Position);
    }
}
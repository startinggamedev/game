using Godot;
using System;
using System.Drawing;
using System.Text;
[GlobalClass]
public partial class LineConnection  : PathConnection
{
    Godot.Vector2 Line = new Godot.Vector2();
    Godot.Vector2 NormalizedLine = new Godot.Vector2();
    float LineAngle = 0f;
    float LineLength = 0f;
    protected override float GetNewLength()
    {
        Line =End - this.Position;
        LineAngle = Line.Angle();
        NormalizedLine = Line.Normalized();
        LineLength = Line.Length();
        return LineLength;
    }
    public override float GetSegmentAngle(float Point)
    {
        return LineAngle;
    }

    public override float GetNearestSegmentTo(Vector2 Position)
    {
        return Math.Clamp(NormalizedLine.Dot(Position - this.Position),0f,LineLength);
    }

    public override Vector2 GetSegmentPosition(float Position)
    {
        return this.Position + (NormalizedLine* Position);
    }
}
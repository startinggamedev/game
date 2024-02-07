using Godot;
using System;
[GlobalClass]
public partial class PositionPoint : PathPoint
{
    [Export]
    Godot.Vector2 Position = new Godot.Vector2();
    public override Vector2 GetPoint()
    {
        return Position;
    }
}

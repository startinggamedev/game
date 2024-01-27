using Godot;
using System;

[GlobalClass]
public partial class MouseAimType : AimType
{
    public override float AimFunction(double delta, Node2D MyNode2D)
    {
        return MyNode2D.GlobalPosition.AngleToPoint(MyNode2D.GetGlobalMousePosition());
    }
}
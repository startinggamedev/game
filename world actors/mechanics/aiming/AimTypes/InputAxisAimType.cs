using Godot;
using System;
using System.Reflection.Metadata.Ecma335;
[GlobalClass]
public partial class InputAxisAimType : AimType
{
    public override float AimFunction(double delta, Node2D MyNode2D)
    {
        return Input.GetVector("Left","Right","Up","Down").Angle();
    }
}
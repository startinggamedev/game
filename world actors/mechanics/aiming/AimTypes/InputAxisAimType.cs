using Godot;
using System;
using System.Reflection.Metadata.Ecma335;
[GlobalClass]
public partial class InputAxisAimType : AimType
{
    public override float AimFunction(double delta, Node2D MyNode2D)
    {
        Godot.Vector2 InputVector =  Input.GetVector("Left","Right","Up","Down");
        if((Math.Abs(InputVector.X) + Math.Abs(InputVector.Y)) > 0f)
            {
                return Input.GetVector("Left","Right","Up","Down").Angle();
            }
        else{return float.NaN;}
    }
}
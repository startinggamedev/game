using Godot;
using System;
[GlobalClass]
public partial class SpinAimType : AimType
{
    [Export]
    float SpinRadiansSec;
    float OutputAngle;
    public override float AimFunction(double delta, Node2D MyNode2D)
    {
        OutputAngle = (float)MyMath.WrapRadian(OutputAngle + (SpinRadiansSec * delta));
        return OutputAngle;
    }
}
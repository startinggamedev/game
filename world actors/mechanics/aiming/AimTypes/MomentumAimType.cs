using Godot;
using System;
[GlobalClass]
public partial class MomentumAimType : AimType
{
    public override float AimFunction(double delta, Node2D MyNode2D)
    {
        if(MyNode2D is PhysicsBody)
        {
            return ((PhysicsBody)MyNode2D).Momentum.Angle();
        }
        else
        {
            GD.PushError("Momentum Aim Type should only be used with PhysicsBody and subclasses");
            return 0f;
        }
    }
}
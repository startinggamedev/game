using Godot;
using System;
[GlobalClass]
public partial class AimResource : Resource
{
[Export]
public AimType MyAimType;
[Export(PropertyHint.Range,"0.,1.,0.0001")]
public float AimSmoothing;
[Export]
public float AimOffset = 0f;
[Export]
public bool CanAim = true;
public virtual void AimProcess(Node2D MyNode2D,double delta)
{
    float TargetDirection =  MyNode2D.GlobalRotation;
    if(MyAimType is not null){TargetDirection = MyAimType.AimFunction(delta,MyNode2D);}
    if (TargetDirection == float.NaN || !CanAim){TargetDirection = MyNode2D.GlobalRotation;}

    MyNode2D.GlobalRotation = (float)MyMath.DeltaLerpAngle(TargetDirection + AimOffset,MyNode2D.GlobalRotation,AimSmoothing,delta * 30);
}
}
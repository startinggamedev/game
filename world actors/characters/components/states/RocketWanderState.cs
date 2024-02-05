using Godot;
using System;
using System.Data;
[GlobalClass]
public partial class RocketWanderState : WanderState
{
    [Export]
    float RocketMomentumScale = 1f;
    protected override void SetupAimObejct(IAimObject AimObjectInstance)
    {
        if(MyAimObject is Rocket)
        {
            ((Rocket)MyAimObject).momentum_scale = RocketMomentumScale;
        }
        else
        {
            GD.PushError("Rocket wander states's MyAimObject should inehrit node, which it doesnt!");
        }
        base.SetupAimObejct(AimObjectInstance);
    }
}
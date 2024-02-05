using Godot;
using System;
[GlobalClass]
public partial class VelocityBumpType : DamageBumpType
{
    [Export]
    private float BumpMultiplier = 1f;
    public override Godot.Vector2 BumpFunction(double delta,Character Bumper,Character Bumped){
        return Bumper.Momentum * BumpMultiplier;
    }
}
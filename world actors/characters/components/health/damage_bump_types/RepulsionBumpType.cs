using Godot;
using System;

public partial class RepulsionBumpType : DamageBumpType
{
    [Export]
    private float BumpMagnitude;
    public override Godot.Vector2 BumpFunction(double delta,Character Bumper,Character Bumped){
        return (Bumped.GlobalPosition - Bumper.GlobalPosition).Normalized() * BumpMagnitude;
    }
}
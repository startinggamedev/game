using Godot;
using System;
[GlobalClass]
public partial class WeaponStateExitCondition : Resource
{
    [Export]
    protected AnimationState NextState;
    public virtual State ExitCondition(WeaponManager MyWeaponManager)
    {
        return NextState;
    }
}
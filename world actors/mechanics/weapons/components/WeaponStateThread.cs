using Godot;
using System;
using System.ComponentModel;
[GlobalClass]
public partial class WeaponStateThread : AnimationStateThread
{
    protected override void OnStateChange(State CurrentState)
    {
        base.OnStateChange(CurrentState);
        if (CurrentState is WeaponState && ThreadAnimationPlayer is WeaponAnimationPlayer)
        {
            ((WeaponState)CurrentState).MyWeaponStateExitCondition = ((WeaponAnimationPlayer)ThreadAnimationPlayer).MyWeaponStateExitCondition;
        } 
    }
}
using Godot;
using System;

[GlobalClass]
public partial class OnAmmoDepletionExitCondition : WeaponStateExitCondition
{
    [Export]
    Godot.Collections.Array<Gl.TriggerStates> ExitTriggers;
    public override State ExitCondition(WeaponManager MyWeaponManager)
    {
        if (MyWeaponManager is not RangedWeaponManager)
        {
            GD.PushError("On ammo depletion exit conidition is supposed to be used only with ranged weapon managers");
            return null;
        }
        if(((RangedWeaponManager)MyWeaponManager).HasaAmmo())
        {
            return NextState;
        }
        else{return null;}
 
    }

}
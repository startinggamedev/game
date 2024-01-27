using Godot;
using System;

[GlobalClass]
public partial class OnAmmoDepletionExitCondition : WeaponStateExitCondition
{
    public override State ExitCondition(WeaponManager MyWeaponManager)
    {
        GD.Print("q");
        if (MyWeaponManager is not RangedWeaponManager)
        {
            GD.PushError("On ammo depletion exit conidition is supposed to be used only with ranged weapon managers");
            return null;
        }
        if(!((RangedWeaponManager)MyWeaponManager).HasAmmo())
        {
            return GetNextState();
        }
        else{return null;}
 
    }

}
using Godot;
using System;
public partial class Recharge : WeaponState
{
    protected override void ProtectedEnter()
    {
        base.ProtectedEnter();
        ((RangedWeaponManager)MyWeaponManager).RechargeAmmo();
    }
}

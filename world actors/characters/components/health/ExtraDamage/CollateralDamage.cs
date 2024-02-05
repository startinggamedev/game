using Godot;
using System;
[GlobalClass]
public partial class CollateralDamage : ExtraDamage
{
    protected bool RanOnce = false;
    bool DealtDamage = false;
    public CollateralDamage()
    {
        Init();
    }
    public CollateralDamage(DamageRes my_damage)
    {
        Init(my_damage);
    }
    public virtual void OnDamageDealt(float DamageDealt)
    {
        DealtDamage = true;
    }
    public override DamageRes DamageFunction(Character MyCharacter)
    {
        if(!RanOnce)
        {
            MyCharacter.MyDamagedetector.DealtDamage += OnDamageDealt;
            RanOnce = true;
        }
        if (DealtDamage)
        {
        GD.Print("the damage was colalterated");
        DealtDamage = false;
        return GetReturnDamage();
        }
        else
        {
            return new DamageRes();
        }
    }
}
using Godot;
using System;
[GlobalClass]
public abstract partial  class ExtraDamage : Resource
{
    [Export]
    public DamageRes MyDamage;
    [Export]
    public int ExtraDamageImmunity = 0;
    
  
    public ExtraDamage(DamageRes my_damage)
    {
        Init(my_damage);
    }
    protected virtual void Init(DamageRes my_damage)
    {
        MyDamage = my_damage;
    }
    public ExtraDamage(){Init();}
    protected virtual void Init(){}
    public DamageRes GetReturnDamage()
    {
        if (ExtraDamageImmunity <= 0)
        {
        return MyDamage;
        }
        else
        {
        ExtraDamageImmunity -= 1;
        return new DamageRes();
        }
    }
    public abstract DamageRes DamageFunction(Character MyCharacter);
}
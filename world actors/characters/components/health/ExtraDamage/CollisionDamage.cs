using Godot;
using System;
[GlobalClass]
public partial class CollisionDamage : ExtraDamage
{
    public CollisionDamage(DamageRes my_damage)
    {
        Init(my_damage);
    }
    public override DamageRes DamageFunction(Character MyCharacter)
    {
        if (MyCharacter.Collided)
        {
            return GetReturnDamage();
        }
        else
        {
            return new DamageRes();
        }
    }
}
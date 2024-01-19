using Godot;
using System;
public abstract partial  class ExtraDamage : Resource
{
    [Export]
    public DamageRes ExtraDamageRes;
    public abstract DamageRes DamageFunction(Character MyCharacter);
}
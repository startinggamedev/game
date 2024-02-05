using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;
public partial class Gl : Node
{
    public enum Types {All,Player,Enemy,AllWeapon,PlayerWeapon,EnemyWeapon}
    public static List<DamageType> DamageTypes = new List<DamageType>(){
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/AllType.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/PlayerType.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/EnemyType.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/AllWeaponType.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/PlayerWeaponType.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/EnemyWeaponType.tres")};
    private static List<StringName> GroupToFollow = new List<StringName>(){"All","Enemy","Player","All","Enemy","Player"};
    public static StringName GetGroupTofollow(int Type)
    {
        return GroupToFollow[Type];
    }
    public Node CharacterHolder;
}
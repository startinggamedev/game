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
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/all_type.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/player_type.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/enemy_type.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/weapon_all_type.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/weapon_player_type.tres"),
        GD.Load<DamageType>("res://world actors/characters/components/health/damage types/weapon_enemy_type.tres")};
}
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
    public Node CharacterHolder;
    public enum TriggerStates {RELEASED,PRESSED,HELD}
}
class_name Global
extends Node2D
enum trigger_states {released,pressed,held}
#make sure weapon and player types are in the same order but offset by three
enum types {all,player,enemy,all_weapon,player_weapon,enemy_weapon}
const damage_types : Array[DamageType] = [preload("res://world actors/characters/components/health/damage types/all_type.tres"),
preload("res://world actors/characters/components/health/damage types/player_type.tres"),
preload("res://world actors/characters/components/health/damage types/enemy_type.tres"),preload("res://world actors/characters/components/health/damage types/weapon_all_type.tres"),
preload("res://world actors/characters/components/health/damage types/weapon_player_type.tres"),preload("res://world actors/characters/components/health/damage types/weapon_enemy_type.tres")]


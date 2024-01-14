class_name WeaponStateExit
extends Resource
@export var next_state_path : NodePath
func get_next_state(weapon_state : WeaponState):
	return weapon_state.get_node(next_state_path)
func exit_weapon_state(weapon : Weapon,weapon_state : WeaponState):
	return get_next_state(weapon_state)

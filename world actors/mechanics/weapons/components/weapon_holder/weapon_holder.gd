class_name WeaponHolder
extends Node2D
var weapon_child : Weapon
func _enter_tree():
	var children = get_children()
	for i in len(children):
		weapon_child = children[i]
		weapon_child.type = get_parent().type

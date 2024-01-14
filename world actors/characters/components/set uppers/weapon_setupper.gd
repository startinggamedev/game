extends Node2D
@export var weapon : PackedScene
@export var aim_type : AimType
@export var triggerer : Triggerer
@export var character : Character
@export var aim_offset : float =0.
const AIM_NODE = preload("res://world actors/items/weapons/components/aim_node/aim_node.tscn")
func _ready():
	if !character:
		if get_parent() is Character:
			character = get_parent()
		else:
			assert(false,"weapon setupper doesnt have character")
	var weapon_instance : Weapon = weapon.instantiate()
	character.health_manager.vitality_status.connect(weapon_instance.set_triggerability)
	weapon_instance.type = character.type + 3
	weapon_instance.triggerer = triggerer
	weapon_instance.bodies.append(character)
	character.health_manager.vitality_status.connect(weapon_instance.set_triggerability)
	add_child(weapon_instance)
	var aim_node_instance : AimNode = AIM_NODE.instantiate()
	aim_node_instance.aim_type = aim_type
	aim_node_instance.aim_offset = aim_offset
	weapon_instance.add_child(aim_node_instance)

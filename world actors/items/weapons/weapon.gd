class_name Weapon
extends Triggerable
@export var bodies : Array[PhysicsBody]
var type : Gl.types
@onready var aim_node = $AimNode
func set_triggerability(can_trigger : bool):
	can_be_triggered = can_trigger
func _ready():
	set_components_type()
func set_components_type():
	pass

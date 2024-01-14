class_name VelocityAimTypes
extends AimType
@export var physics_body : NodePath
func aim_function(aim_object : Node2D,delta : float):
	aim_object.rotation = aim_object.get_node(physics_body).velocity.angle()

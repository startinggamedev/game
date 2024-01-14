class_name SpinAimType
extends AimType
@export var radian_sec : float
func aim_function(aim_object : Node2D,delta:float):
	aim_object.rotation += radian_sec * delta

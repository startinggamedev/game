class_name MouseAimType
extends AimType
func aim_function(aim_object : Node2D,delta : float):
	aim_object.rotation = aim_object.global_position.angle_to_point(Gl.get_global_mouse_position())

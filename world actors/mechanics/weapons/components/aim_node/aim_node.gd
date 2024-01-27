class_name AimNode
extends Node2D
@export var aim_type : AimType
@export var aim_offset : float = 0.
@export var flip_y : bool = false
@export var aim_smoothing : float = 0.
@export var can_aim : bool = true
func _process(delta):
	if aim_type and can_aim: aim_type.aim_function(self,delta)
	rotation += aim_offset
	if flip_y: 
		get_parent().scale.y = sign(cos(get_parent().rotation))
	#get_parent().global_rotation = Gl.delta_angle_lerp(rotation,get_parent().global_rotation,aim_smoothing,delta*60.)

class_name LinearVelocity
extends Node
@export var target_velocity : Vector2
@export var acceleration : float
@export var deacceleration_sec : float
@export var is_accelerating : bool = false
@export var reset_properties : bool = false
var deacceleration_timer : float
func _process(delta):
	if is_accelerating:
		deacceleration_timer = deacceleration_sec
	else:deacceleration_timer-=delta

class_name DirectionalVelocity
extends LinearVelocity
@export var direction : float
@export var magnitude : float
func set_directional_velocity():
	target_velocity = Vector2.from_angle(direction) * magnitude

extends State
@onready var character = $"../.."
@onready var linear_velocity = $"../../velocity_manager/LinearVelocity" as LinearVelocity
func physics(delta):
	pass#linear_velocity.accelerate( Vector2(256,128) - character.global_position,60.,delta)



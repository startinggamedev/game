extends State
@onready var velocity_manager = $"../../velocity_manager"
func enter():
	velocity_manager.bounce(Vector2.RIGHT,0.)
func physics(delta):
	velocity_manager.physics_velocity.impulse(Vector2(0.,10.))

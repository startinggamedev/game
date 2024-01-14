extends Area2D
@export_range(0.,1.) var air_friction : float
func _physics_process(delta):
	var colliding_bodies = get_overlapping_bodies()
	for i in len(colliding_bodies):
		if colliding_bodies[i] is PhysicsBody:
			colliding_bodies[i].air_friction = air_friction

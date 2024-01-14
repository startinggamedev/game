class_name ForceField
extends Area2D
@export var active : bool = true
@export var exceptions : Array[Node]
@export var group_exceptions : Array[StringName]
@export var magnitude : float
@export var acceleration : float
@export var attractive = false
@export var consider_rotation : bool = true
@export_range(0.,TAU) var force_direction : float
func field_function(body : PhysicsBody):
	pass
func _physics_process(delta):
	var attraction_dir = 0.
	var colliding_bodies = get_overlapping_bodies()
	for i in len(colliding_bodies):
		if !exceptions.has(colliding_bodies[i]) and !Gl.is_node_in_group_array(colliding_bodies[i],group_exceptions):
			field_function(colliding_bodies[i])

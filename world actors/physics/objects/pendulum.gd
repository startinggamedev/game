class_name  Pendulum
extends Node2D
@export var gravity : Vector2 = Vector2(0.,15.)
@export var damping : float = 0.01
var angular_speed : float = 0.
var prev_position : Vector2
var real_rotation : float
func _ready():
	real_rotation = PI * 0.5
	prev_position = global_position
func _physics_process(delta):
	rotation = real_rotation
	angular_speed = lerp(angular_speed,global_position.angle_to_point(prev_position + gravity)-rotation,damping)
	rotation += angular_speed
	prev_position = global_position
	real_rotation = rotation
	rotation = rotation + (-PI * 0.5)

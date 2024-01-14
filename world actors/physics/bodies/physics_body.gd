class_name PhysicsBody
extends CharacterBody2D
@export_range(0.,1.) var bounciness : float
@export var weight : float = 1.
@export var intangible : bool = false
@export var velocity_holder : Node
@export var friction_multiplier : float = 1.
@onready var air_friction : float = Gl.air_friction
@onready var force_field_velocity = $velocity_holder/force_field_velocity
var extra_velocity : Array[LinearVelocity]
var permanent_velocity : Array[LinearVelocity]
var collided : bool = false
var linear_velocity = Vector2.ZERO
var collision_normal : Vector2
func _physics_process(delta):
	set_collision_mask_value(1,!intangible)
	calculate_velocity(delta)
	apply_friction(air_friction,delta)
	move()
	air_friction = Gl.air_friction
func move():
	var real_velocity = velocity
	velocity =velocity / weight
	collided = move_and_slide()
	print(name + " "+str(velocity))
	velocity = real_velocity
	if collided:
		collision_normal = get_wall_normal()
		bounce(collision_normal,bounciness)
func bounce(normal : Vector2,bounciness):
	normal = normal.normalized()
	velocity = Gl.mirror(velocity,normal) * bounciness
func calculate_velocity(delta):
	var target_velocity : float = 0.
	var acceleration : Vector2
	var linear_velocity_nodes = velocity_holder.get_children()
	if extra_velocity.is_empty() == false: linear_velocity_nodes.append(extra_velocity)
	linear_velocity_nodes.append(permanent_velocity)
	target_velocity = 0.
	acceleration = Vector2.ZERO
	for i in len(linear_velocity_nodes):
		var current_linear_velocity : LinearVelocity = linear_velocity_nodes[i]
		if current_linear_velocity is DirectionalVelocity:
			current_linear_velocity.set_directional_velocity()
		if current_linear_velocity.is_accelerating:
			acceleration += current_linear_velocity.target_velocity * current_linear_velocity.acceleration
		elif current_linear_velocity.deacceleration_timer > 0.:
			acceleration += -current_linear_velocity.target_velocity * current_linear_velocity.deacceleration
	var normalized_accel = acceleration.normalized()
	for i in len(linear_velocity_nodes):
		var current_linear_velocity : LinearVelocity = linear_velocity_nodes[i]
		target_velocity += clamp(current_linear_velocity.target_velocity.dot(normalized_accel),0.,INF)
		if current_linear_velocity.reset_properties:
			current_linear_velocity.target_velocity = Vector2.ZERO
			current_linear_velocity.acceleration = 0.
			current_linear_velocity.is_accelerating = false
	velocity = velocity.move_toward(acceleration.normalized() * target_velocity,acceleration.length() * delta)
	extra_velocity = []
func impulse(impulse : Vector2):
	velocity += impulse
func apply_friction(friction,delta):
	friction *= friction_multiplier
	velocity = Gl.delta_lerp(velocity,Vector2.ZERO,friction,delta)

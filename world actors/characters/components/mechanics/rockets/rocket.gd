class_name Rocket
extends Triggerable
@export var body : PhysicsBody
@export var aim_type : AimType
@export var acceleration : float
@export var compatible_triggers : Array[Gl.trigger_states] = [Gl.trigger_states.pressed,Gl.trigger_states.held]
@export var rocket_particles : GPUParticles2D
@onready var rocket_velocity = $rocket_velocity
@export var aim_node : AimNode
@onready var animation_player = $animation_player
func _ready():
	aim_node.aim_type = aim_type
	rocket_velocity.reparent(body.velocity_holder)
func _physics_process(delta):
	rocket_particles.amount = sqrt(rocket_velocity.magnitude) * 10.
	rocket_particles.speed_scale = acceleration * 0.005
	rocket_velocity.direction =global_rotation
	if compatible_triggers.has(trigger):
		animation_player.play("moving")
		rocket_particles.emitting = true
		rocket_velocity.is_accelerating = true
	else: 
		animation_player.play("idle")
		rocket_particles.emitting = false
		rocket_velocity.is_accelerating = false

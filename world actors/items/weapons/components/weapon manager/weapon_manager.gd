class_name WeaponManager
extends StateManager
@export var recoil : float
@export var animation_player : AnimationPlayer
@onready var weapon = $".."
func apply_recoil():
	for i in len(weapon.bodies):
		weapon.bodies[i].impulse(-1 *Vector2.from_angle(weapon.global_rotation) * recoil)
func _ready():
	super()
func _process(delta):
	super(delta)
func _physics_process(delta):
	super(delta)


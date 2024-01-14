class_name Bullet
extends Character
@onready var impulse_velocity = $velocity_manager/impulse_velocity
func _ready():
	print(get_class())
	super()

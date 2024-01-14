extends PhysicsBody
@onready var impulse_velocity = $velocity_manager/impulse_velocity
@export var can_move : bool = false
func _ready():
	super()
func _physics_process(delta):
	if can_move: impulse_velocity.impulse(Vector2(0.,10.))
	super(delta)

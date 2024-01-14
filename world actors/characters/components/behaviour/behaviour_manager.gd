class_name BehaviourManager
extends AnimationStateManager
@onready var health_manager = $"../health_manager"
@onready var dead = $dead
func change_to_dead_state(is_alive : bool):
	if current_state != dead and !is_alive:
		change_state(dead)
func _ready():
	health_manager.vitality_status.connect(change_to_dead_state)
	super()
func _process(delta):
	super(delta)
func _physics_process(delta):
	super(delta)


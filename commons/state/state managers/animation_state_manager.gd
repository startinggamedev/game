class_name AnimationStateManager
extends StateManager
@export var animation_player : AnimationPlayer
func change_state(next_state : State):
	super(next_state)
	if animation_player: animation_player.play(current_state.name)
func _ready():
	super()
func _process(delta):
	super(delta)
func _physics_process(delta):
	super(delta)


class_name KeyTriggerer
extends Triggerer
@export var trigger_input_action : String
func trigger_function(delta : float) -> int:
	if Input.is_action_just_pressed(trigger_input_action):
		return Gl.trigger_states.pressed
	elif Input.is_action_pressed(trigger_input_action):
		return Gl.trigger_states.held
	else:
		return Gl.trigger_states.released

class_name AutomaticTriggerer
extends Triggerer
@export var trigger_type : Gl.trigger_states = Gl.trigger_states.pressed
@export var trigger_spacing_sec : float = 0. 
var trigger_timer : float = 0.
func trigger_function(delta : float):
	trigger_timer -= delta
	if trigger_timer <= 0.:
		trigger_timer = trigger_spacing_sec
		return trigger_type
	else:
		return Gl.trigger_states.released

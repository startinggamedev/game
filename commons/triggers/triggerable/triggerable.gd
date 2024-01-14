class_name Triggerable
extends Node2D
@export var can_be_triggered : bool = true
@export var triggerer : Triggerer
var trigger : int = Gl.trigger_states.released
func set_trigger(next_trigger_state : int):
	if can_be_triggered: trigger = next_trigger_state
	else: trigger = Gl.trigger_states.released
func _process(delta):
	set_trigger(triggerer.trigger_function(delta))

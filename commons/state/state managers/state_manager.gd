class_name StateManager
extends Node
@export var current_state : State
func run_state_method(method_name : String,arg_array:Array = []):
	if current_state == null: return
	if current_state.has_method(method_name): current_state.callv(method_name,arg_array)
func change_state(next_state : State):
	if next_state == null: return
	run_state_method("exit",[])
	run_state_method("state_all_signals_disconnect")
	current_state = next_state
	run_state_method("enter",[])
#processes
func _ready():
	if current_state == null: return
	change_state(current_state)
func _process(delta):
	if current_state == null: return
	run_state_method("process",[get_process_delta_time()])
func _physics_process(delta):
	if current_state == null: return
	run_state_method("physics",[get_physics_process_delta_time()])

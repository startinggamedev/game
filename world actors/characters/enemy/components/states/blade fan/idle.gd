extends State
@export var idle_time_sec : float = 0.
@onready var fan_rocket = $"../../BladefanWire/fan_rocket"
@onready var moving = $"../moving"
var timer : float = 0.
func enter():
	fan_rocket.aim_node.can_aim = false
	fan_rocket.can_be_triggered = false
	timer = idle_time_sec
func process(delta):
	timer -= delta
	if timer <= 0.:
		get_parent().change_state(moving)

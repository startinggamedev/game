extends State
@onready var idle = $"../idle"
@onready var fan_rocket = $"../../BladefanWire/fan_rocket"
@export var moving_time_sec : float = 0.
var timer : float = 0.
func enter():
	fan_rocket.aim_node.can_aim = true
	fan_rocket.can_be_triggered = true
	timer = moving_time_sec
func process(delta):
	timer -= delta
	if timer <= 0.:
		get_parent().change_state(idle)

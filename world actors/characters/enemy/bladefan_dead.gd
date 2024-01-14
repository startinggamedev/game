extends State
@onready var fan_rocket = $"../../BladefanWire/fan_rocket"
@onready var velocity_manager = $"../../velocity_manager"
var timer : float = 0.
func enter():
	fan_rocket.aim_node.can_aim = false
	fan_rocket.can_be_triggered = false

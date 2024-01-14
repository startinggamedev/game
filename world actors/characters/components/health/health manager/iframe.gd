extends HealthState
@onready var damageable = $"../damageable"
var iframe_timer : float 
func enter():
	iframe_timer = health_manager.iframe_length_sec
func process(delta):
	iframe_timer -= delta
	if iframe_timer <= 0.:
		health_manager.change_state(damageable)

extends HealthState
@onready var iframe = $"../iframe"
func physics(delta):
	var damagers : Array = health_manager.damage_detector.get_damagers()
	var damage_taken : float = 0.
	for i in len(damagers):
		var current_damager : DamageDetector = damagers[i]
		current_damager.dealt_damage.emit(current_damager.damage)
		damage_taken += health_manager.take_damage(current_damager.damage)
		health_manager.character.impulse(current_damager.get_damage_bump(health_manager.character,delta))
	if damage_taken > 0. and health_manager.iframe_length_sec > 0.:
		health_manager.change_state(iframe)

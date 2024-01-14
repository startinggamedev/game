class_name CollisionDamage
extends ExtraDamage
func damage_function(health_manager : HealthManager,delta : float) -> Damage:
	if health_manager.character.collided:
		return damage
	else: return Damage.new()

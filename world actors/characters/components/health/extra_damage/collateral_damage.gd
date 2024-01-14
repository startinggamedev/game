class_name CollateralDamage
extends ExtraDamage
var dealt_damage : bool = false
func on_damaging(damage_dealt : Damage):
	dealt_damage =true
func damage_function(health_manager : HealthManager,delta ) -> Damage:
	Gl.safe_connect(health_manager.damage_detector.dealt_damage,on_damaging)
	if dealt_damage:
		print("collateral damage")
		dealt_damage = false
		return damage
	else:
		return Damage.new()


class_name VelocityBumpType
extends DamageBumpType
@export var normalized_velocity : bool = false
func bump_function(delta,bumped : Character,bumper : DamageDetector):
	var bump : Vector2 = bumper.character.velocity.normalized()
	if normalized_velocity: bump.normalized()
	bump *= bump_magnitude
	return bump

class_name DamageBumpType
extends Resource
@export var bump_magnitude : float = 1.
func bump_function(delta,bumped : Character,bumper : DamageDetector):
	return Vector2.RIGHT * bump_magnitude

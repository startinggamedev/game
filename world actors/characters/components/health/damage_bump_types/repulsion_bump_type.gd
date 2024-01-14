class_name RepulsionBumpType
extends DamageBumpType
func bump_function(delta,bumped : Character,bumper : DamageDetector):
	return (bumped.global_position - bumper.global_position).normalized() * bump_magnitude

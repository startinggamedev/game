class_name MeleeWeapon
extends Weapon
@onready var damage_detector = $blade/DamageDetector
func _ready():
	super()
func set_components_type():
	damage_detector.set_damage_type(type)

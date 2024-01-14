class_name Character
extends PhysicsBody
@export var damage_detector : DamageDetector
@export var health_manager : HealthManager
@export var type : Gl.types
func toggle_collision(enable : bool):
	intangible = !enable
func _ready():
	health_manager.vitality_status.connect(toggle_collision)
	damage_detector.set_damage_type(type)
func _physics_process(delta):
	super(delta)


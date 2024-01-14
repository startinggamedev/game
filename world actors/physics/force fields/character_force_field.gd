class_name CharacterForceField
extends ForceField
@export var health_manager : HealthManager
func toggle_on_vitality(is_alive):
	active = is_alive
func _ready():
	health_manager.vitality_status.connect(toggle_on_vitality)
func _physics_process(delta):
	super(delta)

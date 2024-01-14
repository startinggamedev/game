class_name DamageDetector
extends Area2D
signal dealt_damage(damage_dealt : Damage)
@export var damage_bump : Array[DamageBumpType]
@export var damage : Damage
@onready var health_manager = $"../health_manager" as HealthManager
@onready var character = $".."
var type : DamageType
func set_damage_type(next_type : int):
	type = Gl.damage_types[next_type]
func get_damage_bump(bumped_node : Node2D,delta):
	var total_bump : Vector2 = Vector2.ZERO
	for i in len(damage_bump):
		total_bump+=damage_bump[i].bump_function(delta,bumped_node,self)
	return total_bump
func toggle_on_vitality(is_alive):
	monitorable = is_alive
	monitoring = is_alive
func _ready():
	set_damage_type(character.type)
	if health_manager: health_manager.vitality_status.connect(toggle_on_vitality)
func get_damagers():
	var removal_offset : int =0
	var damagers = get_overlapping_areas()
	for i in len(damagers):
		i += removal_offset
		var current_damager : DamageDetector = damagers[i]
		if current_damager.type.can_damage.has(type.type) == false:
			damagers.remove_at(i)
			removal_offset -= 1
	return damagers


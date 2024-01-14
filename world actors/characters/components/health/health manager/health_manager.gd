class_name HealthManager
extends StateManager
signal vitality_status(alive : bool)
@export var hp : float
@export var defense : float
@export var max_hp : float = -1.
@export var iframe_length_sec : float
@export var invincible : bool = false
@export var extra_damage : Array[ExtraDamage]
@onready var character = $".."
@onready var iframe = $iframe
@onready var damage_detector = $"../damage_detector"
func update_vitality_status():
	if hp > 0.:
		vitality_status.emit(true)
	else: 
		vitality_status.emit(false)
func take_damage(damage : Damage) -> float:
	var damage_taken = damage.damage
	if damage.respect.defense:
		damage_taken -= defense
	if current_state == iframe and damage.respect.iframe:
		damage_taken = 0.
	if damage.respect.invincibility and invincible:
		damage_taken = 0.
	damage_taken = clamp(damage_taken,0.,INF)
	hp -= damage_taken
	return damage_taken
func _ready():
	if max_hp == -1:
		max_hp = hp
	super()
func _process(delta):
	super(delta)
	for i in len(extra_damage):
		take_damage(extra_damage[i].damage_function(self,delta))
	hp = clamp(hp,0.,max_hp)
	update_vitality_status()
func _physics_process(delta):
	super(delta)


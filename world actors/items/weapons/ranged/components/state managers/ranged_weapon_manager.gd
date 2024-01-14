class_name RangedWeaponManager
extends WeaponManager
@export_range(0.,PI) var random_spread : float = 0.
@export var ammo : int
@export var max_ammo : int = -1
@export var projectile : PackedScene
@export var attack_force : float
@onready var barrel_holder = $"../barrel_holder"
#barrel states
func cooldown():
	animation_player.play("cooldown")
func _ready():
	super()
	if max_ammo == -1:
		max_ammo = ammo
func reload():
	ammo = max_ammo
	print(str(ammo) + " ddi ti relaod?")
func get_barrels():
	return barrel_holder.get_children()
func shoot():
	apply_recoil()
	ammo -= 1
	var barrels = get_barrels()
	for i in len(barrels):
		var current_barrel = barrels[i] as Barrel
		var current_projectile  = projectile.instantiate() as Character
		current_projectile.type = weapon.type
		#make sure adding projectile to the scene tree is the last thing you do 
		Gl.add_child_to([Gl.character_holder,get_parent()],current_projectile)
		current_projectile.impulse(
			Gl.vector_from_angle_and_magnitude(
				current_barrel.global_rotation + randf_range(-random_spread,random_spread),attack_force))
		current_projectile.global_position = Gl.get_ray_global_target_pos(current_barrel)

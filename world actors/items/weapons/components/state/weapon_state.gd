extends State
class_name WeaponState
@export var attack_state : bool = false
@export var state_exit : Array[WeaponStateExit]
@onready var weapon_manager = $".." as  WeaponManager
func enter():
	weapon_manager.animation_player.play(name)
func process(delta):
	exit_condition()
func exit_condition():
	for i in len(state_exit):
		var next_state : WeaponState = state_exit[i].exit_weapon_state(weapon_manager.weapon,self)
		if next_state:
			weapon_manager.change_state(next_state)
			return

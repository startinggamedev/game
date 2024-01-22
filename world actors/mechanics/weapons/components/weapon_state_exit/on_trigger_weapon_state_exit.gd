class_name OnTriggerWeaponStateExit
extends WeaponStateExit
@export var compatible_triggers : Array[Gl.trigger_states]
func exit_weapon_state(weapon : Weapon,weapon_state : WeaponState):
	for i in len(compatible_triggers):
		if weapon.trigger == compatible_triggers[i]:
			return get_next_state(weapon_state)

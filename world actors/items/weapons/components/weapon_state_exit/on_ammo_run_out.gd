class_name OnAmmoRunOut
extends WeaponStateExit
func exit_weapon_state(weapon : Weapon,weapon_state : WeaponState):
	weapon as RangedWeapon
	if weapon_state.weapon_manager.ammo <= 0.:
		return get_next_state(weapon_state)

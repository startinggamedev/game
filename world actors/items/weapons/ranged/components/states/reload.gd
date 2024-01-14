extends WeaponState
func enter():
	super()
func exit():
	super()
	weapon_manager.reload()

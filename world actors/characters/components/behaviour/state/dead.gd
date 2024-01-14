class_name DeadState
extends State
@onready var character = $"../.."
@onready var animation_player = $"../../animation_player"
func enter():
	animation_player.play("death_animation")

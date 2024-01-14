class_name MouseManager
extends Node2D
var pos : Vector2 = Vector2.ZERO
@export var crosshair_sprites : Array[Sprite2D]
@export var crosshair_smoothing : Array[float]
@export var crosshair_rotation : Array[float]
func _process(delta):
	for i in len(crosshair_sprites):
		crosshair_sprites[i].rotation += crosshair_rotation[i] * delta
		crosshair_sprites[i].global_position = Gl.delta_lerp(get_global_mouse_position(),crosshair_sprites[i].global_position,crosshair_smoothing[i],delta * 60.)
	Input.set_mouse_mode(Input.MOUSE_MODE_HIDDEN)

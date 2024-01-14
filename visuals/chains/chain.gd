@tool
class_name Chain
extends Node2D
@export var texture : Texture2D
@export var chain_end : Node2D
@onready var texture_rect = $TextureRect
func _process(delta):
	process_priority = -1000
	if !chain_end: return
	texture_rect.texture = texture
	texture_rect.size.y = texture.get_height()
	texture_rect.rotation = global_position.angle_to_point(chain_end.global_position)
	texture_rect.size.x = global_position.distance_to(chain_end.global_position)

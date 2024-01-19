extends Node2D
@onready var world_viewport = $SubViewportContainer/world_viewport
# Called when the node enters the scene tree for the first time.
func _ready():
	Singleton

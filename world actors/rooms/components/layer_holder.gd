extends CanvasLayer
@onready var characters = $world/characters
func _ready():
	Gl.character_layer = characters

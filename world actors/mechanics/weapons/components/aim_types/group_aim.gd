class_name GroupAimType
extends AimType
@export var target_group: String
func aim_function(aim_object : Node2D,delta : float):
	var target_node : Node2D = Gl.get_nearest_node_in_group(target_group,aim_object.global_position)
	if target_node: aim_object.rotation = aim_object.global_position.angle_to_point(target_node.global_position)

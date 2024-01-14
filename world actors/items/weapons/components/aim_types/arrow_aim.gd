class_name ArrowAimType
extends AimType
func aim_function(aim_object : Node2D,delta : float):
	var arrow_axis = Vector2(Input.get_axis("left","right"),Input.get_axis("up","down"))
	if arrow_axis.length() == 0.: arrow_axis = aim_object.rotation
	else: arrow_axis = arrow_axis.angle()
	aim_object.rotation = arrow_axis

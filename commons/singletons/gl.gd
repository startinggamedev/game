class_name Global
extends Node2D
enum trigger_states {released,pressed,held}
#make sure weapon and player types are in the same order but offset by three
enum types {all,player,enemy,all_weapon,player_weapon,enemy_weapon}
const damage_types : Array[DamageType] = [preload("res://world actors/characters/components/health/damage types/all_type.tres"),
preload("res://world actors/characters/components/health/damage types/player_type.tres"),
preload("res://world actors/characters/components/health/damage types/enemy_type.tres"),preload("res://world actors/characters/components/health/damage types/weapon_all_type.tres"),
preload("res://world actors/characters/components/health/damage types/weapon_player_type.tres"),preload("res://world actors/characters/components/health/damage types/weapon_enemy_type.tres")]
var character_holder : Node
var air_friction : float = 0.7
var gravity : Vector2 = Vector2(0.,80,)
func _ready():
	randomize()
func is_node_in_group_array(node : Node,group_array : Array[StringName]):
	var node_groups = node.get_groups()
	for i in len(node_groups):
		if group_array.has(node_groups[i]):
			return true
	return false
func get_nearest_node_in_group(group : StringName,global_pos : Vector2):
	var nodes : Array[Node] = get_tree().get_nodes_in_group(group)
	if !nodes:
		return null
	var nearest_node : Node2D
	var nearest_distance : float = INF
	for i in len(nodes):
		var current_distance : float = nodes[i].global_position.distance_to(global_pos)
		if  current_distance  < nearest_distance:
			nearest_distance = current_distance
			nearest_node = nodes[i]
	return nearest_node
func add_child_to(possible_parents : Array[Node],child : Node):
	for i in len(possible_parents):
		if is_instance_valid(possible_parents[i]):
			possible_parents[i].add_child(child)
			return true
	return false
func vector_from_angle_and_magnitude(angle,magnitude):
	return Vector2.from_angle(angle) * magnitude
func get_ray_global_target_pos(ray : RayCast2D):
	return ray.global_position + ray.target_position.rotated(ray.global_rotation)
func safe_connect(signal_ : Signal,callable : Callable) -> bool:
	if !signal_.is_connected(callable):
		signal_.connect(callable)
		return true
	return false
func safe_disconnect(signal_ : Signal,callable : Callable) -> bool:
	if signal_.is_connected(callable):
		signal_.disconnect(callable)
		return true
	return false
func delta_lerp(from,to,weight,delta):
	weight = abs(weight - 1.)
	return lerp(from,to, 1 - pow(weight,delta))
func delta_angle_lerp(from,to,weight,delta):
	weight = abs(weight - 1.)
	return lerp_angle(from,to, 1 - pow(weight,delta))
func mirror(vector : Vector2,mirror : Vector2):
	return vector.reflect(mirror).rotated(PI)
func clamp_length(vector : Vector2,min_length,max_length) -> Vector2:
	return vector.normalized() * clamp(vector.length(),min_length,max_length)
func abs_clamp(value,abs_min,abs_max):
	abs_max = abs(abs_max)
	abs_min = abs(abs_min)
	value = clamp(abs(value),abs_min,abs_max) * sign(value)
	return value

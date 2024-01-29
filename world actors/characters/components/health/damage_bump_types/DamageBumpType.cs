using Godot;
using System;

[GlobalClass]
public abstract partial class DamageBumpType : Resource
{
// Called when the node enters the scene tree for the first time.
	public abstract Godot.Vector2 BumpFunction(double delta,Character Bumper,Character Bumped);
}

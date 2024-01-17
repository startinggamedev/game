using Godot;
using System;

public partial class FrictionArea : Area2D
{
	[Export]
	private float friction;
	public float Friction{get;private set;}
}

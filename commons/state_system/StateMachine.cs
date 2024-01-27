using Godot;
using System;
[GlobalClass]
public partial class StateMachine : StateThread
{
	public override void _Ready()
	{
		base._Ready();
		Enter();
	}
	public override void _PhysicsProcess(double delta)
	{
		Physics(delta);
		base._PhysicsProcess(delta);
	}
	public override void _Process(double delta)
	{
		Process(delta);
		base._Process(delta);
	}
}

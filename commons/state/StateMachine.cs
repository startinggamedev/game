using Godot;
using System;
[GlobalClass]
public partial class StateMachine : Node
{
	[Export]
	State RootState;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Ready()
	{
		foreach(var CurrentThread in RootState.Threads)
		{
			CurrentThread.Enter(this);
		}
	}
	public void Process(double delta)
	{
		RootState.Process(delta);
		if (RootState is null){return;}
		StateTools.RunStateProcess(delta,RootState);
	}
	public void Physics(double delta)
	{
		if (RootState is null){return;}
		StateTools.RunStatePhysics(delta,RootState);
	}
	public override void _Process(double delta)
	{
		Process(delta);
	}
	public override void _PhysicsProcess(double delta)
	{
		Physics(delta);
	}
}

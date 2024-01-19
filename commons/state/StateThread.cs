using Godot;
using System;
using System.Runtime.Serialization;
[GlobalClass]
public partial class StateThread : Resource{
	[Export]
	Godot.Collections.Array<State> States;
	[Export]
	private State StartingState;
	private State CurrentState;
	#region methods
	private int GetStateIndex(State StateToCheck)
	{
		int StateIndex = States.IndexOf(StateToCheck);
		if (StateIndex == -1){GD.PushError("State is not part of 'States' Array");}
		return StateIndex;
	}
	public void Enter()
	{
		CurrentState = States[GetStateIndex(StartingState)];
		CurrentState.Enter();
		foreach (var CurrentThread in CurrentState.Threads)
			{
				CurrentThread.Enter();
			}
	}
	public void Exit()
	{
		CurrentState.Exit();
		foreach (var CurrentThread in CurrentState.Threads)
		{
			CurrentThread.Exit();
		}
	}
	private void ChangeStateTo(State NextState)
	{
		if (NextState is null){return;}
		CurrentState.Exit();
		foreach (var CurrentThread in CurrentState.Threads)
		{
			CurrentThread.Exit();
		}
		CurrentState = States[GetStateIndex(NextState)];
		CurrentState.Enter();
		foreach(var CurrentThread in CurrentState.Threads)
		{
			CurrentThread.Enter();
		}
	}
	public void Process(double delta)

	{    
		ChangeStateTo(CurrentState.NextState);
		StateTools.RunStateProcess(delta,CurrentState);
	}
	public void Physics(double delta)
	{
		StateTools.RunStatePhysics(delta,CurrentState);
	}
	#endregion
}

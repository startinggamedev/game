using Godot;
using System;
using System.Runtime.Serialization;
[GlobalClass]
public partial class StateThread : StateMachineComponent{
	[Export]
	private Godot.Collections.Array<State> States;
	[Export]
	private State StartingState;
	private State CurrentState;


    #region methods
	protected virtual void OnStateChange(State CurrentState){}
    private int GetStateIndex(State StateToCheck)
	{
		int StateIndex = States.IndexOf(StateToCheck);
		if (StateIndex == -1){GD.PushError("State is not part of 'States' Array");}
		return StateIndex;
	}
	
	private void ChangeCurrentStateTo(State NextState)
	{
		if (NextState is null){return;}
		CurrentState.Exit();
		foreach (var CurrentThread in CurrentState.Threads)
		{
			CurrentThread.Exit();
		}
		ChangeCurrentState(NextState);
	}
	private void ChangeCurrentState(State NextState)
	{
		CurrentState = States[GetStateIndex(NextState)];
		CurrentState.MyStateMachine = MyStateMachine;
		CurrentState.Enter();
		OnStateChange(CurrentState);
		foreach(var CurrentThread in CurrentState.Threads)
		{
			CurrentThread.Enter(MyStateMachine);
		}
	}

	public virtual void Process(double delta)
	{    
		ChangeCurrentStateTo(CurrentState.NextState);
		StateTools.RunStateProcess(delta,CurrentState);
	}
	public virtual void Physics(double delta)
	{
		StateTools.RunStatePhysics(delta,CurrentState);
	}
	public virtual void Enter(StateMachine CurrentStateMachine)
	{
		MyStateMachine = CurrentStateMachine;
		ChangeCurrentState(StartingState);
	}
	public virtual void Exit()
	{
		CurrentState.Exit();
		foreach (var CurrentThread in CurrentState.Threads)
		{
			CurrentThread.Exit();
		}
	}
    #endregion
}

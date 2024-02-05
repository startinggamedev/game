using Godot;
using System;
[GlobalClass]
public partial class StateThread : Node
{
	[Export]
	State StartingState;

	public State CurrentState{get;private set;}

	Godot.Collections.Array<State> MyStates;
	private void ChangeCurrentState(State NextState)
	{
		if (NextState is null){return;}
		if (CurrentState is not null)
			{
				CurrentState.Exit();
			}
		if(NextState.MyStateThread != this)
		{
			GD.Print(Name);
			GD.Print(NextState.Name);
			GD.Print(NextState.MyStateThread);
			GD.PushError("current state must be a direct child of this thread");
			return;
		}
		CurrentState = NextState;
		CurrentState.Enter();
		OnStateChange(CurrentState);
	}
		protected virtual void OnStateChange(State CurrentState){}
	protected void QueueNextState(State NextState)
	{
		if(NextState is null){return;}
		NextStateQueue = () => ChangeCurrentState(NextState);
	}

	private Action NextStateQueue;

	public override void _Ready()
	{
		MyStates = NodeUtilities.GetChildren<State>(this);
	}
	public virtual void Process(double delta)
	{
		CurrentState.Process(delta);
		QueueNextState(CurrentState.NextState);
		if(NextStateQueue is not null)
		{
			NextStateQueue();
			NextStateQueue = null;
		}

	}
	public virtual void Physics(double delta)
	{
		CurrentState.Physics(delta);
	}
	public virtual void Enter()
	{
		ChangeCurrentState(StartingState);
	}
	public virtual void Exit()
	{
		CurrentState.Exit();
		CurrentState = null;
	}
}

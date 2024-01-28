using Godot;
using System;
[GlobalClass]
public partial class State : Node
{
	public StateThread MyStateThread{get;private set;}
	public Godot.Collections.Array<StateThread> MyThreads;
	public State NextState;
	public override void _Ready()
	{
		MyStateThread = (StateThread)GetParent();
		MyThreads = NodeUtilities.GetChildren<StateThread>(this);
		base._Ready();
	}
	public  void Process(double delta)
	{
		foreach (var Threads in MyThreads)
		{
			Threads.Process(delta);
		}
		ProtectedProcess(delta);
		}
	public  void Physics(double delta)
	{
		foreach (var Threads in MyThreads)
		{
			Threads.Physics(delta);
		}    
		ProtectedPhysics(delta);
	}
	public  void Enter()
	{
		ProtectedEnter();
		foreach (var Thread in MyThreads)
		{
			Thread.Enter();
		}
		}
	public  void Exit()
	{
		ProtectedExit();
		NextState = null;
		foreach (var Thread in MyThreads)
		{
			Thread.Exit();
		}
	}
	protected virtual void ProtectedProcess(double delta){}
	protected virtual void ProtectedPhysics(double delta){}
	protected virtual void ProtectedEnter(){}
	protected virtual void ProtectedExit(){}
}

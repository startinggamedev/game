using Godot;
using System;
using System.Dynamic;
[GlobalClass]
public  partial class State : Resource{
	[Export]
	public Godot.Collections.Array<StateThread> Threads;

	public State NextState{get; protected set;}
	public  virtual void Enter(){}
	public  virtual void Exit(){}
	public  virtual void Process(double delta){}
	public  virtual void Physics(double delta){}
}

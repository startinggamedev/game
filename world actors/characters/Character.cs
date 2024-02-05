using Godot;
using System;

[GlobalClass]
public partial class Character : PhysicsBody,IUsesType
{
	#region exportedvariables
	[Export]
	public Gl.Types Type;
	
	#endregion
	#region ExportedNodes

	[Export]
	public HealthManager MyHealthManager {get; private set;}
	[Export]
	public DamageDetector MyDamagedetector{get;private set;}
	#endregion

	#region Interface implementations
	public void SetUpType(int Type){}
	public int GetMyType(){return (int)Type;}
	#endregion

	#region processes
	public override void _Ready()
	{
		base._Ready();
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
	}
	#endregion
}

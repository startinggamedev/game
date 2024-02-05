using System;
using System.Dynamic;
using Godot;
[GlobalClass]
public partial class Bullet : Character,IAimObject
{
	[Export]
	public AimResource MyAimResource{get;set;}
	[Export]
	public AimType MyAimType{get;set;}
	[Export]
	int Penetration = 0;
	[Export]
	int Ricochets = 0;
	public override void _Ready()
	{
		MyHealthManager.AddExtraDamage(new CollisionDamage(new DamageRes(float.PositiveInfinity)));
		MyHealthManager.AddExtraDamage(new CollateralDamage(new DamageRes(float.PositiveInfinity)));
		base._Ready();
	}
	public override void _Process(double delta)
	{
		MyAimResource.AimProcess(this,delta,MyAimType);
		base._Process(delta);
	}
}

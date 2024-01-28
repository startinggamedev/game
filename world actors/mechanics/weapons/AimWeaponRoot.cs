using Godot;
using System;
public partial class AimWeaponRoot : WeaponRoot
{
	[Export]
	public AimResource MyAimResource{get;private set;} = new AimResource(); 
		public override void _Process(double delta)
	{
		MyAimResource.AimProcess(this,delta);
		base._Process(delta);
	}
}

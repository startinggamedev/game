using Godot;
using System;
public partial class AimWeaponRoot : WeaponRoot,IAimObject
{
	[Export]
	public AimType MyAimType {get;set;}
	[Export]
	public AimResource MyAimResource {get;set;}

	public override void _Process(double delta)
	{
		MyAimResource.AimProcess(this,delta,MyAimType);
		base._Process(delta);
	}
}

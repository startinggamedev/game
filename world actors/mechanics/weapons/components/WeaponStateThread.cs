using Godot;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
[GlobalClass]
public partial class WeaponStateThread : AnimationStateThread
{
	[Export]
	public WeaponManager MyWeaponManager{get;private set;}
	[Export]
	public WeaponManager TestMyWeaponManager{get;private set;}

	public override void _Ready()
	{
		base._Ready();
	}
	protected override void OnStateChange(State CurrentState)
	{
		base.OnStateChange(CurrentState);
	}
}

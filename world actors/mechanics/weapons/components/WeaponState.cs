using Godot;
using System;
using System.Runtime.InteropServices;
[GlobalClass]
public partial class WeaponState: AnimationState{
	public WeaponStateExitCondition MyWeaponStateExitCondition;
	public override void Process(double delta)
	{
	if (MyStateMachine is not WeaponManager){
		GD.PushError("Weapon state should belong to a Weapon Manager");
		return;
		}
		GD.Print(MyWeaponStateExitCondition);
		NextState = MyWeaponStateExitCondition.ExitCondition((WeaponManager)MyStateMachine);
	}
}

using Godot;
using System;
[GlobalClass]
public partial class OnTriggerExitCondition : WeaponStateExitCondition
{
	[Export]
	float MinTriggerTime;
	[Export]
	float MaxTriggerTime = float.PositiveInfinity;
	public override State ExitCondition(WeaponManager MyWeaponManager)
	{
		if((MyWeaponManager.MyTrigger.TimeTriggered) >= MinTriggerTime && (MyWeaponManager.MyTrigger.TimeTriggered) <= MaxTriggerTime )
		{
			
			return GetNextState();
		}
		else{return null;}
	}

}

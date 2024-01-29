using Godot;
using System;
using System.Runtime.InteropServices;
using System.Threading;
[GlobalClass]
public partial class WeaponState: State
{
	[Export]
	Godot.Collections.Array<WeaponStateExitCondition> StateExitConditions = new Godot.Collections.Array<WeaponStateExitCondition>();

	WeaponManager MyWeaponManager;
	protected override void ProtectedProcess(double delta)
	{
		if(MyStateThread is not WeaponStateThread)
		{
			GD.PushError("WeaponState should be direct child of weapon state thread, which it isnt, so it wont work properly");
			return;
		}
		WeaponStateThread MyWeaponThread = (WeaponStateThread)MyStateThread; 
		foreach (WeaponStateExitCondition CurrentCondition in StateExitConditions)
		{
			double AnimationProgress = 0.0;
			if (MyStateThread is AnimationStateThread)
			{
			AnimationPlayer MyAnimationPlayer = ((AnimationStateThread)MyStateThread).ThreadAnimationPlayer;
			AnimationProgress = MyAnimationPlayer.CurrentAnimationPosition / MyAnimationPlayer.CurrentAnimationLength;
			}
			if (AnimationProgress >= CurrentCondition.Start && AnimationProgress <= CurrentCondition.End)
			{
				CurrentCondition.MyState = this;
				NextState = CurrentCondition.ExitCondition(MyWeaponThread.MyWeaponManager) ?? NextState;
			}
		}
		base.ProtectedProcess(delta);
	}
}

using Godot;
using System;
using System.Runtime.InteropServices;
using System.Threading;
[GlobalClass]
public partial class WeaponState: State
{
	[Export]
	Godot.Collections.Array<WeaponStateExitCondition> StateExitConditions = new Godot.Collections.Array<WeaponStateExitCondition>();

	protected WeaponManager MyWeaponManager;
	protected WeaponStateThread MyWeaponThread;
	protected override void ProtectedEnter()
	{
		if(MyStateThread is not WeaponStateThread)
		{
			GD.PushError("WeaponState should be direct child of weapon state thread, which it isnt, so it wont work properly");
			return;
		}
		WeaponStateThread MyWeaponThread = (WeaponStateThread)MyStateThread;
		MyWeaponManager = MyWeaponThread.MyWeaponManager;
		base.ProtectedEnter();
	}
	protected override void ProtectedProcess(double delta)
	{
		 
		foreach (WeaponStateExitCondition CurrentCondition in StateExitConditions)
		{
			double AnimationProgress = 0.0;
			if (MyStateThread is AnimationStateThread)
			{
			AnimationPlayer MyAnimationPlayer = ((AnimationStateThread)MyStateThread).ThreadAnimationPlayer;
			AnimationProgress = NodeUtilities.GetAnimationProgress(MyAnimationPlayer);
			}
			if (AnimationProgress >= CurrentCondition.Start && AnimationProgress <= CurrentCondition.End)
			{
				CurrentCondition.MyState = this;
				NextState = CurrentCondition.ExitCondition(MyWeaponManager) ?? NextState;
			}
		}
		base.ProtectedProcess(delta);
	}
}

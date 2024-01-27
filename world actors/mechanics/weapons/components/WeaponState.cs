using Godot;
using System;
using System.Runtime.InteropServices;
using System.Threading;
[GlobalClass]
public partial class WeaponState: State
{
	[Export]
	Godot.Collections.Array<WeaponStateExitCondition> StateExitConditions;

	WeaponManager MyWeaponManager;
	protected override void ProtectedProcess(double delta)
	{
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
				NextState = CurrentCondition.ExitCondition(MyWeaponManager) ?? NextState;
			}
		}
		base.Process(delta);
	}
}

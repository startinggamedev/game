using Godot;
using System;
using System.Collections.Generic;

public partial class BladeFanNormalBehaviour : State
{
	[Export]
	AnimationPlayer FanAnimationPlayer;
	[Export]
	 Rocket FanRocket;
	[Export]
	Trigger FanTrigger;
	[Export]
	AimType RocketAimType;
	protected override void ProtectedProcess(double delta)
	{
		FanTrigger.UpdateTriggerState(delta);
		bool IsTriggered = FanTrigger.IsTriggered();
		FanRocket.MyTrigger.CanBeTriggered = IsTriggered;
		FanRocket.MyAimResource.CanAim = IsTriggered;
		if (IsTriggered)
		{
			FanAnimationPlayer.Play("Moving");
		}
		else{FanAnimationPlayer.Play("Idle");}
		base.ProtectedProcess(delta);
	}
	protected override void ProtectedPhysics(double delta)
	{
		base.ProtectedPhysics(delta);
	}
	protected override void ProtectedEnter()
	{
		FanRocket.MyAimResource.MyAimType = RocketAimType;
		base.ProtectedEnter();
	}
	protected override void ProtectedExit()
	{
		base.ProtectedExit();
	}
}


using Godot;
using System;
using System.Runtime.InteropServices;
[GlobalClass]
public partial class AnimationStateThread : StateThread
{
	[Export]
	public AnimationPlayer ThreadAnimationPlayer{get;private set;}

	protected override void OnStateChange(State CurrentState)
	{
		ThreadAnimationPlayer.Play(CurrentState.Name);
		base.OnStateChange(CurrentState);
	}

}

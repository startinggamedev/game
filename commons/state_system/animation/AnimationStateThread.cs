using Godot;
using System;
using System.Runtime.InteropServices;
[GlobalClass]
public partial class AnimationStateThread : StateThread
{
	[Export]
	public AnimationPlayer ThreadAnimationPlayer{get;private set;}
	[Export]
	StringName DefaultAnimation;

	protected override void OnStateChange(State CurrentState)
	{
		if (ThreadAnimationPlayer.HasAnimation(CurrentState.Name))
		{
		ThreadAnimationPlayer.Play(CurrentState.Name);
		}
		else if (ThreadAnimationPlayer.HasAnimation(DefaultAnimation))
		{
			ThreadAnimationPlayer.Play(DefaultAnimation);
		}
		base.OnStateChange(CurrentState);
	}

}

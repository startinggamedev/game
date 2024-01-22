using Godot;
using System;
[GlobalClass]
public partial class AnimationStateThread : StateThread
{
	[Export]
	NodePath ThreadAnimationPlayerPath;

	protected AnimationPlayer ThreadAnimationPlayer;

	protected override void OnStateChange(State CurrentState)
	{
		if (CurrentState is AnimationState)
		{
			ThreadAnimationPlayer = GetNode<AnimationPlayer>(ThreadAnimationPlayerPath);
			ThreadAnimationPlayer.Play(((AnimationState)CurrentState).Animation);
		}
		base.OnStateChange(CurrentState);
	}

}

using Godot;
using System;
[GlobalClass]
public partial class AnimationState : State
{
	[Export]
	public StringName Animation {get;protected set;}

	public AnimationPlayer StateAnimationPlayer;
}

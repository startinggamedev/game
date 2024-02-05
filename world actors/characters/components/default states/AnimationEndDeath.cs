using Godot;
using System;
[GlobalClass]
public partial class AnimationEndDeath : DeathBehaviour
{
    AnimationStateThread MyAnimationThread;
    protected override void ProtectedEnter()
    {
        base.ProtectedEnter();
        MyAnimationThread = GetParent<AnimationStateThread>();
        if (MyAnimationThread is null)
        {
            GD.PushError("AnimationEndDeath's thread is not a animation thread.");
        }
        
    }

    protected override void ProtectedProcess(double delta)
    {
        base.ProtectedProcess(delta);
        if(MyAnimationThread is null){return;}
        if(NodeUtilities.GetAnimationProgress(MyAnimationThread.ThreadAnimationPlayer) >= 1.0)
        {
            MyCharacter.QueueFree();
        }
    }
}
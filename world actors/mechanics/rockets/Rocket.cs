using Godot;
using System;
public partial class Rocket : Node2D
{
	[Export]
	float Acceleration;
	[Export]
	float TargetMomentumMagnitude;
	[Export]
	public Trigger MyTrigger = new AutomaticTrigger();
	[Export]
	public AimResource MyAimResource = new AimResource();
	[Export]
	PhysicsBody MyBody;
	[Export]
	GpuParticles2D RocketParticles;
	[Export]
	AnimationPlayer MyAnimationPlayer;


	public override void _PhysicsProcess(double delta)
	{
		MyTrigger.UpdateTriggerState(delta);
		MyAimResource.AimProcess(this,delta);
		RocketParticles.Amount = (int)(Math.Sqrt(TargetMomentumMagnitude) * 5f);
		if (MyTrigger.TimeTriggered > 0f)
		{
			MyBody.ApplyForce(MyMath.VectorFromAngleAndMagnitude(GlobalRotation,TargetMomentumMagnitude),
			Acceleration);
			MyAnimationPlayer.Play("Moving");
		}
		else
		{
			MyAnimationPlayer.Play("Idle");
		}
		RocketParticles.Emitting = MyTrigger.TimeTriggered > 0f;
		base._PhysicsProcess(delta);
	}

}

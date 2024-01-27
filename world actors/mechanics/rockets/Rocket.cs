using Godot;
using System;
public partial class Rocket : Node2D
{
	[Export]
	float Acceleration;
	[Export]
	float TargetMomentumMagnitude;
	[Export]
	Trigger MyTrigger = new AutomaticTrigger();
	[Export]
	private AimResource MyAimResource = new AimResource();
	[Export]
	PhysicsBody MyBody;
	[Export]
	GpuParticles2D RocketParticles;
	[Export]
	AnimationPlayer MyAnimationPlayer;


	public override void _PhysicsProcess(double delta)
	{
		MyAimResource.AimProcess(this,delta);
		RocketParticles.Amount = (int)(Math.Sqrt(TargetMomentumMagnitude) * 10f);
		RocketParticles.Amount = (int)(Acceleration * 0.005);
		if (MyTrigger.TimeTriggered > 0f)
		{
			MyBody.ApplyForce(MyMath.VectorFromAngleAndMagnitude(GlobalRotation,TargetMomentumMagnitude),
			Acceleration);
			MyAnimationPlayer.Play("moving");
		}
		else
		{
			MyAnimationPlayer.Play("idle");
		}
		RocketParticles.Emitting = MyTrigger.TimeTriggered > 0f;
		base._PhysicsProcess(delta);
	}

}

using Godot;
using System;
public partial class Rocket : Node2D,IAimObject,IUsesCharacter
{
	[Export]
	float Acceleration;
	[Export]
	float TargetMomentumMagnitude;
	[Export]
	public float momentum_scale{get{return MomentumScale;}set{MomentumScale = value;}}	
	[Export]
	private float MomentumScale = 1f;
	[Export]
	public Trigger MyTrigger = new AutomaticTrigger();
	[Export]
	public AimResource MyAimResource{get;set;}
	[Export]
	public AimType MyAimType{get;set;}
	public CharacterGetter MyCharacterGetter { get; set; } = new CharacterGetter();
	public Character MyCharacter { get; set; }

	[Export]
	GpuParticles2D RocketParticles;
	[Export]
	AnimationPlayer MyAnimationPlayer;

	public override void _Ready()
	{
		MyCharacterGetter.GetCharacter(this);
		base._Ready();
	}
	public override void _PhysicsProcess(double delta)
	{
		MyTrigger.UpdateTriggerState(delta);
		MyAimResource.AimProcess(this,delta,MyAimType);
		RocketParticles.Amount = (int)(Math.Sqrt(TargetMomentumMagnitude * MomentumScale) * 5f);
		if (MyTrigger.TimeTriggered > 0f)
		{
			MyCharacter.ApplyForce(MyMath.VectorFromAngleAndMagnitude(GlobalRotation,TargetMomentumMagnitude * MomentumScale),
			Acceleration * MomentumScale);
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

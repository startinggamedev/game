using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;

public partial class PhysicsBody : CharacterBody2D{
	[Export]
	public float Weight = 1f;
	[Export]
	public float Bounciness = 0f;
	[Export(PropertyHint.Range,"0.,1.,0.02")]
	public float FrictionMultiplier = 1f;

//Physics Properties
	public bool collided = false;
	public Godot.Vector2 Momentum = Godot.Vector2.Zero;
	private List<float> FrictionList = new List<float>();
	private List<Godot.Vector2> TargetVelocities = new List<Godot.Vector2>();
	private Godot.Vector2 AccelerationDirection;
	private Godot.Vector2 CollisionNormal = new Godot.Vector2(0f,0f);
	private Godot.Vector2 PrevGlobalPosition = Godot.Vector2.Zero;
//Node References
	private FrictionAreaDetector MyFrictionAreaDetector;

	public void SetCollidability(bool CanCollide)
	{
		SetCollisionMaskValue(1,CanCollide);
	}

	public void ApplyForce(Godot.Vector2 ForceTargetMomentum,float Acceleration)
	{
		AccelerationDirection = AccelerationDirection + 
		(Acceleration * ForceTargetMomentum.Normalized());
		TargetVelocities.Add(ForceTargetMomentum);
	}

	public void ApplyImpulse(Godot.Vector2 Impulse){
		Momentum += Impulse / 60f;
	}

	public void AddFriction(float FrictionToAdd){
		FrictionList.Add(FrictionToAdd);
	}

	public void AddFriction(List<float> FrictionToAdd){
		FrictionList.AddRange(FrictionToAdd);
	}

	public void Debugdelta(double delta){
		GD.Print(GlobalPosition.DistanceTo(PrevGlobalPosition) / delta);
	}

	private void ApplyFriction(List<float> FrictionCollection,double Delta)
	{
		float Friction = 0;
		for (int i = FrictionCollection.Count -1;i >= 0;i--)
		{
			Friction = Mathf.Lerp(Friction,FrictionMultiplier,FrictionCollection[i]);
		}
		Momentum = MyMath.DeltaLerp(Momentum,Godot.Vector2.Zero,Friction,Delta);
		GD.Print(MyMath.DeltaLerp(0f,1f,Friction,Delta));
	}
	private void CalculateMomentum(double delta)
	{
		var TargetMomentum = new Godot.Vector2(0f,0f);
		int TargMomentumAmnt = TargetVelocities.Count;
		var NormalizedAcceleration = AccelerationDirection.Normalized();
		for (int i = 0;i < TargMomentumAmnt;i++)
		{
				TargetMomentum += NormalizedAcceleration * Math.Clamp(TargetVelocities[i].Dot(NormalizedAcceleration),0f,float.PositiveInfinity);
		}
		Momentum = Momentum.MoveToward(TargetMomentum,AccelerationDirection.Length() * (float)delta);
		AccelerationDirection = new Godot.Vector2(0f,0f);
		TargetVelocities.Clear();
}

	private void Bounce(Godot.Vector2 Mirror,float BounceScale)
	{
		Momentum = MyMath.Mirror(Momentum,Mirror.Normalized()) * BounceScale;
	}
	private void Move()
	{
		PrevGlobalPosition = GlobalPosition;
		Velocity = Momentum / Weight;
		if(MoveAndSlide() && GetSlideCollisionCount() > 0){
			Bounce(GetWallNormal(),Bounciness);
		}
	}

	public override void _Ready()
	{
		MyFrictionAreaDetector = GetNode<FrictionAreaDetector>("FrictionAreaDetector");
	}

	public override void _PhysicsProcess(double delta)
	{	
		CalculateMomentum(delta);
		AddFriction(MyFrictionAreaDetector.DetectFriction());
		ApplyFriction(FrictionList,delta);
		Move();
		FrictionList.Clear();
	}
}

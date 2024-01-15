using Godot;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;

public partial class PhysicsBody : CharacterBody2D{
[Export]
public float Weight;
[Export]
public float Bounciness = 0f;
[Export] 
public bool collided = false;
[Export(PropertyHint.Range,"0.,1.,0.02")]
public float FrictionMultiplier{
	get{return FrictionMultiplier;}
	set{FrictionMultiplier = Math.Clamp(value,0f,1f);}
}

private List<Godot.Vector2> TargetVelocities = new List<Godot.Vector2>();
private Godot.Vector2 AccelerationDirection;
private Godot.Vector2 CollisionNormal = new Godot.Vector2(0f,0f);

public override void _PhysicsProcess(double delta){
	CalculateVelocity(delta);
}



public void SetCollidability(bool CanCollide){
    SetCollisionMaskValue(1,CanCollide);
}

public void ApplyForce(Godot.Vector2 ForceTargetVelocity,float Acceleration){
	AccelerationDirection = AccelerationDirection + 
	(Acceleration * ForceTargetVelocity.Normalized());
	TargetVelocities.Add(ForceTargetVelocity);
}
public void ApplyFriction(float Friction){
	Friction = Mathf.Lerp(Friction,0f,FrictionMultiplier);
}
private void CalculateVelocity(double delta){
	var TargetVelocity = new Godot.Vector2(0f,0f);
	int TargVelocityAmnt = TargetVelocities.Count;
	var NormalizedAcceleration = AccelerationDirection.Normalized();
	for (int i = 0;i < TargVelocityAmnt;i++)
	{
			TargetVelocity += NormalizedAcceleration * Math.Clamp(TargetVelocities[i].Dot(NormalizedAcceleration),0f,float.PositiveInfinity);
	}
	Velocity = Velocity.MoveToward(TargetVelocity,AccelerationDirection.Length() * (float)delta);
	AccelerationDirection = new Godot.Vector2(0f,0f);
	TargetVelocities.Clear();
}

private void Bounce(Godot.Vector2 Normal){
	Velocity = Gl
}
 private void Move(){
	if(MoveAndSlide()){

	}
 }

}
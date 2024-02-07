using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;

public partial class PhysicsController : Resource{
	[Export]
	public float Weight = 1f;
	[Export]
	public float Bounciness = 0f;
	[Export(PropertyHint.Range,"0.,1.,0.02")]
	public float FrictionMultiplier = 1f;

//Physics Properties
	public bool Collided = false;
	public Godot.Vector2 Momentum = Godot.Vector2.Zero;
	private List<float> FrictionList = new List<float>();
	private List<Godot.Vector2> TargetVelocities = new List<Godot.Vector2>();
	private Godot.Vector2 AccelerationDirection;
	private Godot.Vector2 CollisionNormal = new Godot.Vector2(0f,0f);
	private Godot.Vector2 PrevGlobalPosition = Godot.Vector2.Zero;
//Node References
	private FrictionAreaDetector MyFrictionAreaDetector;


	#region momentum methods
	public void ApplyForce(Godot.Vector2 ForceTargetMomentum,float Acceleration)
	{
		AccelerationDirection = AccelerationDirection + 
		(Acceleration * ForceTargetMomentum.Normalized());
		TargetVelocities.Add(ForceTargetMomentum);
	}
	public void AttractToPoint(Godot.Vector2 Point,float AttractionAcceleration)
	{
		ApplyForce(Point - GlobalPosition,AttractionAcceleration);
	}
	public void ApplyImpulse(Godot.Vector2 Impulse){
		Momentum += Impulse;
	}

	public void AddFriction(float FrictionToAdd){
		FrictionList.Add(FrictionToAdd);
	}

	public void AddFriction(List<float> FrictionToAdd){
		FrictionList.AddRange(FrictionToAdd);
	}
	
	public void Debugdelta(double delta,CharacterBody2D MyBody){
		GD.Print("Velocity seconds: " + (MyBody.GlobalPosition.DistanceTo(PrevGlobalPosition) / delta).ToString());
	}

	private void ApplyFriction(List<float> FrictionCollection,double Delta)
	{
		float Friction = 0;
		for (int i = FrictionCollection.Count -1;i >= 0;i--)
		{
			Friction = Mathf.Lerp(Friction,FrictionMultiplier,FrictionCollection[i]);
		}
		Momentum = MyMath.DeltaLerp(Momentum,Godot.Vector2.Zero,Friction,Delta);
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

	#endregion
	#region collision methods
	private void Move()
	{
		PrevGlobalPosition = GlobalPosition;
		Velocity = Momentum / Weight;
		Collided = MoveAndSlide();
		if(Collided){
			Bounce(GetWallNormal(),Bounciness);
		}
	}
	public void SetCollidability(bool CanCollide)
	{
		SetCollisionMaskValue(1,CanCollide);
	}
	public Godot.Collections.Dictionary RayCollisionCheck(float RayDirection,float RayLength)
	{
		return NodeUtilities.CastRay(this,GlobalPosition,GlobalPosition + MyMath.FromDirAndMag(RayDirection,RayLength),
		new Godot.Collections.Array<Rid>(){GetRid()},1);
	}
	public List<Node2D> GetVisibleNodesByDistance(StringName Group,float SearchRange = float.PositiveInfinity)
	{
		var Nodes = NodeUtilities.GetGroupNodesByDistance(GlobalPosition,Group,SearchRange);
		List<Node2D> NodesToremove = new List<Node2D>(); 
		foreach (var CurrentNode in Nodes)
		{
			var Exceptions = new Godot.Collections.Array<Rid>(){GetRid()};
			if(CurrentNode is CollisionObject2D)
			{
				Exceptions.Add(((CollisionObject2D)(CurrentNode)).GetRid());
			}
			if (NodeUtilities.CastRay(this,GlobalPosition,CurrentNode.GlobalPosition,Exceptions,1).Count > 0)
			{
				NodesToremove.Add(CurrentNode);
			}
		}
		foreach(Node2D CurrentNode in NodesToremove)
		{
			Nodes.Remove(CurrentNode);
		}
		return Nodes;
	}
	#endregion
	#region processes

	public override void Physics(double delta,CharacterBody2D MyBody)
	{	
		CalculateMomentum(delta);
		AddFriction(MyFrictionAreaDetector.DetectFriction());
		ApplyFriction(FrictionList,delta);
		Move();
		FrictionList.Clear();
	}
	#endregion
}

using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ForceField : ForceFieldDetector
{
	[Export]
	float Magnitude;
	[Export(PropertyHint.Range,"-6.2831,6.2831,0.")]
	float Direction;
	[Export]
	float Acceleration;
	[Export]
	float ForceScale = 1f;
	[Export]
	bool  IsAttractive;
	[Export]
	Godot.Collections.Array<PhysicsBody> NodeExceptions;
	[Export]
	Godot.Collections.Array<StringName> GroupExceptions;
	private void ApplyForceTo(PhysicsBody Body)
	{
		float ForceMagnitude = Magnitude;
		float ForceDirection = Direction;
		if (IsAttractive)
		{
			ForceDirection += Body.GlobalPosition.AngleToPoint(GlobalPosition);
		}
		ForceDirection += GlobalRotation;
		Body.ApplyForce(Vector2.FromAngle(ForceDirection) * ForceMagnitude * ForceScale,Acceleration);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Godot.Collections.Array<Area2D> CollidingDetectors = GetOverlappingAreas();
		foreach (ForceFieldDetector CurrentDetector in CollidingDetectors)
		{	
			PhysicsBody CurrentBody = CurrentDetector.MyPhysicsBody;
			if ((!NodeExceptions.Contains(CurrentBody)) && (!NodeUtilities.IsNodeInGroupArray(CurrentBody,GroupExceptions)))
				ApplyForceTo(CurrentDetector.MyPhysicsBody);
		}
	}
}

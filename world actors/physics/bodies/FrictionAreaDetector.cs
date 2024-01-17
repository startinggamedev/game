using Godot;
using System;
using System.Collections.Generic;

public partial class FrictionAreaDetector : Area2D
{
	public List<float> DetectFriction()
	{
		var DetectedFriction = new List<float>
		{
			PhysicsConsts.Airfriction
		};

		Godot.Collections.Array<Area2D> CollidingFrictionAreas = GetOverlappingAreas();
	
		if (CollidingFrictionAreas.Count > 0){ DetectedFriction.Clear();}

		foreach (var CurrentArea in CollidingFrictionAreas)
		{	
			var CurrentFrictionArea = (FrictionArea)CurrentArea;
			DetectedFriction.Add(CurrentFrictionArea.Friction);
		}
		return DetectedFriction;
	}
}

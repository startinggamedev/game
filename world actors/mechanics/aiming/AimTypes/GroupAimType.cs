using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
[GlobalClass]
public abstract partial class GroupAimType : AimType
{
	[Export]
	float SearchRange = float.PositiveInfinity;
	protected StringName TargetGroup;
	public override float AimFunction(double delta, Node2D MyNode2D)
	{
		List<Node2D> TargetNodes = NodeUtilities.GetGroupNodesByDistance(MyNode2D.GlobalPosition,TargetGroup,SearchRange);
		if(TargetNodes.Count <= 0){return float.NaN;}
		return MyNode2D.GlobalPosition.AngleToPoint(TargetNodes[0].GlobalPosition);
	}
}

using Godot;
using System;
using System.Runtime.InteropServices;
[GlobalClass]
public partial class GroupAimType : AimType
{
	[Export]
	StringName TargetGroup;
	public override float AimFunction(double delta, Node2D MyNode2D)
	{
		Node2D TargetNode = NodeUtilities.GetNearestNodeInGroup(MyNode2D.GlobalPosition,TargetGroup);
		if(TargetNode is null){return float.NaN;}
		return MyNode2D.GlobalPosition.AngleToPoint(TargetNode.GlobalPosition);
	}
}

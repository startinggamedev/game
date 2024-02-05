using Godot;
using System;
using System.Collections.Generic;
[GlobalClass]
public partial class CharacterGroupAimType : AimType
{
	[Export]
	float SearchRange = float.PositiveInfinity;
	public override float AimFunction(double delta, Node2D MyNode2D)
	{
		Character MyCharacter = null;
		if (MyNode2D is Character){MyCharacter = (Character)MyNode2D;}
		else if(MyNode2D is IUsesCharacter){MyCharacter = ((IUsesCharacter)MyNode2D).MyCharacter;}
		if (MyCharacter is null){GD.PushError("character group aim type should belong to scene with character!");}
		StringName TargetGroup = Gl.GetGroupTofollow(MyCharacter.GetMyType());
		List<Node2D> TargetNodes = MyCharacter.GetVisibleNodesByDistance(TargetGroup,SearchRange);
		if(TargetNodes.Count <= 0){return float.NaN;}
		return MyNode2D.GlobalPosition.AngleToPoint(TargetNodes[0].GlobalPosition);
	}
}

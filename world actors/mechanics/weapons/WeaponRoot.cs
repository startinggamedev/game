using Godot;
using System;
public partial class WeaponRoot : Node2D,IUsesType
{
	[Export]
	public Character MyCharacter;

	public void SetUpType(int Type){}

	public int GetMyType()
	{
		if (MyCharacter is not null)
		{
			return MyCharacter.GetMyType();
		}
		else
		{
			return (int)Gl.Types.All;
		}
	}
}

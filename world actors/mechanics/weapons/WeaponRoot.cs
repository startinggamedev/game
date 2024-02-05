using Godot;
using System;
public partial class WeaponRoot : Node2D,IUsesCharacter,IUsesType
{
	
	public Character MyCharacter{get;set;}
	[Export]
	public CharacterGetter MyCharacterGetter {get; set;} = new CharacterGetter();

	public override void _Ready()
	{
		MyCharacterGetter.GetCharacter(this);
		base._Ready();
	}
	public void SetUpType(int Type){}

	public int GetMyType()
	{
		if (MyCharacter is not null)
		{
			return MyCharacter.GetMyType() + 3;
		}
		else
		{
			return (int)Gl.Types.All;
		}
	}
}

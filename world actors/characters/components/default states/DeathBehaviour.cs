using Godot;
using System;
[GlobalClass]
public partial class DeathBehaviour : CharacterState
{
	protected void ToggleAliveFeatures(bool IsAlive)
	{
		MyCharacter.SetCollidability(IsAlive);
		MyCharacter.MyDamagedetector.ToggleDamagibiliy(IsAlive);        

	}
	protected override void ProtectedEnter()
	{
		MyCharacter = GetOwner<Character>();
		ToggleAliveFeatures(false);
		base.ProtectedEnter();
	}
	protected override void ProtectedExit()
	{
		ToggleAliveFeatures(true);
		base.ProtectedExit();
	}
}

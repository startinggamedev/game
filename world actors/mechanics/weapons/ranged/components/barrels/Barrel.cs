using Godot;
using System;
using System.Collections.Generic;

[GlobalClass]
public partial class Barrel : RayCast2D
{
	[Export]
	public bool IsActive = true;
	[Export]
	public Godot.Vector2 Impulse = Godot.Vector2.Right;
	[Export(PropertyHint.Range,"0.,3.14159,0.005")]
	public float Spread = 0f;
	[Export]
	private int Barrels = 1;
	[Export]
	private float BarrelSpacing = 0f;

	Gl Globals;
	public override void _EnterTree()
	{
		Globals = Globals = GetNode<Gl>("/root/Globals");
	}

	public void ShootProjectile(PackedScene ProjectileScene)
	{
		int CenterBarrel = Mathf.RoundToInt(((float)Barrels * 0.5) + 0.5);
		for(int i = 1;i <= Barrels;i++)
		{
		Character Projectile = (Character)ProjectileScene.Instantiate();
		float BarrelOffset = (i - CenterBarrel) * BarrelSpacing;
		Projectile.GlobalPosition = GlobalPosition +TargetPosition.Rotated(GlobalRotation + BarrelOffset);
		Projectile.ApplyImpulse(Impulse.Rotated(GlobalRotation + BarrelOffset +(float)GD.RandRange(-Spread,Spread)));
		NodeUtilities.AddChildTo(new List<Node>(){Globals.CharacterHolder,GetParent(),this},Projectile);
		} 
	}
}

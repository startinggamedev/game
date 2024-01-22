using Godot;
using System;
using System.Collections.Generic;
public partial class RangedWeaponManager : WeaponManager
{
	[Export]
	public int ammo{get;private set;} = 1;
	[Export]
	Godot.Collections.Array<Barrel> MyBarrels;
	[Export]
	PackedScene Projectile;

	public bool HasaAmmo()
	{
		return ammo > 0;
	}
	public override void Attack(float Recoil)
	{
	   ammo -= 1;
	   foreach (var CurrentBarrel in MyBarrels){
		if (CurrentBarrel.IsActive)
		{
			CurrentBarrel.ShootProjectile(Projectile);
		}
	   }
	   base.Attack(Recoil);
	}
}

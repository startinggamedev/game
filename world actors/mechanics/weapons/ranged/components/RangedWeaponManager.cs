using Godot;
using System;
using System.Collections.Generic;
public partial class RangedWeaponManager : WeaponManager
{
	[Export]
	int _Ammo;
	[Export]
	public int MaxAmmo {get;private set;} = -1;
	[Export]
	Godot.Collections.Array<Barrel> MyBarrels;
	[Export]
	PackedScene Projectile;

	
	public int Ammo
	{
		set
		{
			if(MaxAmmo == -1){MaxAmmo = _Ammo;}
			_Ammo = Math.Clamp(value,0,MaxAmmo);
		}
		get
		{
			return _Ammo;
		}
	}
	public bool HasAmmo()
	{
		return Ammo > 0;
	}
	public int RechargeAmmo(float RechargeRate = 1f)
	{
		Ammo = (int)Math.Round(MaxAmmo * RechargeRate);
		return Ammo;
	}
	public override void Attack(float Recoil)
	{
		Ammo -= 1;
		foreach (var CurrentBarrel in MyBarrels){
		if (CurrentBarrel.IsActive)
		{
			CurrentBarrel.ShootProjectile(Projectile);
		}
	   }
	   base.Attack(Recoil);
	}
}

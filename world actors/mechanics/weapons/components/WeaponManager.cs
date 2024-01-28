using Godot;
using System;
using System.Text.RegularExpressions;
public partial class WeaponManager : StateMachine
{
	[Export]
	public Trigger MyTrigger = new AutomaticTrigger();
	[Export]
	Godot.Collections.Array<Barrel> MyBarrels;
	protected WeaponRoot MyWeaponRoot;
	public override void _Ready()
	{
		MyWeaponRoot = GetOwner<WeaponRoot>();
		base._Ready();
	}
	public virtual void Attack(float Recoil)
	{
		MyWeaponRoot.MyCharacter?.ApplyImpulse(Recoil * Godot.Vector2.FromAngle(MyWeaponRoot.GlobalRotation));
	}

	public override void _Process(double delta)
	{
		MyTrigger.UpdateTriggerState(delta);
		base._Process(delta);
	}
}

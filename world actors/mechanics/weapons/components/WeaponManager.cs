using Godot;
using System;
using System.Text.RegularExpressions;
public abstract partial class WeaponManager : StateMachine
{
	[Export]
	public Trigger MyTrigger = new AutomaticTrigger();
	[Export]
	protected WeaponRoot MyWeaponRoot;
	[Export]
	Godot.Collections.Array<Barrel> MyBarrels;
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

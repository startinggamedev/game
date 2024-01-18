using Godot;
using System;

public partial class HealthManager : Node
{
	[Export]
	public float Hp {get; private set;} = 1f;
	[Export]
	public float MaxHp {get; private set;} = -1f;
	[Export]
	public float Defense {get; private set;}
	[Export]
	private float IframeLengthSec;
	[Export]
	private Area2D DamageDetector;
	
	public enum HealthStates{Vulnerable,Iframe,Invincible}

	private int CurrentHealthState = (int)HealthStates.Vulnerable;
	public float TakeDamage(DamageRes MyDamageRes){
		if (CurrentHealthState == (int)HealthStates.Iframe && !MyDamageRes.RespectIframe)
		{
			return 0f;
		}
		if (CurrentHealthState == (int) HealthStates.Invincible)
		{
			return 0f;
		}
		float DamageToTake = MyDamageRes.Damage;
		if (MyDamageRes.RespectDefense)
		{
			DamageToTake -= Defense;
			DamageToTake = Math.Max(0f,DamageToTake);
		}
		Hp -= DamageToTake;
		return DamageToTake
	}

	public override void _Ready()
	{
		if (MaxHp < 0f){
			MaxHp = Hp;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

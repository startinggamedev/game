using Godot;
using System;

public partial class HealthManager : Node
{
	#region exports

	// health variables

	[Export]
	public float Hp {get; private set;} = 1f;
	[Export]
	public float MaxHp {get; private set;} = -1f;
	[Export]
	public float Defense {get; private set;}
	[Export]
	private float IframeLengthSec;
	[Export]
	public Godot.Collections.Array<ExtraDamage> MyExtraDamage;
	[Export]
	private DamageDetector MyDamageDetector;

	//exported nodes

	[Export]
	Character MyCharacter;
	#endregion
	#region variables
	
	public enum HealthStates{Vulnerable,Iframe,Invincible}

	private int CurrentHealthState = (int)HealthStates.Vulnerable;
	private double IframeTimer = 0f;

	#endregion

	#region methods
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
		return DamageToTake;
	}

	public void TakeExtraDamage(){
		foreach (var CurrentExtraDamage in MyExtraDamage)
		{
			TakeDamage(CurrentExtraDamage.DamageFunction(MyCharacter));
		}
	}

	public void UpdateVitalityStatus()
	{
		VitalityStatus(Hp > 0f);
	}
	#endregion
	
	#region events
	public Action<bool> VitalityStatus;
	#endregion

	#region processes
	public override void _Ready()
		{
			if (MaxHp < 0f){
				MaxHp = Hp;
			}
		}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (CurrentHealthState == (int)HealthStates.Vulnerable && MyDamageDetector != null)
		{
			foreach (DamageDetector Currentdamager in MyDamageDetector.GetDamagers())
			{
				TakeDamage(Currentdamager.MyDamageRes);
			}
		}
		if (CurrentHealthState == (int)HealthStates.Iframe)
		{
			IframeTimer -= delta;
			if(IframeTimer <= 0f){CurrentHealthState = (int)HealthStates.Vulnerable;}
		}
		else{IframeTimer = IframeLengthSec;}
		TakeExtraDamage();
		UpdateVitalityStatus();
	}
	#endregion
}

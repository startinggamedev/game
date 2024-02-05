using Godot;
using System;

[GlobalClass]
public partial class HealthManager : Node,IUsesCharacter
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
	private Godot.Collections.Array<ExtraDamage> MyExtraDamage = new Godot.Collections.Array<ExtraDamage>();
	[Export]
	private DamageDetector MyDamageDetector;
	[Export]
	public CharacterGetter MyCharacterGetter {get; set;} = new CharacterGetter();
	public Character MyCharacter{get;set;}

	#endregion
	#region variables
	
	public enum HealthStates{Vulnerable,Iframe,Invincible}

	private int CurrentHealthState = (int)HealthStates.Vulnerable;
	private double IframeTimer = 0f;

	#endregion

	#region methods
	public void AddExtraDamage(ExtraDamage AdditionalExtraDamage)
	{
		MyExtraDamage.Add(AdditionalExtraDamage);
	}
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
		if(VitalityStatus is not null){VitalityStatus(Hp > 0f);}
	}
	#endregion
	
	#region events
	public Action<bool> VitalityStatus;
	#endregion
	public bool IsAlive()
	{
		return Hp > 0f;
	}
	#region processes
	public override void _Ready()
		{
			MyCharacterGetter.GetCharacter(this);
			if (MaxHp < 0f){
				MaxHp = Hp;
			}
		}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (CurrentHealthState == (int)HealthStates.Vulnerable && MyDamageDetector != null)
		{
			var MyDamagers = MyDamageDetector.GetDamagers();
			int DamageThisFrame = 0;
			foreach (DamageDetector Currentdamager in MyDamagers)
			{
				DamageThisFrame += 1;
				foreach (var BumpType in Currentdamager.DamageBumpTypes)
				{
					if(BumpType is null)
					{
						GD.PushError("damager BumpType is null");
					}
					MyCharacter.ApplyImpulse(BumpType.BumpFunction(delta,Currentdamager.MyCharacter,MyCharacter));
				}
				if(Currentdamager.DealtDamage is not null){Currentdamager.DealtDamage(TakeDamage(Currentdamager.MyDamageRes));}
			}
			if(DamageThisFrame > 0){GD.Print(GetParent().Name);GD.Print(DamageThisFrame);}
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

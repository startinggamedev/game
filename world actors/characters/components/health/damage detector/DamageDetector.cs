using Godot;
using System;
[GlobalClass]
public partial class DamageDetector : Area2D,IUsesType,IUsesCharacter
{
	[Export]
	HealthManager MyHealthManager;
	[Export]
	public Godot.Collections.Array<DamageBumpType> DamageBumpTypes;
	[Export]
	public DamageRes MyDamageRes;
	public Character MyCharacter{get;set;}
	[Export]
	public CharacterGetter MyCharacterGetter {get; set;} = new CharacterGetter();
	
	public bool CanDamage = true;

	public DamageType MyDamageType{get; private set;}

	public Action<float> DealtDamage;

	public void ToggleDamagibiliy(bool can_damage)
	{
		CanDamage = can_damage;
	}

	public void SetUpType(int MyType)
	{
		MyDamageType = Gl.DamageTypes[MyType];
	}
	public int GetMyType()
	{
		int MyType = (int)Gl.Types.All;
		if (MyCharacter is not null){MyType = MyCharacter.GetMyType();}
		return MyType;
	}

	public override void _Ready()
	{
		MyCharacterGetter.GetCharacter(this);
		SetUpType(GetMyType());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public Godot.Collections.Array<DamageDetector> GetDamagers(){
		Godot.Collections.Array<DamageDetector> Damagers = new Godot.Collections.Array<DamageDetector>(){};
		var  CollidingAreas = GetOverlappingAreas();
		foreach (DamageDetector CurrentDamageDetector in CollidingAreas)
		{
			if (DamageType.CanDamage(MyDamageType,CurrentDamageDetector.MyDamageType) && CurrentDamageDetector.CanDamage)
			{
				Damagers.Add(CurrentDamageDetector);
			}
		}
		return Damagers;
	}
	public Character GetCharacter(){
		return MyCharacter;
	}
}

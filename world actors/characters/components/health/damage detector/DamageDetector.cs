using Godot;
using System;
public partial class DamageDetector : Area2D,IUsesType
{
	[Export]
	HealthManager MyHealthManager;

	[Export]
	public Character MyCharacter;
	[Export]
	public Godot.Collections.Array<DamageBumpType> DamageBumpTypes;
	[Export]
	public DamageRes MyDamageRes;

	public DamageType MyDamageType{get; private set;}

	private void ToggleMonitorability(bool IsMonitorable)
	{
		Monitorable = IsMonitorable;
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
		SetUpType(GetMyType());
		if (MyHealthManager is not null){ MyHealthManager.VitalityStatus += ToggleMonitorability;}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public Godot.Collections.Array<DamageDetector> GetDamagers(){
		Godot.Collections.Array<DamageDetector> Damagers = new Godot.Collections.Array<DamageDetector>(){};
		var  CollidingAreas = GetOverlappingAreas();
		foreach (DamageDetector CurrentDamageDetector in CollidingAreas)
		{
			if (DamageType.CanDamage(MyDamageType,CurrentDamageDetector.MyDamageType))
			{
				Damagers.Add(CurrentDamageDetector);
			}
		}
		return Damagers;
	}
}

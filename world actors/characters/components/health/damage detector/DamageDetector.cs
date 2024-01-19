using Godot;
using System;

public partial class DamageDetector : Area2D
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

	public override void _Ready()
	{
		if (MyCharacter is not null){MyDamageType = Gl.DamageTypes[(int)MyCharacter.Type];}
		if (MyHealthManager is not null){ MyHealthManager.VitalityStatus += ToggleMonitorability;}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public Godot.Collections.Array<DamageDetector> GetDamagers(){
		Godot.Collections.Array<DamageDetector> Damagers = new Godot.Collections.Array<DamageDetector>(){};
		foreach (DamageDetector CurrentDamageDetector in GetDamagers())
		{
			if (DamageType.CanDamage(MyDamageType,CurrentDamageDetector.MyDamageType))
			{
				Damagers.Add(CurrentDamageDetector);
			}
		}
		return Damagers;
	}
}

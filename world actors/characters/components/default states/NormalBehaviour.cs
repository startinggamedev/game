using Godot;
using System;
public partial class NormalBehaviour : State
{
	[Export]
	HealthManager MyHealthManager;
	[Export]
	State DeadState;
	protected override void ProtectedProcess(double delta)
	{
		if(MyHealthManager is null){GD.PushError("export normal behaviour health manager properly.");return;}
		if (!MyHealthManager.IsAlive())
		{
			NextState = DeadState;
		}
		base.ProtectedProcess(delta);
	}
}

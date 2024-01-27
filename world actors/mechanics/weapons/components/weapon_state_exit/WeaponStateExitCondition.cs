using Godot;
using System;
[GlobalClass]
public partial class WeaponStateExitCondition : Resource
{
	[Export]
	private NodePath NextState;
	[Export(PropertyHint.Range,"0.,1.,0.00001")]
	public float Start = -1f;
	[Export(PropertyHint.Range,"0.,1.,0.00001")]
	public float End = -1f;

	public WeaponState MyState;
	protected State GetNextState()
	{
		var NextStateInstance = MyState.GetNode(NextState);
		if (NextStateInstance is not State)
			{
				GD.PushError("weapon exit conditions 'next state' variable doesnt refer to the nodepath of a state");
				return null;
			}
		return (State)NextStateInstance;
	}
	public virtual State ExitCondition(WeaponManager MyWeaponManager)
	{
		return GetNextState();
	}
}

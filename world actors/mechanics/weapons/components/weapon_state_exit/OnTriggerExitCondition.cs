using Godot;
using System;
[GlobalClass]
public partial class OnTriggerExitCondition : WeaponStateExitCondition
{
    [Export]
    Godot.Collections.Array<Gl.TriggerStates> ExitTriggers;
    public override State ExitCondition(WeaponManager MyWeaponManager)
    {
        if(ExitTriggers.Contains((Gl.TriggerStates)MyWeaponManager.MyTrigger.CurrentTriggerState))
        {
            return NextState;
        }
        else
        {
            return null;
        }
    }

}
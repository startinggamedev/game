using Godot;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
[GlobalClass]
public partial class InputActionTrigger : Trigger
{
    [Export]
    StringName TriggerInputAction;
    public override void UpdateTriggerState(double delta)
    {
        if(Input.IsActionJustPressed(TriggerInputAction))
        {
            CurrentTriggerState = (int)Gl.TriggerStates.PRESSED;
        }
        else if(Input.IsActionPressed(TriggerInputAction))
        {
            CurrentTriggerState = (int)Gl.TriggerStates.HELD;
        }
        else
        {
            CurrentTriggerState = (int)Gl.TriggerStates.RELEASED;
        }
    }
}
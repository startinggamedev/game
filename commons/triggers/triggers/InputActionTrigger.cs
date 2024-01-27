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
       SetTrigger(Input.IsActionPressed(TriggerInputAction),delta);
    }
}
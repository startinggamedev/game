using Godot;
using System;
using System.ComponentModel;
[GlobalClass]
public partial class AutomaticTrigger : Trigger
{
    [Export]
    float TriggerSpacingSec = 0f;
    [Export]
    float TriggerLengthSec = 0f;
    
    private float TriggerSpacingTimer = 0f;
    private float TriggerLengthTimer = 0f;
    public override void UpdateTriggerState(double delta)
    {
        if (TriggerSpacingTimer <= 0f) 
        {
            SetTrigger(true,delta);
            if (TriggerLengthTimer >= 0)
            {
            TriggerLengthTimer -= (float)delta;
            }
            else
            {
                TriggerLengthTimer = TriggerLengthSec;
                TriggerSpacingTimer = TriggerSpacingSec;
            }

        }
        else
        {
            SetTrigger(false,delta);
            TriggerSpacingTimer -= (float)delta;
        }
    }

}
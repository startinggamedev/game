using Godot;
using System;
using System.ComponentModel;
[GlobalClass]
public partial class  Trigger : Resource
{
    [Export]
    public bool CanBeTriggered = true;
    public double TimeTriggered {get; private set;}
    public bool IsTriggered()
    {
        return TimeTriggered >= 0;
    }
    protected void SetTrigger(bool ToTrigger,double delta)
    {
    if (ToTrigger && CanBeTriggered)
    {
        TimeTriggered = Math.Max(TimeTriggered,0f);
        TimeTriggered += delta;
    }
    else
    {
        TimeTriggered = Math.Min(TimeTriggered,0f);
        TimeTriggered -= delta;    
    }
    }
    public virtual void UpdateTriggerState(double delta)
    {

    }
}
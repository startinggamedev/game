using Godot;
using System;
[GlobalClass]
public partial class  Trigger : Resource
{
    public double TimeTriggered {get; private set;}
    protected void SetTrigger(bool ToTrigger,double delta)
    {
    if (ToTrigger)
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
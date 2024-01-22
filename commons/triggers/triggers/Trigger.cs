using Godot;
using System;
[GlobalClass]
public partial class  Trigger : Resource
{
    public int CurrentTriggerState {get; protected set;} = (int)Gl.TriggerStates.RELEASED; 
    public virtual void UpdateTriggerState(double delta)
    {

    }
}
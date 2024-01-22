using Godot;
using System;

public abstract partial class StateMachineComponent : Resource
{
    public StateMachine MyStateMachine{get;set;}
    protected T GetNode<T>(NodePath Path) where T : Node
    {
        return MyStateMachine.GetNode<T>(Path);
    }

}
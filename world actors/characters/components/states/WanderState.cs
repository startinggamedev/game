using Godot;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
[GlobalClass]
public partial class WanderState  : CharacterState
{
    [Export]
    AimType MyAimType;
    [Export]
    protected Node2D MyAimObject{get;private set;}
    [Export]
    float MinDistance;
    [Export]
    float MaxDistance = float.PositiveInfinity;
    [Export]
    State MinDistanceNextState;
    [Export]
    State MaxDistanceNextState;
    protected virtual void SetupAimObejct(IAimObject AimObjectInstance)
    {
        AimObjectInstance.MyAimType = MyAimType;
    }
    protected override void ProtectedEnter()
    {
        SetupAimObejct((IAimObject)MyAimObject);
        base.ProtectedEnter();
    }
    protected override void ProtectedProcess(double delta)
    {
        base.ProtectedProcess(delta);
        var MyCharacter= GetOwner<Character>();
        Debug.Assert(MyCharacter is not null,"waander state should have a character");
        var VisibleNodes = MyCharacter.GetVisibleNodesByDistance(Gl.GetGroupTofollow(MyCharacter.GetMyType()),MaxDistance);
        if(VisibleNodes.Count <= 0 || VisibleNodes is null)
        {
            if(MaxDistanceNextState is not null)
            {
                NextState = MaxDistanceNextState;
            } 
        }
        else if(VisibleNodes[0].GlobalPosition.DistanceTo(MyCharacter.GlobalPosition) < MinDistance)
        {
            if(MinDistanceNextState is not null)
            {
                NextState = MinDistanceNextState;
            }
        }
    }
}
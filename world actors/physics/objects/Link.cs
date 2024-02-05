using Godot;
using System;
using System.Dynamic;
using System.Linq;
[GlobalClass]
public partial class Link : Node2D
{
    [Export]
    Node2D LinkedNode;
    [Export]
    float LinkForce = 100f;
    [Export]
    bool RotateLinkedNode =false;
    [Export]
    bool AutomaticSetup = true;
    public float LinkLength = 100f;
    public float LinkAngle{get;protected set;} = 0f;
    public float VisualAngleOffset{get;protected set;} = 0f;
    Godot.Vector2 LinkEnd =Godot.Vector2.Zero;
    public override void _Ready()
    {
        base._Ready();
        if (AutomaticSetup)
        {
            LinkAngle = GlobalPosition.AngleToPoint(LinkedNode.GlobalPosition);
            LinkLength = LinkedNode.GlobalPosition.DistanceTo(GlobalPosition);
        }
    }
    public override void _PhysicsProcess(double delta)
    {

        if(LinkedNode is null){return;}
        LinkEnd = GlobalPosition + (Godot.Vector2.FromAngle(LinkAngle) * LinkLength);
        if (LinkedNode is PhysicsBody)
        {
            PhysicsBody LinkedPhysicsBody =  (PhysicsBody)LinkedNode;
            LinkedPhysicsBody.AttractToPoint(LinkEnd,LinkForce);
        } 
        else
        {
            LinkedNode.GlobalPosition = LinkedNode.GlobalPosition.MoveToward(LinkEnd,LinkLength);
        }
        if(RotateLinkedNode)
        {
            LinkedNode.Rotation = LinkAngle + VisualAngleOffset;
        }
        QueueRedraw();
        base._PhysicsProcess(delta);
    }
}
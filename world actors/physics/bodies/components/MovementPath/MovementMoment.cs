using Godot;
using System;
[GlobalClass]
public partial class MovementMoment : Resource
{

    [Export]
    private PathPointResource StartPathResource;
    [Export]
    private PathPointResource EndPathResource;
    [Export]
    public MomentPath MyPath;
    public Godot.Vector2 StartPoint
    {
        get
        {
            return StartPathResource.GetPoint();
        }
        set
        {
            
        }
    }
    public Godot.Vector2 EndPoint
    {
        get
        {
            return EndPathResource.GetPoint()- StartPoint;
        }
        set
        {

        }
    }
    public void Setup()
    {
        MyPath.Setup(EndPoint);
    }
    
}
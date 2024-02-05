using Godot;
using System;
[GlobalClass]
public partial class MovementPath : Resource
{
    [Export]
    public Godot.Collections.Array<MovementMoment> MyMoments = new Godot.Collections.Array<MovementMoment>();
    PhysicsBody MyBody;
    public void SetUp()
    {
        foreach (var CurrentMoment in MyMoments)
        {
            CurrentMoment.Setup();
        }
    }

}
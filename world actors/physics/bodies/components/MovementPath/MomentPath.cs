using Godot;
using System;
using System.Linq;
[GlobalClass]
public partial class MomentPath : Resource
{
    [Export]
    public Godot.Collections.Array<MomentPathPoint> MyPoints{get;private set;}
    [Export]
    Godot.Vector2 EndPosition;
    public void Setup(Godot.Vector2 EndPoint)
    {
        var PointDiference = EndPosition - MyPoints.First().Position;
        var StretchScale = EndPoint.Length() / PointDiference.Length();
        var Rotation = EndPoint.Angle() - PointDiference.Angle();
        var Offset = -MyPoints.First().Position;
        foreach(var Point in MyPoints)
        {
            Point.Offset(Offset);
            Point.Rotate(Rotation);
            Point.Scale(new Godot.Vector2(StretchScale,1f));
        }
        for(int i = 0;i < MyPoints.Count;i++)
        {
            Godot.Vector2 NextPoint = Godot.Vector2.Zero;
            if(i == MyPoints.Count - 1)
            {
                NextPoint = EndPoint;
            }
            else
            {
                NextPoint = MyPoints[i + 1].Position;
            }
            MyPoints[i].SetUp(NextPoint);
        }
    }

}
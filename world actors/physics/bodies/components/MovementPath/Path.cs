using Godot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Schema;
[GlobalClass]
public partial class Path : Resource
{
    [Export]
    public Godot.Collections.Array<PathConnection> MyConnections{get;private set;}
    public float Length {get;set;}
    [Export]
    protected PathPoint StartPoint;
    [Export]
    protected PathPoint EndPoint;

    public Vector2 End {get{return EndPoint.GetPoint();} set{}}
    public Vector2 Start {get{return StartPoint.GetPoint();} set{}}
    public void Setup()
    {
        var StartEndDiff = End - Start;
        var ConnectionDiff = MyConnections.Last().Position - MyConnections.First().Position;
        var Offset = Start - MyConnections.First().Position;
        float Stretch = StartEndDiff.Length() / ConnectionDiff.Length();
        var Rotation = ConnectionDiff.Angle() - StartEndDiff.Angle();
        foreach(var Connection in MyConnections)
        {
            Connection.Offset(Offset);
            Connection.Rotate(Rotation,Start);
            Connection.ScalePosition(new Godot.Vector2(Stretch,1f),Start);
        }
        for(int i = 0;i < MyConnections.Count;i++)
        {
            Godot.Vector2 NextPoint = Godot.Vector2.Zero;
            if(i == MyConnections.Count - 1)
            {
                NextPoint = End;
            }
            else
            {
                NextPoint = MyConnections[i + 1].Position;
            }
            MyConnections[i].SetUp(NextPoint);
        }
    }
    public float GetConnectionStart(int ConnectionIndex)
    {
        float Start = 0f;
        for(int i = 0;i < ConnectionIndex;i++)
        {
            Start += MyConnections[i].Length;
        }
        return Start;
        }
    public float GetNearestSegmentTo(Godot.Vector2 Position)
    {
        float NearestDistance = float.PositiveInfinity;
        var NearestSegment = 0f;
        int NearestIndex = 0;
        for(int i = 0;i < MyConnections.Count;i++)
        {
            var Connection = MyConnections[i];
            float CurrentSegment = Connection.GetNearestSegmentTo(Position);
            float CurrentDistance = Connection.GetSegmentPosition(CurrentSegment).DistanceTo(Position); 
            if(CurrentDistance < NearestDistance)
            {
                NearestIndex = i;
                NearestDistance = CurrentDistance;
                NearestSegment = CurrentSegment;
            }
        }
        return NearestSegment + GetConnectionStart(NearestIndex);
    }
    public Vector2 GetSegmentPosition(float Segment)
    {
        float PreviousSegment = 0f;
        float CurrentSegment = 0f;
        float LocalSegment = 0f;
        for(int i = 0; i < MyConnections.Count;i++)
        {
            PreviousSegment = CurrentSegment;
            CurrentSegment += MyConnections[i].Length;
            LocalSegment = Segment - PreviousSegment;
            if(Segment >= PreviousSegment&& Segment < CurrentSegment)
            {
                return MyConnections[i].GetSegmentPosition(LocalSegment);
            }
        }
        return MyConnections.Last().GetSegmentPosition(MyConnections.Last().Length);
    }
}
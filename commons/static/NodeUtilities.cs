using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;
public partial class NodeUtilities : GodotObject{
    public static bool IsNodeInGroupArray(Node Node,Godot.Collections.Array<StringName> GroupArray)
    {
        Godot.Collections.Array<StringName> NodeGroups = Node.GetGroups();
        for(int i = NodeGroups.Count - 1;i >= 0;i--){
            if (GroupArray.Contains(NodeGroups[i])){
                return true;
            }
        }
        return false;
    }

    public static List<Node2D> GetGroupNodesByDistance(Godot.Vector2 ComparisionPosition,StringName Group,float SearchRange = float.PositiveInfinity)
    {
        SceneTree MySceneTree = (SceneTree)Engine.GetMainLoop();
        Godot.Collections.Array<Node> GroupNodes = MySceneTree.GetNodesInGroup(Group);
        Godot.Collections.Array<float> Distances = new Godot.Collections.Array<float>();
        List<Node2D> NodesByDistance = new List<Node2D>();
        GD.Print("a");
        foreach(Node2D CurrentNode in GroupNodes)
        {
            if(CurrentNode.GlobalPosition.DistanceTo(ComparisionPosition) <= SearchRange)
            {
                NodesByDistance.Add(CurrentNode);
                Distances.Add(CurrentNode.GlobalPosition.DistanceTo(ComparisionPosition));
            }        
        }
        var DistanceArray = Distances.ToArray();
        var NodeArray = NodesByDistance.ToArray();
        Array.Sort(DistanceArray,NodeArray);
        NodesByDistance = NodeArray.ToList();
        return NodesByDistance;
    }

    public static Godot.Collections.Array<T> GetChildren<[MustBeVariant]T>(Node Parent) where T : Node
    {
        var Children = Parent.GetChildren();
        Godot.Collections.Array<T> Output = new Godot.Collections.Array<T>();
        foreach(T CurrentChild in Children)
        {
            Output.Add(CurrentChild);
        }
        return Output;
    }
    public static Node AddChildTo(Godot.Collections.Array<Node> PossibleParents,Node Child)
    {
        var ChildGlobalPosition = Godot.Vector2.Zero;
        if (Child is Node2D)
        {
            ChildGlobalPosition = ((Node2D)Child).GlobalPosition;    
        }
        foreach (var CurrentParent in PossibleParents)
        {
            if (IsInstanceValid(CurrentParent)){
                CurrentParent.AddChild(Child);
            if (Child is Node2D)
            {
                ((Node2D)Child).GlobalPosition = ChildGlobalPosition; 
            }
                return CurrentParent;
            }
        }
        return null;
    }
    public static Node AddChildTo(List<Node> PossibleParents,Node Child)
    {
        return AddChildTo(new Godot.Collections.Array<Node>(PossibleParents),Child);
    }
    public static Godot.Collections.Dictionary CastRay(CanvasItem MyCanvasItem,Godot.Vector2 From,Godot.Vector2 To,Godot.Collections.Array<Rid> Exceptions,uint CollisionMask)
    {
        var spaceState = MyCanvasItem.GetWorld2D().DirectSpaceState;
        var query = PhysicsRayQueryParameters2D.Create(From,To,
        CollisionMask,Exceptions);
        var result = spaceState.IntersectRay(query);
        return result;
    }
    public static double GetAnimationProgress(AnimationPlayer animation_player)
    {
		return animation_player.CurrentAnimationPosition / animation_player.CurrentAnimationLength;
    }

}
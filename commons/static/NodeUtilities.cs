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

    public static Node2D GetNearestNodeInGroup(Godot.Vector2 ComparisionPosition,StringName Group)
    {
        SceneTree MySceneTree = (SceneTree)Engine.GetMainLoop();
        Godot.Collections.Array<Node> GroupNodes = MySceneTree.GetNodesInGroup(Group);
        if (GroupNodes.Count() == 0){
            return null;
        }
        Node2D NearestNode = new Node2D();
        float NearestDistance = float.PositiveInfinity;
        for (int i = GroupNodes.Count - 1;i >= 0;i--)
        {
            if (GroupNodes[i] is Node2D){
                Node2D CurrentNode = (Node2D)GroupNodes[i];
                float CurrentDistance = CurrentNode.GlobalPosition.DistanceTo(ComparisionPosition);
                if (CurrentDistance < NearestDistance)
                {
                    NearestDistance = CurrentDistance;
                    NearestNode = CurrentNode;
                }
            }
        }
        return NearestNode;
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

}
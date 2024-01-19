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
    public static Node AddChildTo(Godot.Collections.Array<Node> PossibleParents,Node Child)
    {
        for(int i = PossibleParents.Count -1;i >= 0;i--){
            Node CurrentParent = PossibleParents[i];
            if (IsInstanceValid(CurrentParent)){
                CurrentParent.AddChild(Child);
                return CurrentParent;
            }
        }
        return null;
    }

}
using Godot;
using System;
[GlobalClass]
public abstract partial class PathPoint : Resource
{
    public abstract Godot.Vector2 GetPoint();
}
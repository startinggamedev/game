using Godot;
using System;
[GlobalClass]
public abstract partial class PathPointResource : Resource
{
    public abstract Godot.Vector2 GetPoint();
}
using Godot;
using System;

[GlobalClass]
public abstract partial class AimType : Resource
{
    public abstract float AimFunction(double delta,Node2D MyNode2D);
}
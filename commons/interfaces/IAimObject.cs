using Godot;
using System;
using System.Dynamic;
public interface IAimObject
{
    public AimResource MyAimResource{get;protected set;}
    public AimType MyAimType{get;set;}
}
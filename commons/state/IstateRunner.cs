using Godot;
using System;

public interface IStateRunner
{
    public void Process(double delta);
    public void Physics(double delta);
}
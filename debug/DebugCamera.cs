using Godot;
using System;
public partial class DebugCamera : Camera2D
{
    [Export]
    bool Active = false;
    public override void _PhysicsProcess(double delta)
    {
        if(Input.IsActionJustPressed("EnterDebugCamera"))
        {
            Active = !Active;
        }
        if(Active)
        {
            var ZoomToAdd = Input.GetAxis("Scrolldown","ScrollUp");
            Zoom *= ZoomToAdd * (float)delta;
            Position += Input.GetVector("Left","Right","Up","Down") * (float)delta * 200f;
        }
    }
}
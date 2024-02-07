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
            float ZoomToAdd = 0f;
            if(Input.IsActionJustReleased("ScrollUp"))
            {
                ZoomToAdd = 1.1f;
            }
            else if(Input.IsActionJustReleased("ScrollDown"))
            {
                ZoomToAdd = 0.9f;
            }
            if(ZoomToAdd != 0f){Zoom *= ZoomToAdd;}
            GD.Print(ZoomToAdd);
            Position += Input.GetVector("Left","Right","Up","Down") * (float)delta * 2000f;
        }
    }
}
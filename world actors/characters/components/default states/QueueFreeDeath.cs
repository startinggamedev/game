using Godot;
using System;
[GlobalClass]
public partial class QueueFreeDeath : DeathBehaviour
{
    protected override void ProtectedEnter()
    {
        base.ProtectedEnter();
        MyCharacter.QueueFree();
    }
}
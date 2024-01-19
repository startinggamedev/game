using Godot;
using System;
public partial class RoomTemplate : Node2D
{
	[Export]
	SubViewport CharacterViewPort;
	Gl Globals;
	public override void _Ready()
	{
		Globals = GetNode<Gl>("/root/Globals");
		Globals.CharacterHolder = CharacterViewPort;
	}

}

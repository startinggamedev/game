using Godot;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;

public partial class Chain : Node2D
{
	[Export]
	private Texture2D ChainTexture;
	[Export]
	private Node2D ChainEnd;
	private TextureRect ChainRect;
	// Called when the node enters the scene tree for the first time.
	private Godot.Vector2 GetEndPoint(Godot.Vector2 EndPoint){
	return EndPoint;
	}
	private Godot.Vector2 GetEndPoint(Node2D EndPointNode){
		return EndPointNode.GlobalPosition;
	}

	public override void _Ready()
	{
		ChainRect = GetNode<TextureRect>("ChainRect");
		ChainRect.Texture = ChainTexture;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		GlobalRotation = 0f;
		Godot.Vector2 PosDifference =ChainEnd.GlobalPosition - GlobalPosition;
		ChainRect.Rotation = PosDifference.Angle();
		ChainRect.Size = new Godot.Vector2(PosDifference.Length(),ChainRect.Size.Y);
	}
}

using Godot;
using System;
using System.Collections.Generic;


public partial class DuplicateCollisionObjects : Node2D

{
	
	[Export]
	CollisionPolygon2D BaseBoundBox;
	[Export]
	Godot.Collections.Array<CollisionObject2D> DerivatedCollisionObjects;
 
	private List<CollisionPolygon2D> DuplicatedBaseBoxes = new List<CollisionPolygon2D>();
	private bool SetUpBoundingBoxes = true;
	public void DuplicateBoundingBox()
	{
		foreach (var item in DuplicatedBaseBoxes)
		{
			item.QueueFree();
		}
		for (int i = DerivatedCollisionObjects.Count - 1;i >= 0;i--){
			CollisionPolygon2D DuplicatedBox =  (CollisionPolygon2D)BaseBoundBox.Duplicate();
			DuplicatedBaseBoxes.Add(DuplicatedBox);
			DerivatedCollisionObjects[i].AddChild(BaseBoundBox.Duplicate());
		}
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (SetUpBoundingBoxes){
			DuplicateBoundingBox();
			SetUpBoundingBoxes = false;
		}
	}
}

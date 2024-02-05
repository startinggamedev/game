using Godot;
using System;
[GlobalClass]
public partial class WanderAimType : AimType
{
    [Export]
    public float AimChangeSpacingSec = 1f;
    [Export]
    public float AimChangeSpacingRandomness = 1f;
    [Export]
    public float SpacedAimChange = Mathf.Pi;
    [Export]
    public float SpacedAimChangeRamdomness = 2f;
    [Export]
    public float RayCastCheckScale = 20f;
    [Export(PropertyHint.Range,"0.,1.,0.00001")]
    public float AimSmoothing = 0.9f;
    PhysicsBody MyPhysicsBody;
    float AimChangeTimer = 0f;
    float AimDirection = 0f;
    float TargetAimDirection = 0f;
    private void GetaSpaceAim(double delta)
    {
      AimChangeTimer -= (float)delta;
      if(AimChangeTimer <= 0)
      {

        AimChangeTimer = MyMath.RandomizeValue(AimChangeSpacingSec,AimChangeSpacingRandomness);
        TargetAimDirection += MyMath.RandomizeValue(SpacedAimChange,SpacedAimChangeRamdomness);
      }
    }
    private void GetWallDodgeAim(Node2D MyNode2D)
    {
      if(MyPhysicsBody is not null)
      {
        Godot.Collections.Dictionary RayCastResult = MyPhysicsBody.RayCollisionCheck(TargetAimDirection,RayCastCheckScale);
        if(RayCastResult.Count >0)
        {
          TargetAimDirection = ((Godot.Vector2)RayCastResult["position"]).AngleToPoint(MyPhysicsBody.GlobalPosition);
        }
      }
    }
    public override float AimFunction(double delta, Node2D MyNode2D)
    {
    MyPhysicsBody = MyNode2D.GetOwner<PhysicsBody>();
    GetaSpaceAim(delta);
    GetWallDodgeAim(MyNode2D);
    TargetAimDirection =(float)MyMath.WrapRadian(TargetAimDirection);
    AimDirection = (float)MyMath.DeltaLerpAngle(TargetAimDirection,AimDirection,AimSmoothing,delta * 30f);
    return AimDirection;
    }
}
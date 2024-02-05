using Godot;
using System;
[GlobalClass]
public partial class Pendulum : Link
{
	[Export]
	float GravityScale = 1f;
	[Export]
	float Damping = 0.1f;
	[Export]
	float Stiffness = 50f;
	[Export]
	float PendulumOffset = -MathF.PI * 0.5f;
	float AngularSpeed = MathF.PI;
	Godot.Vector2 PrevPosition = Godot.Vector2.Zero;
	public override void _Ready()
	{
		VisualAngleOffset = PendulumOffset;
		PrevPosition = GlobalPosition;
		base._Ready();
	}
	public void ApplyImpulse(Godot.Vector2 Impulse)
	{
		AngularSpeed += Godot.Vector2.FromAngle(LinkAngle).Rotated(MathF.PI * 0.5f).Dot(Impulse);
	}
	public override void _PhysicsProcess(double delta)
	{
		ApplyImpulse(PhysicsConsts.Gravity * GravityScale * (float)delta);
		ApplyImpulse((PrevPosition - GlobalPosition)*0.1f);
		AngularSpeed = (float)MyMath.DeltaLerp(AngularSpeed,0f,Damping,delta);
		LinkAngle += AngularSpeed * (float)delta / (LinkLength / 50f) / Stiffness;
		PrevPosition = GlobalPosition;
		base._PhysicsProcess(delta);

	}

}

using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;
public partial class Mymath : Node{
    static Godot.Vector2 VectorFromAngleAndMagnitude(float Angle, float Magnitude)
    {
        return Godot.Vector2.FromAngle(Angle) * Magnitude;
    }
    static float DeltaLerp(float From,float To,float Weight,double Delta){
        return Mathf.Lerp(From,To,1f - (float)Math.Pow(Weight,Delta));
    }
    static float DeltaLerpAngle(float From,float To,float Weight,double Delta){
        return Mathf.LerpAngle(From,To,1f - (float)Math.Pow(Weight,Delta));
    }
    static float AbsClamp(float Value,float Min,float Max)
    {
        return Mathf.Sign(Value) * Mathf.Clamp(Mathf.Abs(Value),Mathf.Abs(Min),Mathf.Abs(Max));
    }
    static Godot.Vector2 Mirror(Godot.Vector2 Vector,Godot.Vector2 Mirror)
    {
        return Vector.Reflect(Mirror).Rotated(MathF.PI);
    }
    static Godot.Vector2 ClampLength(Godot.Vector2 Vector,float MinLength,float MaxLength)
    {
        return Vector.Normalized() * Math.Clamp(Vector.Length(),MinLength,MaxLength);
    }
}
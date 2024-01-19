using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;
public class MyMath{
    public static Godot.Vector2 VectorFromAngleAndMagnitude(double Angle, double Magnitude)
    {
        return Godot.Vector2.FromAngle((float)Angle) * (float)Magnitude;
    }

    // lerp methods
    public static double GetdeltaLerpweight(double Weight,double Delta){
        Weight = Math.Abs(Weight - 1f);
        return 1- Math.Pow(Weight,Delta);
    }
    public static double DeltaLerp(double From,double To,double Weight,double Delta){
        return Mathf.Lerp(From,To,GetdeltaLerpweight(Weight,Delta));
    }
    public static Godot.Vector2 DeltaLerp(Godot.Vector2 From,Godot.Vector2 To,double Weight,double Delta)
    {
        return From.Lerp(To,(float)GetdeltaLerpweight(Weight,Delta));
    }
    public static double DeltaLerpAngle(double From,double To,double Weight,double Delta)
    {
        return Mathf.LerpAngle(From,To,GetdeltaLerpweight(Weight,Delta));
    }
    public static double AbsClamp(double Value,double Min,double Max)
    {
        return Mathf.Sign(Value) * Mathf.Clamp(Mathf.Abs(Value),Mathf.Abs(Min),Mathf.Abs(Max));
    }
    public static Godot.Vector2 Mirror(Godot.Vector2 Vector,Godot.Vector2 Mirror)
    {
        return Vector.Reflect(Mirror).Rotated(MathF.PI);
    }
    public static Godot.Vector2 ClampLength(Godot.Vector2 Vector,double MinLength,double MaxLength)
    {
        return Vector.Normalized() * (float)Math.Clamp(Vector.Length(),MinLength,MaxLength);
    }
}
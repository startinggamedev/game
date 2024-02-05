using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;
public class PhysicsConsts{
    public static Godot.Vector2 Gravity = new Godot.Vector2(0f,80f);
    public static float Airfriction = 0.5f;
}
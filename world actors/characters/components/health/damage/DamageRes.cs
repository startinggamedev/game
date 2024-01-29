using Godot;
using System;
using System.Dynamic;
[GlobalClass]
public partial class DamageRes : Resource
{
    [Export]
    public bool RespectIframe {get; private set;} = true ;
    [Export]
    public bool RespectDefense {get; private set;} = true ;
    [Export]
    public float Damage {get; private set;} = 0f; 

}

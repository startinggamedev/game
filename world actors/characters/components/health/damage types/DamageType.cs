using Godot;
using System;
public partial class DamageType : Resource{
[Export]
private Gl.Types Type;
[Export]
private Godot.Collections.Array<Gl.Types> Damageables;
public static bool CanDamage(DamageType This,DamageType With)
{
	return With.Damageables.Contains(This.Type);
}
}

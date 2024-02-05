using Godot;
using System;
[GlobalClass]
public partial class CharacterState : State,IUsesCharacter
{
    [Export]
    public CharacterGetter MyCharacterGetter {get;set;} = new CharacterGetter();
    public Character MyCharacter { get; set; }

    public override void _Ready()
    {
        MyCharacterGetter.GetCharacter(this);
        base._Ready();
    }
}
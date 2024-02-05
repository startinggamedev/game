using Godot;
using System;
using System.Dynamic;
public partial interface IUsesCharacter
{
    public CharacterGetter MyCharacterGetter{get;set;}
    public Character MyCharacter{get;set;}
}
using Godot;
using System;
[GlobalClass]
public partial class CharacterGetter : Resource
{
    protected Node MyNode;
    public virtual Character GetCharacter(IUsesCharacter MyCharacterUser)
    {
        Character CharacterToUse = null;
        if(MyCharacterUser is not Node){return CharacterToUse;}
        MyNode = (Node)MyCharacterUser;
        var MyNodeOwner = MyNode.GetOwner<Node>();
        if(MyNodeOwner is Character)
        {
           CharacterToUse = (Character)MyNodeOwner;
        }
        else if(MyNodeOwner is IUsesCharacter)
        {
            CharacterToUse = ((IUsesCharacter)MyNodeOwner).MyCharacterGetter.GetCharacter((IUsesCharacter)MyNodeOwner); 
        }
        if(MyCharacterUser is Character)
        {
            CharacterToUse = (Character)MyCharacterUser;
        }
        MyCharacterUser.MyCharacter = CharacterToUse;
        return CharacterToUse;
    }
}
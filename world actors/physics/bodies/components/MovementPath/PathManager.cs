using Godot;
using System;
[GlobalClass]
public partial class PathManager : Resource
{
    [Export]
    public Godot.Collections.Array<Path> MyPaths = new Godot.Collections.Array<Path>();

    public void SetUp()
    {
        foreach (var CurrentPath in MyPaths)
        {
            CurrentPath.Setup();
        }
    }
}
using System;

public class FinalSpaceRule : ISpaceRule
{
    private ISpace _space;

    public ISpace Space
    {
        get => _space;
        set => _space = value;
    }

    public string PlayRule()
    {
        EndGame();
        return $"Stay in Space {_space.SpaceIndex}{Environment.NewLine}End Position";
    }
    
    private void EndGame()
    {
        GameEvents.EndGame();
    }
}
using UnityEngine;

public class BasicSpace : ISpace
{
    protected int _spaceIndex;
    protected IBoard _board;

    public int SpaceIndex
    {
        get => _spaceIndex;
        set => _spaceIndex = value;
    }

    public IBoard Board
    {
        get => _board;
        set => _board = value;
    }

    public virtual string Play()
    {
        var log = $"Stay in Space {_spaceIndex}";
        Debug.Log(log);
        return log;
    }
}

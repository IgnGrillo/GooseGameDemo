using UnityEngine;

public class Space : ISpace
{
    private int _spaceIndex;
    private IBoard _board;
    private ISpaceRule _rule;

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

    public ISpaceRule Rule
    {
        get => _rule;
        private set => _rule = value;
    }

    public Space(ISpaceRule rule)
    {
        Rule = rule;
        rule.Space = this;
    }

    public virtual string Play()
    {
        return _rule.PlayRule();
    }
}
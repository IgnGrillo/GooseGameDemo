public class BridgeSpaceRule : ISpaceRule
{
    private ISpace _space;

    public ISpace Space
    {
        get => _space;
        set => _space = value;
    }

    public string PlayRule()
    {
        return $"The Bridge: Go to space {_space.SpaceIndex + 6}";
    }
}
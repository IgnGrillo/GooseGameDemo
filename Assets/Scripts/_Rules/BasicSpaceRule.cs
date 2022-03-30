public class BasicSpaceRule : ISpaceRule
{
    private ISpace _space;

    public ISpace Space
    {
        get => _space;
        set => _space = value;
    }

    public string PlayRule()
    {
        return $"Stay in Space {_space.SpaceIndex}";
    }
}
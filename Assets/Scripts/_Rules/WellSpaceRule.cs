public class WellSpaceRule : ISpaceRule
{
    private ISpace _space;

    public ISpace Space
    {
        get => _space;
        set => _space = value;
    }

    public string PlayRule()
    {
        return "The Well: Wait until someone comes to pull you out - they then take your place";
    }
}
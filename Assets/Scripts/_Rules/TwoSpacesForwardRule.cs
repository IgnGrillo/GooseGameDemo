public class TwoSpacesForwardRule : ISpaceRule
{
    private ISpace _space;

    public ISpace Space
    {
        get => _space;
        set => _space = value;
    }

    public string PlayRule()
    {
        return "Move two spaces forward.";
    }
}
public class PrisonSpaceRule : ISpaceRule
{
    private ISpace _space;

    public ISpace Space
    {
        get => _space;
        set => _space = value;
    }

    public string PlayRule()
    {
        return "The Prison: Wait until someone comes to release you - they then take your place";
    }
}
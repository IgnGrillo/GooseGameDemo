public class HotelSpaceRule : ISpaceRule
{
    private ISpace _space;

    public ISpace Space
    {
        get => _space;
        set => _space = value;
    }

    public string PlayRule()
    {
        return $"The Hotel: Stay for (miss) one turn";
    }
}
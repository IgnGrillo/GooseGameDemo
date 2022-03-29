using UnityEngine;

public class TwoSpacesForwardSpace : BasicSpace
{
    public override string Play()
    {
        var log = "Move two spaces forward.";
        Debug.Log(log);
        return log;
    }
}

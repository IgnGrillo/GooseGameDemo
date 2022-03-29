using UnityEngine;

public class BridgeSpace : BasicSpace
{
    public override string Play()
    {
        var log = $"The Bridge: Go to space {_spaceIndex + 6}";
        Debug.Log(log);
        return log;
    }
}

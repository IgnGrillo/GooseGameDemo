using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonSpace : ISpace
{
    public int SpaceIndex { get; set; }
    public IBoard Board { get; set; }
    public string Play()
    {
        var log = "The Prison: Wait until someone comes to release you - they then take your place";
        Debug.Log(log);
        return log;
    }
}

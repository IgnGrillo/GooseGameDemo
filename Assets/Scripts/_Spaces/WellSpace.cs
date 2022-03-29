using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellSpace : ISpace
{
    public int SpaceIndex { get; set; }
    public IBoard Board { get; set; }
    public string Play()
    {
        var log = "The Well: Wait until someone comes to pull you out - they then take your place";
        Debug.Log(log);
        return log;
    }
}

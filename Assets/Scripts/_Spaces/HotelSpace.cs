using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotelSpace : ISpace
{
    public int SpaceIndex { get; set; }
    public IBoard Board { get; set; }
    public string Play()
    {
        var log = "The Hotel: Stay for (miss) one turn";
        Debug.Log(log);
        return log;
    }
}

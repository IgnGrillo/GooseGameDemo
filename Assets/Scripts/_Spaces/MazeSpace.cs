using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpace : ISpace
{
    public int SpaceIndex { get; set; }
    public IBoard Board { get; set; }
    public string Play()
    {
        var log = "The Maze: Go back to space 39";
        Debug.Log(log);
        return log;
    }
}

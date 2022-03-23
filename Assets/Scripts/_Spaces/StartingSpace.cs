using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSpace : BasicSpace
{
    public StartingSpace(IBoard board) : base(board)
    {
        Debug.Log("Start Position");
    }
}

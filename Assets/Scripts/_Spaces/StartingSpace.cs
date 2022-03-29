using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSpace : BasicSpace
{
    public override string Play()
    {
        var message = "Start Position";
        Debug.Log(message);
        return message;
    }
}

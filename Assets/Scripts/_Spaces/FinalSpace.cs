using System;
using UnityEngine;

public class FinalSpace : BasicSpace
{
    public override string Play()
    {
        var fullMessage = GetSpaceMessage();
        LogMessage(fullMessage);
        EndGame();
        
        return fullMessage;
    }

    private string GetSpaceMessage()
    {
        var additionalLog = $"{Environment.NewLine}End Position";
        return $"{base.Play()}{additionalLog}";
    }

    private void LogMessage(string message)
    {
        Debug.Log(message);
    }

    private void EndGame()
    {
        GameEvents.EndGame();
    }
}

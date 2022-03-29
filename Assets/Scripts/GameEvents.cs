using System;

public static class GameEvents
{
    public static event Action OnGameFinish;

    public static void EndGame()
    {
        OnGameFinish?.Invoke();
    }
}

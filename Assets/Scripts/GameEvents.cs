using System;

public static class GameEvents
{
    public static event Action OnGameStart;
    public static event Action OnGameFinish;
    public static event Action<IPlayer> OnNewTurn;

    public static void StartGame()
    {
        OnGameStart?.Invoke();
    }
    
    public static void EndGame()
    {
        OnGameFinish?.Invoke();
    }

    public static void SetNewTurn(IPlayer currentPlayer)
    {
        OnNewTurn?.Invoke(currentPlayer);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

public class GooseGame : MonoBehaviour
{
    [Header("Game SetUp Fields")]
    [SerializeField] private int amountOfPlayers = 1;
    [SerializeField] private int amountOfTiles = 63;
    
    public static GooseGame Instance;
    
    private LinkedList<IPlayer> players;
    private IBoard currentBoard;
    private LinkedListNode<IPlayer> currrentPlayer;
    private Action onGameFinish;

    public int AmountOfTiles => amountOfTiles;
    public Action OnGameFinish
    {
        get => onGameFinish;
        set => onGameFinish = value;
    }

    private void Awake()
    {
        SetUpSingleton();
    }

    [ContextMenu("Start Board Game %g")]
    public void StartGame()
    {
        SetUpGame();
        StartFirstPlayerTurn();
    }
    
    public void EndGame()
    {
        UnsubscribeFromPlayerEvents();
        onGameFinish?.Invoke();
    }
    
    //TODO: Quemar esto
    public ISpace GetNextSpace(ISpace space, int spaceDistance)
    {
        return currentBoard.GetNextSpace(space, spaceDistance);
    }
    
    private void SetUpSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void SetUpGame()
    {
        CreateBoard();
        CreatePlayers();
        SetUpPlayersInitialPosition();
        SubscribeToPlayerEvents();
    }

    private void CreateBoard()
    {
        var tileBuilder = new BasicTileBuilder();
        currentBoard = new Board(tileBuilder);
    }

    private void CreatePlayers()
    {
        players = new LinkedList<IPlayer>();

        for (int i = 0; i < amountOfPlayers; i++)
        {
            players.AddLast(new AIPlayer());
        }
    }

    private void SetUpPlayersInitialPosition()
    {
        for (var currentPlayer = players.First; currentPlayer != null; currentPlayer = currentPlayer.Next)
        {
            currentPlayer.Value.SetPlayerInitialSpace(currentBoard.GetInitialSpace());
        }
    }

    private void SubscribeToPlayerEvents()
    {
        var currentNode = players.First;

        while (currentNode != null)
        {
            currentNode.Value.OnTurnFinish += GoToNextPlayerTurn;
            currentNode = currentNode.Next;
        }
    }
    
    private void UnsubscribeFromPlayerEvents()
    {
        var currentNode = players.First;

        while (currentNode != null )
        {
            currentNode.Value.OnTurnFinish -= GoToNextPlayerTurn;
            currentNode = currentNode.Next;
        }
    }

    private void StartFirstPlayerTurn()
    {
        currrentPlayer = players.First;
        currrentPlayer.Value.PlayTurn();
    }

    private void GoToNextPlayerTurn()
    {
        currrentPlayer = GetNextPlayer();
        currrentPlayer.Value.PlayTurn();
    }

    private LinkedListNode<IPlayer> GetNextPlayer()
    {
        return currrentPlayer.Next ?? players.First;
    }
}

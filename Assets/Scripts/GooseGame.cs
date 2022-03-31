using System;
using System.Collections.Generic;
using UnityEngine;

public class GooseGame
{
    private IPlayer _currrentPlayer;
    private IPlayer _startingPlayer;
    private LinkedList<IPlayer> _playersTurnOrder;

    public IBoard Board { get; private set; }
    public List<IPlayer> Players { get; }
    public bool IsGameBeingPlayed;

    public GooseGame()
    {
        Players = new List<IPlayer>();
        _playersTurnOrder = new LinkedList<IPlayer>();
    }

    public void CreateBoard()
    {
        Board = new Board();
        Board.SetUpSpaces(new BasicTileBuilder());
    }

    public void AddPlayer(IPlayer player)
    {
        Players.Add(player);
        _playersTurnOrder.AddLast(player);
    }

    public void SetStartingPlayer(IPlayer startingPlayer)
    {
        _startingPlayer = startingPlayer;
        _currrentPlayer = _startingPlayer;
    }
    
    public void StartGame()
    {
        SetUpGame();
        CallStartGame();
        CallNewTurn();
    }

    public void PlayNextTurn()
    {
        if (IsGameBeingPlayed)
        {
            MoveToNextPlayer();
            CallNewTurn();
        }
    }
    
    public void EndGame()
    {
        CallEndGame();
        TearDownGame();
    }

    private void SetUpGame()
    {
        IsGameBeingPlayed = true;
        SetUpPlayersInitialPosition();
    }

    private static void CallStartGame()
    {
        GameEvents.StartGame();
    }
    
    private void CallNewTurn()
    {
        GameEvents.SetNewTurn(_currrentPlayer);
    }

    private static void CallEndGame()
    {
        GameEvents.EndGame();
    }

    private void TearDownGame()
    {
        IsGameBeingPlayed = false;
    }

    private void SetUpPlayersInitialPosition()
    {
        foreach (var player in Players)
        {
            player.CurrentSpace = Board.GetInitialSpace();
        }
    }

    private void MoveToNextPlayer()
    {
        _currrentPlayer = GetNextPlayer();
    }

    private IPlayer GetNextPlayer()
    {
        var currentPlayerNode = _playersTurnOrder.Find(_currrentPlayer);
        return currentPlayerNode.Next  != null? currentPlayerNode.Next.Value : _playersTurnOrder.First.Value;
    }
}

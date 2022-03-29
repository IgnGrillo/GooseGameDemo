using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GooseGame : MonoBehaviour
{
    private IBoard _board;
    private List<IPlayer> _players;
    private IPlayer _currrentPlayer;
    private LinkedList<IPlayer> _playersTurnOrder;
    private Action _onGameStart;
    private Action _onGameFinish;
    
    public IBoard Board
    {
        get => _board;
        private set => _board = value;
    }

    public List<IPlayer> Players
    {
        get => _players;
        private set => _players = value;
    }

    public Action OnGameStart
    {
        get => _onGameStart;
        set => _onGameStart = value;
    }
    
    public Action OnGameFinish
    {
        get => _onGameFinish;
        set => _onGameFinish = value;
    }
    
    public void CreateBoard()
    {
        Board = new Board();
        Board.SetUpSpaces(new BasicTileBuilder());
    }

    public void AddPlayer(IPlayer player)
    {
        if (Players == null)
        {
            _players = new List<IPlayer>();
        }
        if (_playersTurnOrder == null)
        {
            _playersTurnOrder = new LinkedList<IPlayer>();
        }
        
        Players.Add(player);
        _playersTurnOrder.AddLast(player);
    }

    public void SetStartingPLayer(IPlayer startingPlayer)
    {
        _currrentPlayer = startingPlayer;
    }
    
    [ContextMenu("Start Board Game %g")]
    public void StartGame()
    {
        SetUpGame();
        _onGameStart?.Invoke();
        StartFirstPlayerTurn();
    }
    
    public void EndGame()
    {
        GameEvents.OnGameFinish -= EndGame;
        UnsubscribeFromPlayerEvents();//Esto tendria que estar subsctripto al ongame finish
        _onGameFinish?.Invoke();
    }

    private void SetUpGame()
    {
        SetUpPlayersInitialPosition();
        SubscribeToPlayerEvents();
        SubscribeToGameFinish();
    }

    private void SetUpPlayersInitialPosition()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].CurrentSpace = Board.GetInitialSpace();     
        }
    }

    private void SubscribeToPlayerEvents()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].OnTurnFinish += GoToNextPlayerTurn;
        }
    }

    private void SubscribeToGameFinish()
    {
        GameEvents.OnGameFinish += EndGame;
    }
    
    private void UnsubscribeFromPlayerEvents()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].OnTurnFinish -= GoToNextPlayerTurn;
        }
    }

    private void StartFirstPlayerTurn()
    {
        _currrentPlayer.PlayTurn();
    }

    private void GoToNextPlayerTurn()
    {
        _currrentPlayer = GetNextPlayer();
        _currrentPlayer.PlayTurn();
    }

    private IPlayer GetNextPlayer()
    {
        var currentPlayerNode = _playersTurnOrder.Find(_currrentPlayer);
        return currentPlayerNode.Next  != null? currentPlayerNode.Next.Value : _playersTurnOrder.First.Value;
    }
}

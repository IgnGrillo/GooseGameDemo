using System.Collections.Generic;
using NUnit.Framework;

public class GooseGameShould
{
    private GooseGame _gooseGame;
    private bool _gameStartFlag;
    private bool _gameFinishFlag;
    private Dictionary<IPlayer,int> _playedTurns;
    
    [SetUp]
    public void SetUp()
    {
        _gooseGame = new GooseGame();
    }

    [Test]
    public void TakePlayersWhenAssigned()
    {
        WhenOneAIPlayerAdded();
        ThenAssertForOnePlayerAmount();
    }

    [Test]
    public void CreateABoard()
    {
        WhenABoardIsCreated();
        ThenAssertBoardCreation();
    }

    [Test]
    public void CallTheStartGameEventWhenAGameStarts()
    {
        GivenAnAIPlayerAndABoard();
        GivenAGameStartSubscription();
        WhenTheGameStarts();
        ThenCheckStartFlagStatus();
        TearDownGameStartSubscription();
    }
    
    [Test]
    public void CallTheGameFinishEventWhenAGameEnds()
    {
        GivenAGameFinishSubscription();
        WhenTheGameEnds();
        ThenCheckFinishFlagStatus();
        TearDownGameFinishSubscription();
    }
    
    [Test]
    public void HaveTheIsBeingPlayedFlagRaisedWhenAGameIsBeingPlayed()
    {
        GivenAnAIPlayerAndABoard();
        WhenTheGameStarts();
        ThenAssertIsBeingPlayedAsTrue();
    }
    
    [Test]
    public void HaveTheIsBeingPlayedFlagDownWhenAGameEnds()
    {
        WhenTheGameEnds();
        ThenAssertIsBeingPlayedAsFalse();
    }

    [Test]
    public void MoveToTheNextTurnWhenTheGameIsNotPrepared()
    {
        GivenAnAIPlayerAndABoard();
        GivenANewTurnSubscription();
        WhenWeStartGameAndProceedToNextTurn();
        Assert.AreEqual(2,GetTotalAmountOfPlayedTurns());
        TearDownNewTurnSubscription();
    }
    
    [Test]
    public void NotMoveToTheNextTurnWhenTheGameIsNotPrepared()
    {
        GivenAnAIPlayerAndABoard();
        GivenANewTurnSubscription();
        WhenWeProceedToNextTurn();
        Assert.AreEqual(0,GetTotalAmountOfPlayedTurns());
        TearDownNewTurnSubscription();
    }

    private void GivenABoardGame()
    {
        _gooseGame.CreateBoard();
    }

    private void GivenAnAIPlayerAndABoard()
    {
        GivenABoardGame();
        GivenASingleAIAsTheStartingPlayer();
    }
    
    private void GivenASingleAIAsTheStartingPlayer()
    {
        var aiPlayer = new AIPlayer();
        aiPlayer.CurrentBoard = _gooseGame.Board;
        _gooseGame.AddPlayer(aiPlayer);
        _gooseGame.SetStartingPlayer(aiPlayer);
    }

    private void GivenAGameStartSubscription()
    {
        GameEvents.OnGameStart += RaiseGameStartFlag;
    }
    
    private void GivenAGameFinishSubscription()
    {
        GameEvents.OnGameFinish += RaiseGameFinishFlag;
    }

    private void GivenANewTurnSubscription()
    {
        _playedTurns = new Dictionary<IPlayer, int>();
        GameEvents.OnNewTurn += AddAmountOfPlayedTurns;
    }
    
    private void WhenOneAIPlayerAdded()
    {
        _gooseGame.AddPlayer(new AIPlayer());
    }
    
    private void WhenABoardIsCreated()
    {
        _gooseGame.CreateBoard();
    }
    
    private void WhenTheGameStarts()
    {
        _gooseGame.StartGame();
    }
    
    private void WhenTheGameEnds()
    {
        _gooseGame.EndGame();
    }
    
    private void WhenWeStartGameAndProceedToNextTurn()
    {
        _gooseGame.StartGame();
        _gooseGame.PlayNextTurn();
    }

    private void WhenWeProceedToNextTurn()
    {
        _gooseGame.PlayNextTurn();
    }
    
    private void ThenCheckStartFlagStatus()
    {
        Assert.IsTrue(_gameStartFlag);
    }
    
    private void ThenCheckFinishFlagStatus()
    {
        Assert.IsTrue(_gameFinishFlag);
    }

    private void ThenAssertForOnePlayerAmount()
    {
        Assert.AreEqual(1, _gooseGame.Players.Count);
    }
    
    private void ThenAssertBoardCreation()
    {
        Assert.IsNotNull(_gooseGame.Board);
    }

    private void ThenAssertIsBeingPlayedAsTrue()
    {
        Assert.IsTrue(_gooseGame.IsGameBeingPlayed);
    }
    
    private void ThenAssertIsBeingPlayedAsFalse()
    {
        Assert.IsFalse(_gooseGame.IsGameBeingPlayed);
    }
    
    private void TearDownGameStartSubscription()
    {
        _gameStartFlag = false;
        GameEvents.OnGameStart -= RaiseGameStartFlag;
    }

    private void TearDownGameFinishSubscription()
    {
        _gameFinishFlag = false;
        GameEvents.OnGameFinish -= RaiseGameFinishFlag;
    }

    private void TearDownNewTurnSubscription()
    {
        _playedTurns.Clear();
        GameEvents.OnNewTurn -= AddAmountOfPlayedTurns;
    }
    
    private void RaiseGameStartFlag()
    {
        _gameStartFlag = true;
    }

    private void RaiseGameFinishFlag()
    {
        _gameFinishFlag = true;
    }

    private void AddAmountOfPlayedTurns(IPlayer player)
    {
        if (!_playedTurns.ContainsKey(player))
        {
            _playedTurns.Add(player,1);
        }
        else
        {
            _playedTurns[player]++;
        }
    }

    private int GetTotalAmountOfPlayedTurns()
    {
        int turnsPlayed = 0;
        foreach (var playerTurns in _playedTurns)
        {
            turnsPlayed += playerTurns.Value;
        }
        return turnsPlayed;
    }
}

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GooseGameShould
{
    private GooseGame _gooseGame;
    private bool _gameFinishFlag;
    
    [SetUp]
    public void SetUp()
    {
        _gooseGame = new GameObject("Goose Game").AddComponent<GooseGame>();
    }

    [Test]
    public void CreateOnePlayer()
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

    [Test][Ignore("tendria que ser un Play, el hecho de que el juego termine no es directamente su responsabilidad")]
    public void StartGame()
    {
        GivenASoloGame();
        GivenAGameFinishSubscription();
        WhenStartGame();
        ThenCheckFinishFlagStatus();
        TearDownGameFinishSubscription();
    }

    private void ThenCheckFinishFlagStatus()
    {
        Assert.IsTrue(_gameFinishFlag);
    }

    private void WhenOneAIPlayerAdded()
    {
        _gooseGame.AddPlayer(new AIPlayer());
    }
    
    private void WhenABoardIsCreated()
    {
        _gooseGame.CreateBoard();
    }

    private void GivenABoardGame()
    {
        _gooseGame.CreateBoard();
    }

    private void GivenASingleAIAsTheStartingPlayer()
    {
        var aiPlayer = new AIPlayer();
        aiPlayer.CurrentBoard = _gooseGame.Board;//que onda con esto
        _gooseGame.AddPlayer(aiPlayer);
        _gooseGame.SetStartingPLayer(aiPlayer);
    }

    private void GivenAGameFinishSubscription()
    {
        _gooseGame.OnGameFinish += RaiseGameFinishFlag;
    }

    private void GivenASoloGame()
    {
        GivenASingleAIAsTheStartingPlayer();
        GivenABoardGame();
    }

    private void WhenStartGame()
    {
        _gooseGame.StartGame();
    }
    
    private void ThenAssertForOnePlayerAmount()
    {
        Assert.AreEqual(1, _gooseGame.Players.Count);
    }
    
    private void ThenAssertBoardCreation()
    {
        Assert.IsNotNull(_gooseGame.Board);
    }

    private void TearDownGameFinishSubscription()
    {
        _gameFinishFlag = false;
        _gooseGame.OnGameFinish -= RaiseGameFinishFlag;
    }

    private void RaiseGameFinishFlag()
    {
        _gameFinishFlag = true;
    }
}

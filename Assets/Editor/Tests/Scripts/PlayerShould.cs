using NUnit.Framework;

public class PlayerShould
{
    private IPlayer _currentPlayer;
    private bool _turnStartFlag;
    private bool _turnFinishFlag;

    [SetUp]
    public void Setup()
    {
        _currentPlayer = new AIPlayer();
    }
    
    [Test]
    public void TakeASpaceWhenAssigned()
    {
        GivenABasicSpaceAsCurrentSpace();
        ThenCheckCurrentSpace();
    }

    [Test]
    public void TakeABoardWhenAssigned()
    {
        GivenABoardAsCurrentBoard();
        ThenCheckCurrentBoard();
    }

    [Test]
    public void CallTheOnTurnStartWhenPlayingItsTurn()
    {
        GivenFullySetUpBoard();
        GivenStartingPosition();
        GivenTurnStartEventSubscription();
        WhenPlayerPlaysTurn();
        ThenAssertTurnStartFlagStatus();
        TearDownOnTurnStartSubscription();
    }

    [Test]
    public void CallTheOnTurnFinishWhenPlayingItsTurn()
    {
        GivenFullySetUpBoard();
        GivenStartingPosition();
        GivenTurnFinishEventSubscription();
        WhenPlayerPlaysTurn();
        ThenAssertTurnFinishFlagStatus();
        TearDownOnTurnFinishSubscription();
    }

    [Test][Ignore("Reunion")]
    public void MoveToAnotherSpaceWhenCalledTo()
    {
        GivenFullySetUpBoard();
        GivenStartingPosition();
        WhenPlayerPlaysTurn();
    }

    private void GivenABasicSpaceAsCurrentSpace()
    {
        _currentPlayer.CurrentSpace = new BasicSpace();
    }

    private void GivenABoardAsCurrentBoard()
    {
        _currentPlayer.CurrentBoard = new Board();
    }

    private void GivenFullySetUpBoard()
    {
        var board = new Board();
        board.SetUpSpaces(new BasicTileBuilder());
        _currentPlayer.CurrentBoard = board;
    }

    private void GivenStartingPosition()
    {
        var initialSpace = _currentPlayer.CurrentBoard.GetInitialSpace();
        _currentPlayer.CurrentSpace = initialSpace;
    }
    
    private void GivenTurnStartEventSubscription()
    {
        _currentPlayer.OnTurnStart += RaiseStartTurnFlag;
    }
    
    private void GivenTurnFinishEventSubscription()
    {
        _currentPlayer.OnTurnFinish += RaiseTurnFinishFlag;
    }

    private void WhenPlayerPlaysTurn()
    {
        _currentPlayer.PlayTurn();
    }
    
    private void ThenCheckCurrentBoard()
    {
        Assert.IsNotNull(_currentPlayer.CurrentBoard);
    }

    private void ThenCheckCurrentSpace()
    {
        Assert.IsNotNull(_currentPlayer.CurrentSpace);
    }
    
    private void ThenAssertTurnStartFlagStatus()
    {
        Assert.IsTrue(_turnStartFlag);
    }
    
    private void ThenAssertTurnFinishFlagStatus()
    {
        Assert.IsTrue(_turnFinishFlag);
    }
    
    private void RaiseStartTurnFlag()
    {
        _turnStartFlag = true;
    }

    private void RaiseTurnFinishFlag()
    {
        _turnFinishFlag = true;
    }

    private void TearDownOnTurnStartSubscription()
    {
        _turnStartFlag = false;
        _currentPlayer.OnTurnStart -= RaiseStartTurnFlag;
    }
    
    private void TearDownOnTurnFinishSubscription()
    {
        _turnFinishFlag = false;
        _currentPlayer.OnTurnFinish -= RaiseTurnFinishFlag;
    }
}

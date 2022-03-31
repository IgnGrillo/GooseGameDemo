using NUnit.Framework;

public class BoardShould
{
    private IBoard _board;

    [SetUp]
    public void SetUp()
    {
        _board = new Board();
    }

    [Test]
    public void SetUpItsSpaces()
    {
        WhenBoardSpacesAreSetUp();
        ThenAssertItsSpacesAreNotNull();
    }

    [Test]
    public void HaveAnInitialSpace()
    {
        WhenBoardSpacesAreSetUp();
        ThenAssertInitialSpaceHasIndexZero();
    }
    
    [Test]
    public void HaveALastSpace()
    {
        WhenBoardSpacesAreSetUp();
        ThenAssertLastSpaceHasCorrectIndex();
    }

    [Test]
    public void ReturnSubsequentSpaces()
    {
        WhenBoardSpacesAreSetUp();
        ThenAssertBoardSpacesPosition();
    }
    
    private void WhenBoardSpacesAreSetUp()
    {
        _board.SetUpSpaces(new BasicTileBuilder());
    }

    private void ThenAssertItsSpacesAreNotNull()
    {
        Assert.IsNotNull(_board.Spaces);
    }
    
    private void ThenAssertInitialSpaceHasIndexZero()
    {
        Assert.AreEqual(0,_board.GetInitialSpace().SpaceIndex);
    }
    
    private void ThenAssertLastSpaceHasCorrectIndex()
    {
        Assert.AreEqual(_board.Spaces.Count - 1,_board.Spaces.Last.Value.SpaceIndex);
    }

    private void ThenAssertBoardSpacesPosition()
    {
        var initialSpace = _board.GetInitialSpace();
        var lastSpaceIndex = _board.Spaces.Last.Value.SpaceIndex;
        
        Assert.AreEqual(1,_board.GetNextSpace(initialSpace, 1).SpaceIndex);
        Assert.AreEqual(lastSpaceIndex / 4,_board.GetNextSpace(initialSpace, lastSpaceIndex / 4).SpaceIndex);
        Assert.AreEqual( lastSpaceIndex,_board.GetNextSpace(initialSpace, lastSpaceIndex).SpaceIndex);
        Assert.AreEqual(lastSpaceIndex, _board.GetNextSpace(initialSpace, lastSpaceIndex + 100).SpaceIndex);
    }
}

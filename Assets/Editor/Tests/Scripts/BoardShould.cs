using NUnit.Framework;

public class BoardShould
{
    private IBoard _board;
    private ISpace _initialSpace;
    private ISpace _lastSpace;
    private int _lastSpaceIndex;

    [SetUp]
    public void SetUp()
    {
        _board = new Board();
    }

    [Test]
    public void SetUpItsSpaces()
    {
        GivenABoardSpaceSetUp();
        ThenAssertItsSpacesAreNotNull();
    }

    [Test]
    public void HaveAnInitialSpace()
    {
        GivenABoardSpaceSetUp();
        ThenAssertInitialSpaceHasIndexZero();
    }
    
    [Test]
    public void HaveALastSpace()
    {
        GivenABoardSpaceSetUp();
        ThenAssertLastSpaceHasCorrectIndex();
    }

    [Test]
    public void ReturnSubsequentSpaces()
    {
        GivenABoardSpaceSetUp();
        GivenInitialAndLastSpace();
        ThenAssertBoardSpacesPosition();
    }

    private void GivenABoardSpaceSetUp()//Cambiar a un When
    {
        _board.SetUpSpaces(new BasicTileBuilder());
    }

    private void GivenInitialAndLastSpace()// Que onda esto, creo variables que solo uso una vez
    {
        _initialSpace = _board.GetInitialSpace(); 
        _lastSpace = _board.GetLastSpace();
        _lastSpaceIndex = _lastSpace.SpaceIndex;
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
        Assert.AreEqual(_board.Spaces.Count - 1,_board.GetLastSpace().SpaceIndex);
    }

    private void ThenAssertBoardSpacesPosition()
    {
        Assert.AreEqual(1,_board.GetNextSpace(_initialSpace, 1).SpaceIndex);
        Assert.AreEqual(_lastSpaceIndex / 4,_board.GetNextSpace(_initialSpace, _lastSpaceIndex / 4).SpaceIndex);
        Assert.AreEqual( _lastSpaceIndex,_board.GetNextSpace(_initialSpace, _lastSpaceIndex).SpaceIndex);
        Assert.AreEqual(_lastSpaceIndex, _board.GetNextSpace(_initialSpace, _lastSpaceIndex + 100).SpaceIndex);
    }
}

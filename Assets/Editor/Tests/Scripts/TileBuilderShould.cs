using System.Collections.Generic;
using NUnit.Framework;

public class TileBuilderShould
{
    private ITileBuilder _builder;
    private Board _board;
    private LinkedList<ISpace> _spaces;

    [SetUp]
    public void SetUp()
    {
        _builder = new BasicTileBuilder();
        _board = new Board();
    }
    
    [Test]
    public void CreateTilesOnSetUp()
    {
        WhenTilesAreRetrieved();
        ThenSpacesAreNotNull();
    }

    [Test]
    public void HaveTheCorrectAmountOfTilesOnCreation()
    {
        WhenTilesAreRetrieved();
        ThenDesiredSpacesCoincidesWithSpacesCreated();
    }

    [Test]
    public void HaveNoTilesWithSameIndex()
    {
        WhenTilesAreRetrieved();
        ThenCheckForNoRepetitionsOnSpacesIndexes();
    }

    private void WhenTilesAreRetrieved()
    {
        _spaces = _builder.GetBoardSpaces(_board);
    }

    private void ThenSpacesAreNotNull()
    {
        Assert.IsNotNull(_spaces);
    }

    private void ThenDesiredSpacesCoincidesWithSpacesCreated()
    {
        Assert.AreEqual(_builder.DesiredTiles,_spaces.Count);
    }

    private void ThenCheckForNoRepetitionsOnSpacesIndexes()
    {
        Assert.IsFalse(IsThereAnIndexCollision());
    }

    private bool IsThereAnIndexCollision()
    {
        Dictionary<int, ISpace> spacesDictionary = new Dictionary<int, ISpace>();
        var currentNode = _spaces.First;
        while (currentNode != null)
        {
            var currentSpace = currentNode.Value;
            if (!spacesDictionary.ContainsKey(currentSpace.SpaceIndex))
            {
                spacesDictionary.Add(currentSpace.SpaceIndex, currentSpace);
            }
            else
            {
                return true;
            }
            currentNode = currentNode.Next;
        }

        return false;
    }
}
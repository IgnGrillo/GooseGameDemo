using System;
using System.Collections.Generic;
using NUnit.Framework;

public class SpacesShould
{
    private ISpace _currentSpace;
    private string _spaceResponse;
    private int _startingSpaceIndex;
    private bool _endGameFlag;
    
    [SetUp]
    public void SetUp()
    {
        _startingSpaceIndex = 0;
    }
    
    [Test]
    public void BeIndexable()
    {
        var spaces = GivenXAmountOfBasicTilesWithIncrementalIndex(10);
        ThenAssertTheirIndexes(spaces);
    }

    [Test]
    public void DisplayMessageWhenPlayBasic()
    {
        GivenBasicSpaceWithIndex(_startingSpaceIndex);
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse($"Stay in Space {_startingSpaceIndex}");
    }

    [Test]
    public void DisplayMessageWhenPlayBridge()
    {
        GivenBridgeSpaceWithIndex(_startingSpaceIndex);
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse($"The Bridge: Go to space {_startingSpaceIndex + 6}");
    }

    [Test]
    public void DisplayMessageWhenPlayFinalSpace()
    {
        GivenFinalSpaceWithIndex(_startingSpaceIndex);
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse($"Stay in Space {_startingSpaceIndex}{Environment.NewLine}End Position");
    }

    [Test]
    public void CallGameFinishWhenPlayFinalSpace()
    {
        GivenFinalSpaceWithIndex(_startingSpaceIndex);
        GivenFinishGameEventSubscription();
        WhenCurrentSpacePlay(); 
        ThenAssertEndGameFlagRaisedState();
        TearDownEndGameSubscription();
    }

    [Test]
    public void DisplayMessageWhenPlayStartingSpace()
    {
        GivenStartingSpaceWithIndex(_startingSpaceIndex);
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse("Start Position");
    }

    [Test]
    public void DisplayMessageWhenPlayTwoSpacesForwardSpace()
    {
        GivenTwoSpacesForwardWithIndex(_startingSpaceIndex);
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse("Move two spaces forward.");
    }

    [Test]
    public void DisplayMessageWhenPlayHotelSpace()
    {
        GivenHotelSpace();
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse("The Hotel: Stay for (miss) one turn");
    }
    
    [Test]
    public void DisplayMessageWhenPlayMazeSpace()
    {
        GivenMazeSpace();
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse("The Maze: Go back to space 39");
    }
    
    [Test]
    public void DisplayMessageWhenPlayWellSpace()
    {
        GivenWellSpace();
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse("The Well: Wait until someone comes to pull you out - they then take your place");
    }
    
    [Test]
    public void DisplayMessageWhenPlayPrisonSpace()
    {
        GivenPrisonSpace();
        WhenCurrentSpacePlay();
        ThenAssertSpaceResponse("The Prison: Wait until someone comes to release you - they then take your place");
    }

    private List<ISpace> GivenXAmountOfBasicTilesWithIncrementalIndex(int xAmount)
    {
        var spaces = new List<ISpace>();
        for (int i = 0; i < xAmount; i++)
        {
            var space = new BasicSpace
            {
                SpaceIndex = i
            };
            spaces.Add(space);
        }
        return spaces;
    }
    
    private void GivenBasicSpaceWithIndex(int spaceIndex)
    {
        _currentSpace = new BasicSpace();
        _currentSpace.SpaceIndex = spaceIndex;
    }
    
    private void GivenBridgeSpaceWithIndex(int spaceIndex)
    {
        _currentSpace = new BridgeSpace();
        _currentSpace.SpaceIndex = spaceIndex;
    }

    private void GivenFinalSpaceWithIndex(int spaceIndex)
    {
        _currentSpace = new FinalSpace();
        _currentSpace.SpaceIndex = spaceIndex;
    }

    private void GivenFinishGameEventSubscription()
    {
        _endGameFlag = false;
        GameEvents.OnGameFinish += RaiseEndGameFlag;
    }
    
    private void GivenStartingSpaceWithIndex(int spaceIndex)
    {
        _currentSpace = new StartingSpace();
        _currentSpace.SpaceIndex = spaceIndex;
    }
    
    private void GivenTwoSpacesForwardWithIndex(int spaceIndex)
    {
        _currentSpace = new TwoSpacesForwardSpace();
        _currentSpace.SpaceIndex = spaceIndex;
    }

    private void GivenHotelSpace()
    {
        _currentSpace = new HotelSpace();
    }
    
    private void GivenMazeSpace()
    {
        _currentSpace = new MazeSpace();
    }
    
    private void GivenPrisonSpace()
    {
        _currentSpace = new PrisonSpace();
    }

    private void GivenWellSpace()
    {
        _currentSpace = new WellSpace();
    }

    private void WhenCurrentSpacePlay()
    {
        _spaceResponse = _currentSpace.Play();
    }
    
    private static void ThenAssertTheirIndexes(List<ISpace> spaces)
    {
        for (int i = 0; i < spaces.Count; i++)
        {
            Assert.AreEqual(i,spaces[i].SpaceIndex);
        }
    }
    
    private void ThenAssertSpaceResponse(string expectedResponse)
    {
        Assert.AreEqual(expectedResponse, _spaceResponse);
    }

    private void ThenAssertEndGameFlagRaisedState()
    {
        Assert.IsTrue(_endGameFlag);
    }

    private void RaiseEndGameFlag()
    {
        _endGameFlag = true;
    }
    
    private void TearDownEndGameSubscription()
    {
        GameEvents.OnGameFinish -= RaiseEndGameFlag;
    }
}
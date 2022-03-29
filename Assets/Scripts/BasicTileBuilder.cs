using System.Collections.Generic;

public class BasicTileBuilder : ITileBuilder
{
    private IBoard _board;
    private LinkedList<ISpace> _spaces;
    private int _currentCreationIndex;

    private const int BASIC_BUILDER_TILES = 64;
    
    public int DesiredTiles => BASIC_BUILDER_TILES;

    public LinkedList<ISpace> GetBoardSpaces(IBoard board)
    {
        _board = board;
        _spaces = new LinkedList<ISpace>();
        ResetSpaceCreationIndex();
        AddTilesToList();
        return _spaces;
    }

    private void ResetSpaceCreationIndex()
    {
        _currentCreationIndex = 0;
    }

    private void AddTilesToList()
    {
        AddStartingSpace(1);
        AddBasicSpaces(5);
        AddBridgeSpaces(1);//6
        AddFiveBasicOneTwoSpaces();
        AddFiveBasicOneTwoSpaces();
        AddHotelSpaces(1);//19
        AddFourBasicSpacesOneTwoSpaces();
        AddFiveBasicOneTwoSpaces();
        AddWellSpaces(1);//31
        AddFourBasicSpacesOneTwoSpaces();
        AddBasicSpaces(5);
        AddMazeSpaces(1);//42
        AddFiveBasicOneTwoSpaces();
        AddBasicSpaces(1);
        AddPrisonSpaces(6);//50-55
        AddFourBasicSpacesOneTwoSpaces();
        AddBasicSpaces(2);
        AddFinalSpaces(1);//63
    }

    private void AddStartingSpace(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetStartingSpace());
            _currentCreationIndex++;
        }
    }

    private void AddBasicSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetBasicSpace());   
            _currentCreationIndex++;
        }
    }
    
    private void AddBridgeSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetBridgeSpace());   
            _currentCreationIndex++;
        }
    }

    private void AddTwoSpacesSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetTwoSpacesForwardSpace());   
            _currentCreationIndex++;
        }
    }

    private void AddFinalSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetFinalSpace());   
            _currentCreationIndex++;
        }
    }
    
    private void AddHotelSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetHotelSpace());   
            _currentCreationIndex++;
        }
    }
    
    private void AddMazeSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetMazeSpace());   
            _currentCreationIndex++;
        }
    }
    
    private void AddPrisonSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetPrisonSpace());   
            _currentCreationIndex++;
        }
    }
    
    private void AddWellSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetWellSpace());   
            _currentCreationIndex++;
        }
    }
    
    private void AddFiveBasicOneTwoSpaces()
    {
        AddBasicSpaces(5);
        AddTwoSpacesSpaces(1);
    }
    
    private void AddFourBasicSpacesOneTwoSpaces()
    {
        AddBasicSpaces(4);
        AddTwoSpacesSpaces(1);
    }

    private StartingSpace GetStartingSpace()
    {
        var space = new StartingSpace
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }

    private BasicSpace GetBasicSpace()
    {
        var space = new BasicSpace
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }

    private BridgeSpace GetBridgeSpace()
    {
        var space = new BridgeSpace
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }

    private TwoSpacesForwardSpace GetTwoSpacesForwardSpace()
    {
        var space = new TwoSpacesForwardSpace
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }

    private FinalSpace GetFinalSpace()
    {
        var space = new FinalSpace()
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }
    
    private HotelSpace GetHotelSpace()
    {
        var space = new HotelSpace()
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }
    
    private MazeSpace GetMazeSpace()
    {
        var space = new MazeSpace()
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }
    
    private PrisonSpace GetPrisonSpace()
    {
        var space = new PrisonSpace()
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }
    
    private WellSpace GetWellSpace()
    {
        var space = new WellSpace()
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }
}
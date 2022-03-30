using System.Collections.Generic;

public class BasicTileBuilder : ITileBuilder
{
    private IBoard _board;
    private LinkedList<ISpace> _spaces;
    private int _currentCreationIndex;

    private const int BASIC_BUILDER_TILES = 64;
    
    public int DesiredTileAmount => BASIC_BUILDER_TILES;
    
    //Crear con un constructor con sus dependencias necesarias
    //Dividir mas los metodos, reflejando mejor la intencionalidad

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
        AddSpace(new StartingSpaceRule(),1);
        AddSpace(new BasicSpaceRule(),5);
        AddSpace(new BridgeSpaceRule(),1);;//6
        AddFiveBasicOneTwoSpaces();
        AddFiveBasicOneTwoSpaces();
        AddSpace(new HotelSpaceRule(),1);//19
        AddFourBasicSpacesOneTwoSpaces();
        AddFiveBasicOneTwoSpaces();
        AddSpace(new WellSpaceRule(),1);//31
        AddFourBasicSpacesOneTwoSpaces();
        AddSpace(new BasicSpaceRule(),5);
        AddSpace(new MazeSpaceRule(),1);//42
        AddFiveBasicOneTwoSpaces();
        AddSpace(new BasicSpaceRule(),1);
        AddSpace(new PrisonSpaceRule(),6);//50-55
        AddFourBasicSpacesOneTwoSpaces();
        AddSpace(new BasicSpaceRule(),2);
        AddSpace(new FinalSpaceRule(),1);//63
    }

    private void AddSpace(ISpaceRule rule, int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            _spaces.AddLast(GetSpace(rule));
            _currentCreationIndex++;
        }
    }

    private Space GetSpace(ISpaceRule rule)
    {
        var space = new Space(rule)
        {
            Board = _board,
            SpaceIndex = _currentCreationIndex
        };
        return space;
    }

    
    private void AddFiveBasicOneTwoSpaces()
    {
        AddSpace(new BasicSpaceRule(),5);
        AddSpace(new TwoSpacesForwardRule(),1);
    }
    
    private void AddFourBasicSpacesOneTwoSpaces()
    {
        AddSpace(new BasicSpaceRule(),4);
        AddSpace(new TwoSpacesForwardRule(),1);
    }
}
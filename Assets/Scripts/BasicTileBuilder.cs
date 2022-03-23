using System.Collections.Generic;

public class BasicTileBuilder : ITileBuilder
{
    private  LinkedList<ISpace> spaces;
    private IBoard board;
    
    public LinkedList<ISpace> GetBoardTiles(IBoard board)
    {
        this.board = board;
        spaces = new LinkedList<ISpace>();
        AddTilesToList();
        return spaces;
    }

    private void AddTilesToList()
    {
        AddStartingSpace(1);
        AddBasicSpaces(5);
        AddBridgeSpaces(1);

        var amountOfRepetitions = (63 - 6) / 6;
        for (int i = 0; i < amountOfRepetitions; i++)
        {
            AddBasicSpaces(5);
            AddTwoSpacesSpaces(1);
        }

        AddBasicSpaces(2);
        AddFinalSpaces(1);
    }
    
    private void AddStartingSpace(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            spaces.AddLast(new StartingSpace(board));
        }
    }

    private void AddBasicSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            spaces.AddLast(new BasicSpace(board));
        }
    }
    
    private void AddBridgeSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            spaces.AddLast(new BridgeSpace(board));
        }
    }
    
    private void AddTwoSpacesSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            spaces.AddLast(new TwoSpacesForwardSpace(board));
        }
    }
    
    private void AddFinalSpaces(int amountToAdd)
    {
        for (int i = 0; i < amountToAdd; i++)
        {
            spaces.AddLast(new FinalSpace(board));
        }
    }
}
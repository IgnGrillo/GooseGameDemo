using System.Collections.Generic;

public class Board : IBoard
{
    private LinkedList<ISpace> spaces;

    public Board(ITileBuilder tileBuilder)
    {
        SetUpBoard(tileBuilder);
    }
    
    public ISpace GetInitialSpace()
    {
        return spaces.First.Value;
    }

    public ISpace GetNextSpace(ISpace space, int spaceDistance)
    {
        LinkedListNode<ISpace> currentSpace = spaces.Find(space);
        int counter = 0;
        
        while (currentSpace != null && counter < spaceDistance)
        {
            counter++;
            currentSpace = currentSpace.Next;
        }
        
        return currentSpace.Value;
    }

    public int GetSpaceIndex(ISpace space)
    {
        int counter = 0;
        var currentElement = spaces.First;
        
        while (currentElement.Value != space && currentElement.Value != null)
        {
            currentElement = currentElement.Next;
            counter++;
        }

        return counter;
    }
    
    private void SetUpBoard(ITileBuilder tileBuilder)
    {
        spaces = tileBuilder.GetBoardTiles(this);
    }
}

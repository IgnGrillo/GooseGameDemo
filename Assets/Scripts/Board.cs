using System.Collections.Generic;

public class Board : IBoard
{
    public LinkedList<ISpace> Spaces { get; private set; }

    public void SetUpSpaces(ITileBuilder tileBuilder)
    {
        Spaces = tileBuilder.GetBoardSpaces(this);
    }

    public ISpace GetInitialSpace()
    {
        return Spaces.First.Value;
    }

    public ISpace GetNextSpace(ISpace space, int distanceToMove)
    {
        LinkedListNode<ISpace> currentSpace = Spaces.Find(space);
        int movedSpaces = 0;
        
        while (movedSpaces < distanceToMove)
        {
            var nextSpace = currentSpace.Next;
            if (nextSpace == null) break;
            else
            {
                currentSpace = nextSpace;
                movedSpaces++;
            }
        }
        
        return currentSpace.Value;
    }
}

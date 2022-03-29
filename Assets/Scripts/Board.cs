using System.Collections.Generic;

public class Board : IBoard
{
    private LinkedList<ISpace> _spaces;

    public LinkedList<ISpace> Spaces
    {
        get => _spaces;
        private set => _spaces = value;
    }

    public void SetUpSpaces(ITileBuilder tileBuilder)
    {
        Spaces = tileBuilder.GetBoardSpaces(this);
    }

    public ISpace GetInitialSpace()
    {
        return Spaces.First.Value;
    }

    public ISpace GetLastSpace()
    {
        return Spaces.Last.Value;
    }

    public ISpace GetNextSpace(ISpace space, int spaceDistance)
    {
        LinkedListNode<ISpace> currentSpace = Spaces.Find(space);
        int counter = 0;
        
        while (currentSpace != null && counter < spaceDistance)
        {
            counter++;
            if (!TrySetNextSpace(ref currentSpace)) break;
        }
        
        return currentSpace.Value;
    }

    private bool TrySetNextSpace(ref LinkedListNode<ISpace> currentSpace)
    {
        if (currentSpace.Next != null)
        {
            currentSpace = currentSpace.Next;
            return true;
        }
        else
        {
            return false;
        }
    }
}

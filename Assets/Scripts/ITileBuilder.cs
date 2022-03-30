using System.Collections.Generic;

public interface ITileBuilder
{
    public int DesiredTileAmount { get; }
    LinkedList<ISpace> GetBoardSpaces(IBoard board);
}

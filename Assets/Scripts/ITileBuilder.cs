using System.Collections.Generic;

public interface ITileBuilder
{
    public int DesiredTiles { get; }
    LinkedList<ISpace> GetBoardSpaces(IBoard board);
}

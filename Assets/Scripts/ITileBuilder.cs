using System.Collections.Generic;

public interface ITileBuilder
{
    LinkedList<ISpace> GetBoardTiles(IBoard board);
}

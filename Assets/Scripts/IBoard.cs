using System.Collections.Generic;

public interface IBoard
{
    LinkedList<ISpace> Spaces { get; }
    void SetUpSpaces(ITileBuilder tileBuilder);
    ISpace GetInitialSpace();
    ISpace GetLastSpace();
    ISpace GetNextSpace(ISpace space, int spaceDistance);
}

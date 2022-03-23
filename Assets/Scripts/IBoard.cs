public interface IBoard
{
    ISpace GetInitialSpace();
    ISpace GetNextSpace(ISpace space, int spaceDistance);
    int GetSpaceIndex(ISpace space);
}

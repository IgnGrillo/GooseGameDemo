using UnityEngine;

public class BasicSpace : ISpace
{
    protected IBoard board;

    public IBoard Board => board;
    
    public BasicSpace(IBoard board)
    {
        this.board = board;
    }

    public virtual void PlaySpace()
    {
        Debug.Log($"Stay in Space {board.GetSpaceIndex(this)}");
    }
}

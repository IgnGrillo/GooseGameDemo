using UnityEngine;

public class BridgeSpace : BasicSpace
{
    public BridgeSpace(IBoard board) : base(board)
    {
    }
    
    public override void PlaySpace()
    {
        Debug.Log($"The Bridge: Go to space {board.GetSpaceIndex(this) + 6}");
    }
}

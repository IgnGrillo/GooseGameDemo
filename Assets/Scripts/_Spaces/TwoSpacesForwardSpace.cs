using UnityEngine;

public class TwoSpacesForwardSpace : BasicSpace
{
    public TwoSpacesForwardSpace(IBoard board) : base(board)
    {
    }
    
    public override void PlaySpace()
    {
        Debug.Log("Move two spaces forward.");
    }
}

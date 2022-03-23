using UnityEngine;

public class FinalSpace : BasicSpace
{
    public FinalSpace(IBoard board) : base(board)
    {
    }

    public override void PlaySpace()
    {
        base.PlaySpace();
        Debug.Log("End Position");
        GooseGame.Instance.EndGame(); 
    }
}

using System;

public interface IPlayer
{
    IBoard CurrentBoard { get; set; }
    ISpace CurrentSpace { get; set; }
    Action OnTurnStart { get; set; }
    Action OnTurnFinish { get; set; }
    void PlayTurn();
    void MovePlayerForward(int amountOfSpacesToMove);
}

using System;

public interface IPlayer
{
    bool CanPlayTurn { get; set; }
    ISpace CurrentSpace { get; set; }
    Action OnTurnFinish { get; set; }
    void SetPlayerInitialSpace(ISpace space);
    void PlayTurn();
}

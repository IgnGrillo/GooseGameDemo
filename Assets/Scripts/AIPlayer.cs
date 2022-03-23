using System;

public class AIPlayer : IPlayer
{
    private RollTheDiceCommand _rollTheDiceCommand;

    public bool CanPlayTurn { get; set; }
    public ISpace CurrentSpace { get; set; }
    public Action OnTurnFinish { get; set; }

    public AIPlayer()
    {
        SetUpCommands();
    }

    public void SetPlayerInitialSpace(ISpace space)
    {
        CurrentSpace = space;
    }

    public void PlayTurn()
    {
        _rollTheDiceCommand.Execute(this);
        OnTurnFinish?.Invoke();
    }

    private void SetUpCommands()
    {
        _rollTheDiceCommand = new RollTheDiceCommand();
    }
}

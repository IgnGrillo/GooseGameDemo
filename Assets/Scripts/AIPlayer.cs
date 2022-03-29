using System;

public class AIPlayer : IPlayer
{
    private RollTheDiceCommand _rollTheDiceCommand;
    private IBoard _currentBoard;
    private ISpace _currentSpace;

    public IBoard CurrentBoard
    {
        get => _currentBoard;
        set => _currentBoard = value;
    }
    public ISpace CurrentSpace
    {
        get => _currentSpace;
        set => _currentSpace = value;
    }
    public Action OnTurnStart { get; set; }
    public Action OnTurnFinish { get; set; }

    public AIPlayer()
    {
        SetUpCommands();
    }
    
    public void PlayTurn()
    {
        OnTurnStart?.Invoke();
        _rollTheDiceCommand.Execute(this);
        OnTurnFinish?.Invoke(); 
    }

    public void MovePlayerForward(int amountOfSpacesToMove)
    {
        _currentSpace = CurrentBoard.GetNextSpace(_currentSpace, amountOfSpacesToMove);
    }

    private void SetUpCommands()
    {
        _rollTheDiceCommand = new RollTheDiceCommand();
    }
}

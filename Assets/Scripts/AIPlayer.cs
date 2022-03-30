using System;

public class AIPlayer : IPlayer
{
    private MovePlayerCommand _movePlayerCommand;
    private PlayCurrentSpaceCommand _playCurrentSpaceCommand;
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
        _movePlayerCommand.Execute(this);
        _playCurrentSpaceCommand.Execute(this);
        OnTurnFinish?.Invoke(); 
    }

    public void MovePlayerForward(int amountOfSpacesToMove)
    {
        _currentSpace = CurrentBoard.GetNextSpace(_currentSpace, amountOfSpacesToMove);
    }

    public void PlayCurrentSpace()
    {
        _currentSpace.Play();   
    }

    private void SetUpCommands()
    {
        _movePlayerCommand = new MovePlayerCommand();
        _playCurrentSpaceCommand = new PlayCurrentSpaceCommand();
    }
}

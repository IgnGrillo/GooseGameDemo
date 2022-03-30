public class MovePlayerCommand : ICommand
{
    public void Execute(IPlayer executer)
    {
        var diceNumber = Dice.RollDice();
        diceNumber = 1; //The exercise requires to move a single space at a time
        executer.MovePlayerForward(diceNumber);
    }
}
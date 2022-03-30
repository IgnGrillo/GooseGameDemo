public class PlayCurrentSpaceCommand : ICommand
{
    public void Execute(IPlayer executer)
    {
        executer.PlayCurrentSpace();
    }
}
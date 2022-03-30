public interface ISpace
{
   int SpaceIndex { get; set; }
   IBoard Board { get; set; }
   ISpaceRule Rule { get; }
   string Play();
}

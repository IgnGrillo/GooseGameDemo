public interface ISpace
{
   int SpaceIndex { get; set; }
   IBoard Board { get; set; }
   string Play();
}

using Storage.Interfaces;

namespace Storage.Parameters;
internal class PalletParameters
{
    public int Id { get; }
    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }
    public List<IBox> Boxes { get; private set; }

    public PalletParameters(int id, double width, double height, double depth, List<IBox> boxes)
    {
        Id = id;
        Width = width;
        Height = height;
        Depth = depth;
        Boxes = boxes;
    }
}

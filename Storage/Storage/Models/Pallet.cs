using Storage.Interfaces;

namespace Storage.Models;
internal class Pallet : IPallet
{
    public int Id { get; private set; }

    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }
    public double Weight { get; }
    public double Volume { get; }

    public List<IBox> Boxes { get; private set; }

    public DateOnly ExpirationDate { get; private set; }

    public Pallet(int id, double width, double height, double depth, double weight, List<IBox> boxes)
    {
        Id = id;

        Width = width < 0 ? 0 : width;
        Height = height < 0 ? 0 : height;
        Depth = depth < 0 ? 0 : depth;
        Weight = weight < 0 ? 0 : weight;

        Boxes = boxes;

        foreach (var box in boxes)
        {
            Volume += box.Volume;
        }

        Volume += Width * Height * Depth;

        //What if Boxes.Count == 0?
        ExpirationDate = Boxes.Min(x => x.ExpirationDate);
    }
}

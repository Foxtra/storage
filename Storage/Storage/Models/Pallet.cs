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

    public Pallet(int id, double width, double height, double depth, List<IBox> boxes)
    {
        Id = id;

        Width = width < 0 ? 0 : width;
        Height = height < 0 ? 0 : height;
        Depth = depth < 0 ? 0 : depth;

        Boxes = boxes;

        foreach (var box in boxes)
        {
            Volume += box.Volume;
            Weight += box.Weight;
        }

        Volume += Width * Height * Depth;
        //TODO Move to parameters
        Weight += 30;


        //What if Boxes.Count == 0?
        ExpirationDate = Boxes.Min(x => x.ExpirationDate);
    }
}

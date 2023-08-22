using System.Text;
using Storage.Interfaces;
using Storage.Parameters;

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

    private readonly StorageParameters _storageParameters;

    public Pallet(PalletParameters palletParameters, StorageParameters storageParameters)
    {
        _storageParameters = storageParameters;
        Id = palletParameters.Id;

        Width = palletParameters.Width < 0 ? 0 : palletParameters.Width;
        Height = palletParameters.Width < 0 ? 0 : palletParameters.Width;
        Depth = palletParameters.Width < 0 ? 0 : palletParameters.Width;

        Boxes = palletParameters.Boxes;

        foreach (var box in Boxes)
        {
            Volume += box.Volume;
            Weight += box.Weight;
        }

        Volume += Width * Height * Depth;

        Weight += _storageParameters.PalletWeight;

        try
        {
            ExpirationDate = Boxes.Min(x => x.ExpirationDate);
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException($"Pallet with ID:{Id} has no Boxes", ex);
        }
    }

    public override string ToString()
    {
        var info = $"ID: {Id}; Width: {Width}; Height: {Height}; Depth: {Depth};" +
            $" Weight: {Weight:f1}; Volume: {Volume:f1}; ExpirationDate: {ExpirationDate:d}; Boxes: [ ";

        var stringBuilder = new StringBuilder(info);
        for (var i = 0; i < Boxes.Count; i++)
        {
            stringBuilder.Append(Boxes[i].ToString());
        }
        stringBuilder.Append(" ]");

        return stringBuilder.ToString();
    }
}

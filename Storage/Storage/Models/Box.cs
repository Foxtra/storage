using Storage.Interfaces;
using Storage.Parameters;

namespace Storage.Models;
internal class Box : IBox
{
    public int Id { get; private set; }
    public int? PalletId { get; private set; }

    public double Width { get; private set; }

    public double Height { get; private set; }

    public double Depth { get; private set; }

    public double Weight { get; private set; }

    public double Volume { get; private set; }

    public DateOnly? ProductionDate { get; private set; }

    public DateOnly ExpirationDate { get; private set; }

    private readonly StorageParameters _storageParameters;

    public Box(BoxParameters boxParameters, StorageParameters storageParameters)
    {
        _storageParameters = storageParameters;

        Id = boxParameters.Id;
        PalletId = boxParameters.PalletId;

        Width = boxParameters.Width < 0 ? 0 : boxParameters.Width;
        Height = boxParameters.Width < 0 ? 0 : boxParameters.Width;
        Depth = boxParameters.Width < 0 ? 0 : boxParameters.Width;
        Weight = boxParameters.Width < 0 ? 0 : boxParameters.Width;

        Volume = Width * Height * Depth;

        if (boxParameters.ProductionDate != null)
        {
            ProductionDate = boxParameters.ProductionDate;
        }

        if (boxParameters.ExpirationDate != null)
        {
            ExpirationDate = (DateOnly)boxParameters.ExpirationDate;
        }
        else
        {
            try
            {
                ExpirationDate = ((DateOnly)ProductionDate).AddDays(_storageParameters.ExpirationDateDelta);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException($"The Box with id:{Id} must contain ProductionDate or ExpirationDate", ex);
            }
        }
    }

    public override string ToString()
    {
        return $"ID: {Id}; PalletId: {PalletId}; Width: {Width}; Height: {Height}; Depth: {Depth};" +
            $" Weight: {Weight:f1}; Volume: {Volume:f1}; ProductionDate: {ProductionDate}; ExpirationDate: {ExpirationDate:d}; ";
    }
}

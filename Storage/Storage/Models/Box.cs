using Storage.Interfaces;

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

    public Box(int id, int? palletId, int width, int height, int depth, int weight, DateOnly? productionDate, DateOnly? expirationDate)
    {
        Id = id;
        PalletId = palletId;

        Width = width < 0 ? 0 : width;
        Height = height < 0 ? 0 : height;
        Depth = depth < 0 ? 0 : depth;
        Weight = weight < 0 ? 0 : weight;

        Volume = Width * Height * Depth;

        if (productionDate != null)
        {
            ProductionDate = productionDate;
        }

        if (expirationDate != null)
        {
            ExpirationDate = (DateOnly)expirationDate;
        }
        else
        {
            //TODO move to parameters or const
            try
            {
                ExpirationDate = ((DateOnly)ProductionDate).AddDays(100);
            }
            catch (NullReferenceException ex)
            {
                //TODO add OutputProvider
                Console.WriteLine($"The Box with id:{Id} must contain ProductionDate or ExpirationDate");
                Console.WriteLine(ex.Message);
            }
        }
    }

    public void SetPalletId(int id) => PalletId = id;
}

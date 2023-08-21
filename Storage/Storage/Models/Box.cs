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

    private readonly IOutput _output;

    //TODO Create ParamClass
    public Box(int id, int? palletId, double width, double height, double depth, double weight, DateOnly? productionDate, DateOnly? expirationDate, IOutput OutputService)
    {
        _output = OutputService;

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
                _output.WriteString($"The Box with id:{Id} must contain ProductionDate or ExpirationDate");
                _output.WriteString(ex.Message);
            }
        }
    }

    public void SetPalletId(int id) => PalletId = id;

    public override string ToString()
    {
        return $"ID: {Id}; PalletId: {PalletId}; Width: {Width}; Height: {Height}; Depth: {Depth};" +
            $" Weight: {Weight:f1}; Volume: {Volume:f1}; ProductionDate: {ProductionDate}; ExpirationDate: {ExpirationDate:d}; ";
    }
}

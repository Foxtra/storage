namespace Storage.Parameters;
internal class BoxParameters
{
    public int Id { get; }
    public int? PalletId { get; }
    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }
    public double Weight { get; }
    public DateOnly? ProductionDate { get; }
    public DateOnly? ExpirationDate { get; }

    public BoxParameters(int id, int? palletId, double width, double height, double depth, double weight, DateOnly? productionDate, DateOnly? expirationDate)
    {
        Id = id;
        PalletId = palletId;
        Width = width;
        Height = height;
        Depth = depth;
        Weight = weight;
        ProductionDate = productionDate;
        ExpirationDate = expirationDate;
    }
}

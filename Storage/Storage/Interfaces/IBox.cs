namespace Storage.Interfaces;
internal interface IBox
{
    public int Id { get; }
    public int? PalletId { get; }
    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }
    public double Weight { get; }
    public double Volume { get; }
    public DateOnly? ProductionDate { get; }
    public DateOnly ExpirationDate { get; }

    public void SetPalletId(int id);
}

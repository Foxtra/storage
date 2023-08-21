namespace Storage.Interfaces;
internal interface IPallet
{
    public int Id { get; }
    public double Width { get; }
    public double Height { get; }
    public double Depth { get; }
    public double Weight { get; }
    public double Volume { get; }
    public List<IBox> Boxes { get; }
    public DateOnly ExpirationDate { get; }
}

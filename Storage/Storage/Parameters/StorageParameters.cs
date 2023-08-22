namespace Storage.Parameters;
internal class StorageParameters
{
    public int ExpirationDateDelta { get; set; }
    public int PalletWeight { get; set; }
    public int NumberOfPallets { get; set; }
    public int NumberOfBoxes { get; set; }
    public int MaxPalletWidth { get; set; }
    public int MaxPalletHeight { get; set; }
    public int MaxPalletDepth { get; set; }
    public int MaxBoxWidth { get; set; }
    public int MaxBoxHeight { get; set; }
    public int MaxBoxDepth { get; set; }
    public int MaxBoxWeight { get; set; }
    public DateTime StartDate { get; set; }
    public int TopThree { get; set; }
}

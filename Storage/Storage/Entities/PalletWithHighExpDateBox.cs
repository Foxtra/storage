using Storage.Interfaces;

namespace Storage.Entities;
internal class PalletWithHighExpDateBox
{
    public IPallet Pallet { get; set; }

    public override string ToString()
    {
        var info = $"ID: {Pallet.Id}; Volume: {Pallet.Volume:f4}; Box's Exp Date: {Pallet.Boxes.Max(x => x.ExpirationDate):d}";

        return info;
    }
}

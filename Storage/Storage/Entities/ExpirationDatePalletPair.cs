using System.Text;
using Storage.Interfaces;

namespace Storage.Entities;
internal class ExpirationDatePalletPair
{
    public DateOnly ExpirationDate { get; set; }
    public IOrderedEnumerable<IPallet> Pallet { get; set; }

    public override string ToString()
    {
        var info = $"ExpirationDate: {ExpirationDate}, Pallets: [ ";

        var stringBuilder = new StringBuilder(info);
        foreach (var p in Pallet)
        {
            stringBuilder.Append($"ID: {p.Id}, Weight: {p.Weight:f1}; ");
        }
        stringBuilder.Append("]");

        return stringBuilder.ToString();
    }
}

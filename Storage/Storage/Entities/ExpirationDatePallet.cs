using Storage.Interfaces;

namespace Storage.Entities;
internal class ExpirationDatePallet
{
    public DateOnly ExpirationDate { get; set; }
    public IOrderedEnumerable<IPallet> Pallet { get; set; }
}

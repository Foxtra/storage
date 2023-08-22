using Storage.Entities;
using Storage.Interfaces;

namespace Storage.Services;
internal class SortingService : ISortingService
{
    public List<ExpirationDatePalletPair> GroupByExpDateSortByItSortByWeight(List<IPallet> pallets)
    {
        var result = pallets
            .GroupBy(p => p.ExpirationDate)
            .Select(group =>
                        new {
                            ExpirationDate = group.Key,
                            Pallets = group.OrderBy(x => x.Weight)
                        })
                  .OrderBy(group => group.ExpirationDate)
                  .Select(x => new ExpirationDatePalletPair { ExpirationDate = x.ExpirationDate, Pallet = x.Pallets })
                  .ToList();

        return result;
    }

    public List<PalletWithHighExpDateBox> TopPalletsSortByBoxExpDateSortByPalletVolume(int topNumber, List<IPallet> pallets)
    {
        DateOnly maxExpirationDate;
        try
        {
            maxExpirationDate = pallets.Max(p => p.Boxes.Max(b => b.ExpirationDate));
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException($"No Pallets", ex);
        }

        var result = pallets
            .FindAll(pallet => pallet.Boxes.Any(b => b.ExpirationDate == maxExpirationDate))
            .OrderBy(pallet => pallet.Volume)
            .Select(x => new PalletWithHighExpDateBox { Pallet = x })
            .Take(topNumber)
            .ToList();

        return result;
    }
}

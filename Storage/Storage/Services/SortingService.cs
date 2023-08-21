using Storage.Entities;
using Storage.Interfaces;

namespace Storage.Services;
internal class SortingService : ISortingService
{
    public List<ExpirationDatePallet> GroupByExpDateSortByItSortByWeight(List<IPallet> pallets)
    {
        var result = pallets
            .GroupBy(p => p.ExpirationDate)
            .Select(group =>
                        new {
                            ExpirationDate = group.Key,
                            Pallets = group.OrderByDescending(x => x.Weight)
                        })
                  .OrderBy(group => group.ExpirationDate)
                  .Select(x => new ExpirationDatePallet { ExpirationDate = x.ExpirationDate, Pallet = x.Pallets })
                  .ToList();

        return result;
    }

    public List<IPallet> TopPalletsSortByBoxExpDateSortByPalletVolume(int topNumber, List<IPallet> pallets)
    {
        var result = pallets
            .OrderBy(pallet => pallet.Boxes.Max(b => b.ExpirationDate))
            .OrderBy(pallet => pallet.Volume)
            .Take(topNumber)
            .ToList();

        return result;
    }
}

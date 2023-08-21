using Storage.Entities;

namespace Storage.Interfaces;
internal interface ISortingService
{
    public List<ExpirationDatePallet> GroupByExpDateSortByItSortByWeight(List<IPallet> pallets);

    public List<IPallet> TopPalletsSortByBoxExpDateSortByPalletVolume(int topNumber, List<IPallet> pallets);
}

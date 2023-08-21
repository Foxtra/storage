using Storage.Entities;

namespace Storage.Interfaces;
internal interface ISortingService
{
    public List<ExpirationDatePallet> GroupByExpDateSortByItSortByWeight();

    public List<IPallet> TopPalletsSortByBoxExpDateSortByPalletVolume(int topNumber);
}

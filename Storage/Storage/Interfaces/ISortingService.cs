using Storage.Entities;

namespace Storage.Interfaces;
internal interface ISortingService
{
    public List<ExpirationDatePalletPair> GroupByExpDateSortByItSortByWeight(List<IPallet> pallets);

    public List<PalletWithHighExpDateBox> TopPalletsSortByBoxExpDateSortByPalletVolume(int topNumber, List<IPallet> pallets);
}

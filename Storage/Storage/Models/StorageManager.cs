using Storage.Interfaces;

namespace Storage.Models;
internal class StorageManager
{
    private readonly IDataGenerationService _dataGenerationService;
    private readonly ISortingService _sortingService;
    private readonly IOutput _outputService;

    public StorageManager(IDataGenerationService dataGenerationService, ISortingService sortingService, IOutput outputService)
    {
        _dataGenerationService = dataGenerationService;
        _sortingService = sortingService;
        _outputService = outputService;
    }

    public void Run()
    {
        List<IPallet> data = _dataGenerationService.GeneratePallets();

        var firstSortingGroup = _sortingService.GroupByExpDateSortByItSortByWeight(data);

        //TODO use consts
        var secondSortingGroup = _sortingService.TopPalletsSortByBoxExpDateSortByPalletVolume(3, data);

        _outputService.WriteString("Group all pallets by expiration date, sort by expiration date, in each group sort pallets by weight:");
        _outputService.WriteEmptyLine();
        _outputService.WriteList(firstSortingGroup);
        _outputService.WriteEmptyLine();
        _outputService.WriteString("3 pallets that contain the boxes with the highest expiration date, sorted by volume:");
        _outputService.WriteEmptyLine();
        _outputService.WriteList(secondSortingGroup);
        _outputService.WriteEmptyLine();
    }
}

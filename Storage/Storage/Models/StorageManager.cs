using Storage.Entities;
using Storage.Interfaces;
using Storage.Parameters;

namespace Storage.Models;
internal class StorageManager
{
    private readonly IDataGenerationService _dataGenerationService;
    private readonly ISortingService _sortingService;
    private readonly IOutput _outputService;
    private readonly IStorageParametersProvider _parametersProvider;
    private readonly StorageParameters _storageParameters;

    public StorageManager(IDataGenerationService dataGenerationService, ISortingService sortingService, IOutput outputService, IStorageParametersProvider parametersProvider)
    {
        _dataGenerationService = dataGenerationService;
        _sortingService = sortingService;
        _outputService = outputService;
        _parametersProvider = parametersProvider;
        _storageParameters = _parametersProvider.GetParameters();
    }

    public void Run()
    {
        List<IPallet> data = _dataGenerationService.GeneratePallets();

        List<ExpirationDatePalletPair> firstSortingGroup = _sortingService.GroupByExpDateSortByItSortByWeight(data);

        List<PalletWithHighExpDateBox> secondSortingGroup = _sortingService.TopPalletsSortByBoxExpDateSortByPalletVolume(_storageParameters.TopThree, data);

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

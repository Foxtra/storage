using Storage.Interfaces;
using Storage.Models;
using Storage.Parameters;

namespace Storage.Services;
internal class DataGenerationService : IDataGenerationService
{
    private readonly Random _random;
    private readonly StorageParameters _storageParameters;

    public DataGenerationService(IStorageParametersProvider parametersProvider)
    {
        _random = new Random();
        _storageParameters = parametersProvider.GetParameters();
    }

    public List<IPallet> GeneratePallets()
    {
        var Pallets = new List<IPallet>();

        for (int i = 0; i < _storageParameters.NumberOfPallets; i++)
        {
            Pallets.Add(GeneratePallet(i));
        }

        return Pallets;
    }

    private IPallet GeneratePallet(int id)
    {
        double width = _random.NextDouble() * _storageParameters.MaxPalletWidth;
        double height = _random.NextDouble() * _storageParameters.MaxPalletHeight;
        double depth = _random.NextDouble() * _storageParameters.MaxPalletDepth;

        var boxes = new List<IBox>();
        for (int i = 0; i < _storageParameters.NumberOfBoxes; i++)
        {
            boxes.Add(GenerateBox(id: i, palletId: id, width, depth));
        }

        PalletParameters palletParameters = new PalletParameters(id, width, height, depth, boxes);

        IPallet pallet = new Pallet(palletParameters, _storageParameters);

        return pallet;
    }

    private IBox GenerateBox(int id, int palletId, double maxWidth, double maxDepth)
    {
        double width;
        do
        {
            width = _random.NextDouble() * _storageParameters.MaxBoxWidth;
        } while (width > maxWidth);

        double depth;
        do
        {
            depth = _random.NextDouble() * _storageParameters.MaxBoxDepth;
        } while (depth > maxDepth);

        double height = _random.NextDouble() * _storageParameters.MaxBoxHeight;
        double weight = _random.NextDouble() * _storageParameters.MaxBoxWeight;

        DateOnly? productionDate = null;
        DateOnly? expirationDate = null;

        if (_random.Next(2) == 1)
        {
            productionDate = GenerateDate();
        }
        else
        {
            expirationDate = GenerateDate();
        }

        BoxParameters boxParameters = new BoxParameters(id, palletId, width, height, depth, weight, productionDate, expirationDate);

        IBox box = new Box(boxParameters, _storageParameters);

        return box;
    }

    private DateOnly GenerateDate()
    {
        DateTime start = _storageParameters.StartDate;
        int range = (DateTime.Today - start).Days;
        var newDate = start.AddDays(_random.Next(range));
        return DateOnly.FromDateTime(newDate);
    }
}

using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services;
internal class DataGenerationService : IDataGenerationService
{
    private readonly Random _random;
    private readonly IOutput _outputService;

    public DataGenerationService(IOutput outputService)
    {
        _random = new Random();
        _outputService = outputService;
    }

    public List<IPallet> GeneratePallets()
    {
        List<IPallet> Pallets = new List<IPallet>();
        //TODO use consts
        for (int i = 0; i < 5; i++)
        {
            Pallets.Add(GeneratePallet(i));
        }

        return Pallets;
    }

    private IPallet GeneratePallet(int id)
    {
        //TODO use consts
        double width = _random.NextDouble() * 100;
        double height = _random.NextDouble() * 100;
        double depth = _random.NextDouble() * 100;

        List<IBox> boxes = new List<IBox>();
        //TODO use consts
        for (int i = 0; i < 5; i++)
        {
            boxes.Add(GenerateBox(id: i, palletId: id));
        }

        IPallet pallet = new Pallet(id, width, height, depth, boxes);

        return pallet;
    }

    private IBox GenerateBox(int id, int palletId)
    {
        //TODO use consts
        double width = _random.NextDouble() * 100;
        double height = _random.NextDouble() * 100;
        double depth = _random.NextDouble() * 100;
        double weight = _random.NextDouble() * 100;

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

        IBox box = new Box(id, palletId, width, height, depth, weight, productionDate, expirationDate, _outputService);

        return box;
    }

    private DateOnly GenerateDate()
    {
        //TODO use consts
        DateTime start = new DateTime(2023, 4, 5);
        int range = (DateTime.Today - start).Days;
        start.AddDays(_random.Next(range));
        return DateOnly.FromDateTime(start);
    }
}

using Storage.Interfaces;
using Storage.Models;
using Storage.Services;

namespace Storage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOutput outputService = new ConsoleOutputService();
            IDataGenerationService dataGenerationService = new DataGenerationService(outputService);
            ISortingService sortingService = new SortingService();

            var storageManager = new StorageManager(dataGenerationService, sortingService, outputService);

            storageManager.Run();
        }
    }
}

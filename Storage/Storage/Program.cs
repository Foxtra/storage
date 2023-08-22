using Storage.Interfaces;
using Storage.Models;
using Storage.Services;

namespace Storage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStorageParametersProvider parametersProvider = new StorageParametersProvider();
            IDataGenerationService dataGenerationService = new DataGenerationService(parametersProvider);
            ISortingService sortingService = new SortingService();
            IOutput outputService = new ConsoleOutputService();

            var storageManager = new StorageManager(dataGenerationService, sortingService, outputService, parametersProvider);

            storageManager.Run();
        }
    }
}

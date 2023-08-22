using Newtonsoft.Json;
using Storage.Interfaces;
using Storage.Parameters;

namespace Storage.Services;
internal class StorageParametersProvider : IStorageParametersProvider
{
    public StorageParameters GetParameters()
    {
        var parametersFile = new FileInfo("Resources/parameters.json");

        if (!parametersFile.Exists)
        {
            throw new ArgumentException(
                $"Can't find parameters json file. Trying to find it here: {parametersFile.FullName}");
        }

        var textContent = File.ReadAllText(parametersFile.FullName);

        try
        {
            return JsonConvert.DeserializeObject<StorageParameters>(textContent);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Can't read storage parameters content", ex);
        }
    }
}

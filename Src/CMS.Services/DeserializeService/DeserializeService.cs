using System.Text.Json;
using CMS.Models.Models.CMSComponents;

namespace CMS.Services.DeserializeService
{
    public class DeserializeService : IDeserializeService
    {
        public Root DeserializeJsonFile(string jsonFilePath)
        {
            return JsonSerializer.Deserialize<Root>(File.ReadAllText(jsonFilePath), new JsonSerializerOptions{AllowTrailingCommas = true})!;
        }
    }
}

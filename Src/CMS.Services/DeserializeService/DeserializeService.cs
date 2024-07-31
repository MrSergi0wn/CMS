using System.Text.Json;
using CMS.Models.Models.CMSComponents;

namespace CMS.Services.DeserializeService
{
    public class DeserializeService : IDeserializeService
    {
        public CmsComponents DeserializeJsonFile(string jsonFilePath)
        {
            return JsonSerializer.Deserialize<CmsComponents>(File.ReadAllText(jsonFilePath), new JsonSerializerOptions{AllowTrailingCommas = true})!;
        }
    }
}

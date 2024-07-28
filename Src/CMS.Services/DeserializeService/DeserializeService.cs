using CMS.Models.Models.CMSComponents;
using Newtonsoft.Json;

namespace CMS.Services.DeserializeService
{
    public class DeserializeService : IDeserializeService
    {
        public IEnumerable<Template> DeserializeJsonFile(string jsonFilePath)
        {
            var qwe = JsonConvert.DeserializeObject<List<Template>>(File.ReadAllText(jsonFilePath))!;


            return qwe;

            //return (!string.IsNullOrEmpty(jsonFilePath) ? JsonConvert.DeserializeObject<Template>(File.ReadAllText(jsonFilePath))! : null)!; 
        }
    }
}

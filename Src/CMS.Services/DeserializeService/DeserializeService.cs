using CMS.Models.ViewModels;
using Newtonsoft.Json;

namespace CMS.Services.DeserializeService
{
    public class DeserializeService : IDeserializeService
    {
        public TemplateViewModel DeserializeJsonFile(string jsonFilePath)
        {
            return (!string.IsNullOrEmpty(jsonFilePath) ? JsonConvert.DeserializeObject<TemplateViewModel>(File.ReadAllText(jsonFilePath))! : null)!; 
            //todo Присрать суда FileManager и через BaseDirectory через относительный путь искать путь к файлу
        }
    }
}

using System.Text;

namespace CMS.Models.Models.CMSComponents
{
    public class ComponentModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string ComponentName { get; set; }

        /// <summary>
        /// Тип ("For Header", "For Body", "For Footer")
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Параметры
        /// </summary>
        public Dictionary<string, string> Properties { get; set; }

        /// <summary>
        /// Шаблон
        /// </summary>
        public string HtmlTemplate { get; set; }

        /// <summary>
        /// Конвертация из Base64 в Html разметку
        /// </summary>
        public string OuterHtml
        {
            get
            {
                if (string.IsNullOrEmpty(this.HtmlTemplate) || this.Properties == null) return string.Empty;

                var stringBuilder =
                    new StringBuilder(Encoding.UTF8.GetString(Convert.FromBase64String(this.HtmlTemplate)));

                foreach (var property in this.Properties)
                {
                    stringBuilder.Replace(property.Key, property.Value);
                }

                return stringBuilder.ToString();
            }
        }
    }
}
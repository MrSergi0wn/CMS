namespace CMS.Models.Models.CMSComponents
{
    public class ComponentModel
    {
        //public ComponentModel()
        //{
        //}

        public string ComponentId { get; set; }

        public string Type { get; set; }

        public Dictionary<string, string> Properties { get; set; }

        public string HtmlTemplate { get; set; }

        public string OuterHtml { get; set; }
        //{
        //    get => this.OuterHtml;
        //    set
        //    {
        //        return (() =>
        //        {
        //            foreach (var property in Properties)
        //            {
        //                this.HtmlTemplate.Replace(property.Key, property.Value);
        //            }
        //        };
        //    }
        //}
    }
}
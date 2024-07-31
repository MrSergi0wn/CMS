namespace CMS.Models.Models.CMSComponents
{
    public class Root
    {
        public string SelectedHeaderID { get; set; }

        public string SelectedBodyID { get; set; }

        public string SelectedFooterID { get; set; }

        public List<ComponentModel> Components { get; set; }
    }
}

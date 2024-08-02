namespace CMS.Models.Models.CMSComponents
{
    public class HomeViewModel
    {
        public string SelectedHeader { get; set; }

        public string SelectedBody { get; set; }

        public string SelectedFooter { get; set; }

        public IEnumerable<BuilderViewModel> BuilderViewModels { get; set; }
    }
}

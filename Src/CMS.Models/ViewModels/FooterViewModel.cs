namespace CMS.Models.ViewModels
{
    public class FooterViewModel : IViewComponent
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Class { get; set; }

        public int Width { get; set; }
    }
}

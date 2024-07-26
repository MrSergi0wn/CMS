namespace CMS.Models.ViewModels
{
    public class HeaderViewModel : IViewComponent
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Class { get; set; }
    }
}

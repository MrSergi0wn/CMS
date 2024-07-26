namespace CMS.Models.ViewModels
{
    public class BodyViewModel : IViewComponent
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Class { get; set; }

        public string? ContentColor { get; set; }
    }
}

namespace CMS.Models.ViewModels
{
    public class TemplateViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<IViewComponent>? HeaderComponent { get; set; }

        public List<IViewComponent>? BodyComponent { get; set; }

        public List<IViewComponent>? FooterComponent { get; set; }
    }
}

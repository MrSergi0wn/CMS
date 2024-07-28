namespace CMS.Models.Models.CMSComponents
{
    public class Template
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Components> Conponents { get; set; }
    }
}

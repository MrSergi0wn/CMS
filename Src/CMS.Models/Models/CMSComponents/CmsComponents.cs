namespace CMS.Models.Models.CMSComponents
{
    public class CmsComponents
    {
        public List<Header>? Headers { get; set; }

        public int SelectedHeaderId { get; set; }

        public List<Body>? Bodies { get; set; }

        public int SelectedBodyId { get; set; }

        public List<Footer>? Footers { get; set; }

        public int SelectedFooterId { get; set; }
    }
}

namespace CMS.Models.Models.CMSComponents
{
    public class BuilderViewModel
    {
        public BuilderViewModel(ComponentModel deserializedComponent)
        {
            this.ComponentName = deserializedComponent.ComponentName;
            this.CurrentColor = deserializedComponent.Properties["rep_color"];
            this.OuterHtml = deserializedComponent.OuterHtml;
        }

        public string ComponentName { get; set; }

        public string CurrentColor { get; set; }
        
        public string OuterHtml { get; set; }
    }
}

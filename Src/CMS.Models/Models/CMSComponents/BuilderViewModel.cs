using CMS.Domain;

namespace CMS.Models.Models.CMSComponents
{
    public class BuilderViewModel
    {
        public BuilderViewModel(ComponentModel deserializedComponent)
        {
            this.ComponentName = deserializedComponent.ComponentName;
            this.ComponentTag = deserializedComponent.Properties["rep_tag"];
            this.ComponentColor = deserializedComponent.Properties["rep_color"];
            this.ComponentClass = deserializedComponent.Properties["rep_class"];
            this.OuterHtml = deserializedComponent.OuterHtml;
        }

        public string ComponentName { get; set; }

        public string ComponentTag { get; set; }

        public string ComponentColor { get; set; }

        public string ComponentClass { get; set; }
        
        public string OuterHtml { get; set; }
    }
}

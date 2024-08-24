using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructe.TagHelpers
{
    [HtmlTargetElement("table")]
    public class TableTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "table table-hover");
            //RazorPage lerde tanımlanan <table> etiketlerinin classını table table-hover yaptık.
            //<table class="table table-hover"> yazmamıza gerek kalmadı
        }
    }
}
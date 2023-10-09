using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.TagHelpers
{
    public class CustomButtonTagHelper : TagHelper
    {
        public string? Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            output.Content.SetContent(string.IsNullOrEmpty(Text) ? "Create" : Text);
            if(!string.IsNullOrEmpty(Text) && Text.Equals("Delete"))
            {
				output.Attributes.SetAttribute("class", "btn btn-danger");
			}
            else
            {
				output.Attributes.SetAttribute("class", "btn btn-primary");
			}
			
		}
    }
}

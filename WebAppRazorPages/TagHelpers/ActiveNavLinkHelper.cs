using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebAppRazorPages.TagHelpers
{
    [HtmlTargetElement("li", Attributes="asp-page-name")]
    public class ActiveNavLinkHelper : TagHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        
        public ActiveNavLinkHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HtmlAttributeName("asp-page-name")]
        public string PageName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var currentPath = _contextAccessor.HttpContext.Request.Path;
            if(currentPath.HasValue && currentPath.Value.Contains(PageName, StringComparison.OrdinalIgnoreCase))
            {
                var classAttr = output.Attributes.FirstOrDefault(c => c.Name == "class");
                if (classAttr == null)
                {
                    output.Attributes.Add("class", "active");
                }
                else
                {
                    var newClass = classAttr.Value== null? "active": classAttr.Value+" active";
                    output.Attributes.SetAttribute("class", newClass);
                }
            }
        }
    }
}

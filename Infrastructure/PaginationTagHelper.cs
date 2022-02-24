using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission8.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//class to allow pagination, dynamically build navigation links 

namespace Mission8.Models.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-num")]
    public class PaginationTagHelpers : TagHelper
    {
        private IUrlHelperFactory Uhf;

        public PaginationTagHelpers(IUrlHelperFactory temp)
        {
            Uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext Vc { get; set; }


        //Different from View Context:
        public PageInfo PageNum { get; set; }
        public string PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }


        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = Uhf.GetUrlHelper(Vc);
            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageNum.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageNum.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tb.AddCssClass(PageClass);
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}

#pragma checksum "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\Home\News.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f6e481097250aa928453c485ebb690f67abdb2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_News), @"mvc.1.0.view", @"/Views/Home/News.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/News.cshtml", typeof(AspNetCore.Views_Home_News))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\_ViewImports.cshtml"
using Asp_Final;

#line default
#line hidden
#line 2 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\_ViewImports.cshtml"
using Asp_Final.Models;

#line default
#line hidden
#line 4 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\_ViewImports.cshtml"
using Asp_Final.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f6e481097250aa928453c485ebb690f67abdb2b", @"/Views/Home/News.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1e1467693a232b07bf45fa3078607e213337594", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_News : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<News>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\Home\News.cshtml"
  
    ViewData["Title"] = "News";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(114, 89, true);
            WriteLiteral("\r\n    <section class=\"wrapper\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n");
            EndContext();
#line 10 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\Home\News.cshtml"
             foreach(var info in Model)
            {

#line default
#line hidden
            BeginContext(259, 61, true);
            WriteLiteral("                <div class=\"col-4\">\r\n                    <h1>");
            EndContext();
            BeginContext(321, 10, false);
#line 13 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\Home\News.cshtml"
                   Write(info.Title);

#line default
#line hidden
            EndContext();
            BeginContext(331, 27, true);
            WriteLiteral("</h1>\r\n                    ");
            EndContext();
            BeginContext(358, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "51c13455d3c34176bbb7b8827c655b3b", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 386, "~/img/", 386, 6, true);
#line 14 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\Home\News.cshtml"
AddHtmlAttributeValue("", 392, info.PhotoUrl, 392, 14, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(410, 25, true);
            WriteLiteral("\r\n                    <p>");
            EndContext();
            BeginContext(436, 9, false);
#line 15 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\Home\News.cshtml"
                  Write(info.Info);

#line default
#line hidden
            EndContext();
            BeginContext(445, 30, true);
            WriteLiteral("</p>\r\n                </div>\r\n");
            EndContext();
#line 17 "C:\Users\code\Desktop\Asp_Final_Project\Asp_Final\Asp_Final\Views\Home\News.cshtml"
            }

#line default
#line hidden
            BeginContext(490, 46, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    </section>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<News>> Html { get; private set; }
    }
}
#pragma warning restore 1591
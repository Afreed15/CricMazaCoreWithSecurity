#pragma checksum "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1872c9ccd9c071d7a7ff7492482b30451e1f51d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlayerProfiles_Details), @"mvc.1.0.view", @"/Views/PlayerProfiles/Details.cshtml")]
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
#nullable restore
#line 1 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\_ViewImports.cshtml"
using WebApplication28;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\_ViewImports.cshtml"
using WebApplication28.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1872c9ccd9c071d7a7ff7492482b30451e1f51d5", @"/Views/PlayerProfiles/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4234da03e4883c1f6f8d2e03697028fe6b4c7a1", @"/Views/_ViewImports.cshtml")]
    public class Views_PlayerProfiles_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication28.Models.PlayerProfile>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Players", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml"
  
    ViewData["Title"] = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n<h4>PlayerProfile</h4>\r\n<hr />\r\n<div class=\"display: block; margin-left: auto;margin-right: auto;width: 50%;\">\r\n    <h1 class=\"text-center text-white bg-dark\">");
#nullable restore
#line 13 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml"
                                          Write(Html.DisplayFor(model => model.P.Tplayer));

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;&nbsp;&nbsp; Profile</h1>\r\n</div>\r\n<ul style=\"list-style-type:none;display: block; margin-left: 500px;margin-right: 500px;width: 50%;\">\r\n\r\n    <li><img");
            BeginWriteAttribute("src", " src=\"", 450, "\"", 481, 1);
#nullable restore
#line 17 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml"
WriteAttributeValue("", 456, "/Images/"+Model.P.Img, 456, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"250\" width=\"300\" /></li>\r\n\r\n\r\n\r\n    <li><b class=\"text-danger\">Country :&nbsp;&nbsp;");
#nullable restore
#line 21 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml"
                                               Write(Html.DisplayFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></li>\r\n\r\n    <li><b class=\"text-danger\">IPL Team :&nbsp;&nbsp; ");
#nullable restore
#line 23 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml"
                                                 Write(Html.DisplayFor(model => model.T.Tname));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></li>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n    <li> <b class=\"text-danger\">Role :&nbsp;&nbsp;  ");
#nullable restore
#line 32 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml"
                                               Write(Html.DisplayFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></li>\r\n\r\n    <li><b class=\"text-danger\"> Highest Score :&nbsp;&nbsp;  ");
#nullable restore
#line 34 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml"
                                                        Write(Html.DisplayFor(model => model.HighestScore));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></li>\r\n\r\n    <li><b class=\"text-danger\">Best Bowling :&nbsp;&nbsp;  ");
#nullable restore
#line 36 "C:\Users\DELL\Desktop\mvccoreproject\mvcsecurity\Views\PlayerProfiles\Details.cshtml"
                                                      Write(Html.DisplayFor(model => model.BestBowling));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></li>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n</ul>\r\n\r\n\r\n<div>\r\n   \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1872c9ccd9c071d7a7ff7492482b30451e1f51d57022", async() => {
                WriteLiteral(" Back to players profile ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1872c9ccd9c071d7a7ff7492482b30451e1f51d58200", async() => {
                WriteLiteral("Back to players ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication28.Models.PlayerProfile> Html { get; private set; }
    }
}
#pragma warning restore 1591

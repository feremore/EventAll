#pragma checksum "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\Staff\Remove.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a782e9ebf71e1011f287c6f1f70f46796d62a2d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Staff_Remove), @"mvc.1.0.view", @"/Views/Staff/Remove.cshtml")]
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
#line 1 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\_ViewImports.cshtml"
using EventAll;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\_ViewImports.cshtml"
using EventAll.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a782e9ebf71e1011f287c6f1f70f46796d62a2d1", @"/Views/Staff/Remove.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a680206b3831c8a2e439025b9431146ff09bc75f", @"/Views/_ViewImports.cshtml")]
    public class Views_Staff_Remove : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>");
#nullable restore
#line 1 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\Staff\Remove.cshtml"
Write(ViewBag.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a782e9ebf71e1011f287c6f1f70f46796d62a2d13735", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\Staff\Remove.cshtml"
     foreach (var venue in ViewBag.venues)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <input type=\"checkbox\" name=\"venueIds\"");
                BeginWriteAttribute("id", " id=\"", 146, "\"", 160, 1);
#nullable restore
#line 6 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\Staff\Remove.cshtml"
WriteAttributeValue("", 151, venue.ID, 151, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 161, "\"", 178, 1);
#nullable restore
#line 6 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\Staff\Remove.cshtml"
WriteAttributeValue("", 169, venue.ID, 169, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <label");
                BeginWriteAttribute("for", " for=\"", 198, "\"", 213, 1);
#nullable restore
#line 7 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\Staff\Remove.cshtml"
WriteAttributeValue("", 204, venue.ID, 204, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 7 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\Staff\Remove.cshtml"
                          Write(venue.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n        <br />\r\n");
#nullable restore
#line 9 "C:\Users\Kloew\codecamp\EventAll\EventAllApp\EventAll\Views\Staff\Remove.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <input type=\"submit\" value=\"Remove Selected Venue(s)\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

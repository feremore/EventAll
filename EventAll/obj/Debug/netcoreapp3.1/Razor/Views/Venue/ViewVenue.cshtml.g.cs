#pragma checksum "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adde1c3aaa1565f6886e76e5f14abeb0cc11d975"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Venue_ViewVenue), @"mvc.1.0.view", @"/Views/Venue/ViewVenue.cshtml")]
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
#line 1 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\_ViewImports.cshtml"
using EventAll;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\_ViewImports.cshtml"
using EventAll.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adde1c3aaa1565f6886e76e5f14abeb0cc11d975", @"/Views/Venue/ViewVenue.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a680206b3831c8a2e439025b9431146ff09bc75f", @"/Views/_ViewImports.cshtml")]
    public class Views_Venue_ViewVenue : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EventAll.ViewModels.ViewVenueViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Event", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ViewEvent", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n<div class=\"container\">\r\n\r\n    <div class=\"row\" style=\"margin-bottom:15px;\">\r\n        <h1>");
#nullable restore
#line 11 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml"
       Write(Model.Venue.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(":</h1>\r\n        <div class=\"col-6\">\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <td>Capacity</td>\r\n                    <td>Price</td>\r\n                </tr>\r\n                <tr>\r\n\r\n                    <td>");
#nullable restore
#line 20 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml"
                   Write(Model.Venue.Capacity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>$");
#nullable restore
#line 21 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml"
                    Write(Model.Venue.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                </tr>
            </table>


        </div>
        <div class=""col-6"">
            <h2>List of Events:</h2>
            <table class=""table"">

                <tr>
                    <th>Name of Event</th>
                   
                    <th>Date</th>
                </tr>

");
#nullable restore
#line 37 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml"
                 foreach (var even in Model.Events)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "adde1c3aaa1565f6886e76e5f14abeb0cc11d9755504", async() => {
#nullable restore
#line 40 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml"
                                                                                                Write(even.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml"
                                                                               WriteLiteral(even.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>                        \r\n                        <td>");
#nullable restore
#line 41 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml"
                       Write(even.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 43 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Venue\ViewVenue.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </div>\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EventAll.ViewModels.ViewVenueViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

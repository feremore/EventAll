#pragma checksum "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9d2414505bb1236dda2b834e890bd7bc663d6f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Event_RemoveEquipment), @"mvc.1.0.view", @"/Views/Event/RemoveEquipment.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b9d2414505bb1236dda2b834e890bd7bc663d6f9", @"/Views/Event/RemoveEquipment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a680206b3831c8a2e439025b9431146ff09bc75f", @"/Views/_ViewImports.cshtml")]
    public class Views_Event_RemoveEquipment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
#line 1 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
Write(ViewBag.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b9d2414505bb1236dda2b834e890bd7bc663d6f93789", async() => {
                WriteLiteral("\r\n    \r\n");
#nullable restore
#line 4 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
     foreach (var obj in ViewBag.objs)
    {
        

#line default
#line hidden
#nullable disable
                WriteLiteral("        <input type=\"checkbox\" name=\"objIds\"");
                BeginWriteAttribute("id", " id=\"", 154, "\"", 175, 1);
#nullable restore
#line 7 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
WriteAttributeValue("", 159, obj.EquipmentID, 159, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 176, "\"", 200, 1);
#nullable restore
#line 7 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
WriteAttributeValue("", 184, obj.EquipmentID, 184, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"EventID\"");
                BeginWriteAttribute("value", " value=\"", 249, "\"", 269, 1);
#nullable restore
#line 8 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
WriteAttributeValue("", 257, obj.EventID, 257, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <label");
                BeginWriteAttribute("for", " for=\"", 289, "\"", 311, 1);
#nullable restore
#line 9 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
WriteAttributeValue("", 295, obj.EquipmentID, 295, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 9 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
                                 Write(obj.Equipment.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n        <br />\r\n");
#nullable restore
#line 11 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <input type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 391, "\"", 431, 3);
                WriteAttributeValue("", 399, "Remove", 399, 6, true);
                WriteAttributeValue(" ", 405, "Selected", 406, 9, true);
#nullable restore
#line 13 "C:\Users\Kloew\Capstone\EventAll\EventAllApp\EventAll\Views\Event\RemoveEquipment.cshtml"
WriteAttributeValue(" ", 414, ViewBag.objName, 415, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
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

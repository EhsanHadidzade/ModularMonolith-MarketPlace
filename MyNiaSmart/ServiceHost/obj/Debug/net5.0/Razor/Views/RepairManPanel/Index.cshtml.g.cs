#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\RepairManPanel\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6119abe529fefaac6224bf97ad9d4cbf7ed5740e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RepairManPanel_Index), @"mvc.1.0.view", @"/Views/RepairManPanel/Index.cshtml")]
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
#line 1 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6119abe529fefaac6224bf97ad9d4cbf7ed5740e", @"/Views/RepairManPanel/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_RepairManPanel_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RepairWorkShopManagement.Application.Contracts.RepairManService.RepairManServiceViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\RepairManPanel\Index.cshtml"
  
    ViewData["Title"] = "پنل تعمیرات";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row page-titles mx-0"">
    <div class=""col-sm-6 p-md-0"">
        <div class=""welcome-text"">
            <h4>سلام، خوش آمدید</h4>
            <p class=""mb-0"">پنل تعمیرات</p>
        </div>
    </div>
    <div class=""col-sm-6 p-md-0 justify-content-sm-end mt-2 mt-sm-0 d-flex"">
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a href=""javascript:void(0)"">پنل ها </a></li>
            <li class=""breadcrumb-item active""><a href=""javascript:void(0)"">پنل تعمیرات </a></li>
        </ol>
    </div>
</div>

");
#nullable restore
#line 21 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\RepairManPanel\Index.cshtml"
 if (ViewData["message"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""alert alert-info alert-dismissible fade show"">
        <svg viewBox=""0 0 24 24"" width=""24"" height=""24"" stroke=""currentColor"" stroke-width=""2"" fill=""none"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""mr-2"">
            <circle cx=""12"" cy=""12"" r=""10""></circle>
            <line x1=""12"" y1=""16"" x2=""12"" y2=""12""></line>
            <line x1=""12"" y1=""8"" x2=""12.01"" y2=""8""></line>
        </svg>
        <strong>اطلاعات!</strong>
        ");
#nullable restore
#line 30 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\RepairManPanel\Index.cshtml"
   Write(ViewData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    </div>\r\n");
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\RepairManPanel\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div clas=\"row\">\r\n    <center>\r\n        <a href=\"/RepairManPanel/AddServiceToRepairManPanel\" class=\"btn btn-square btn-outline-primary\" style=\"width:80%\">افزودن محصول جدید</a>\r\n    </center>\r\n</div>\r\n<br />\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RepairWorkShopManagement.Application.Contracts.RepairManService.RepairManServiceViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

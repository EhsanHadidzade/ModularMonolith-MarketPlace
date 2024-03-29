#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0013e65d3a2353cf087a48992c60d3e515d4066"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_SystemService_Index), @"mvc.1.0.view", @"/Areas/Administrator/Views/SystemService/Index.cshtml")]
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
#line 1 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\_ViewImports.cshtml"
using ServiceHost.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
using _0_Framework.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0013e65d3a2353cf087a48992c60d3e515d4066", @"/Areas/Administrator/Views/SystemService/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administrator_Views_SystemService_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<RepairWorkShopManagement.Application.Contracts.SystemService.SystemServiceViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminTheme/vendor/global/global.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
  
    ViewData["Title"] = "مدیریت سرویس های سامانه";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- Custom Stylesheet -->
<link href=""/AdminTheme/vendor/datatables/css/jquery.dataTables.min.css"" rel=""stylesheet"">
<link href=""/AdminTheme/vendor/bootstrap-select/dist/css/bootstrap-select.min.css"" rel=""stylesheet"">


<div class=""row page-titles mx-0"">
    <div class=""col-sm-6 p-md-0"">
        <div class=""welcome-text"">
            <h4>سلام، خوش آمدید</h4>
        </div>
    </div>
    <div class=""col-sm-6 p-md-0 justify-content-sm-end mt-2 mt-sm-0 d-flex"">
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a href=""/administrator"">پنل مدیریت </a></li>
            <li class=""breadcrumb-item active""><a");
            BeginWriteAttribute("href", " href=\"", 836, "\"", 843, 0);
            EndWriteAttribute();
            WriteLiteral("> مدیریت سرویس های سامانه </a></li>\r\n        </ol>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 25 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
 if (ViewData["message"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-xl-12 col-xxl-12\">\r\n        <div class=\"card-body\">\r\n            <div class=\"alert alert-info solid alert-dismissible fade show\">\r\n                <strong></strong> ");
#nullable restore
#line 30 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                             Write(ViewData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 34 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-12"">

        <div class=""card"">

            <div class=""card-header"">
                <h4 class=""card-title"">لیست سرویس های سامانه </h4>
            </div>

            <div class=""card-body"">
                <button type=""button"" class=""btn btn-rounded btn-info"" onclick=""window.location.href ='/administrator/SystemService/Create'"">
                    <span class=""btn-icon-left text-info"">
                        <i class=""fa fa-plus color-info""></i>
                    </span>افزودن
                </button>
                <div class=""table-responsive"">
                    <table id=""example3"" class=""display"" style=""min-width: 845px"">
                        <thead>
                            <tr>
                                <th>عنوان سرویس</th>
                                <th> عنوان برند</th>
                                <th> عنوان مدل</th>
                                <th> عنوان نوع</th>
                                <th> عنو");
            WriteLiteral(@"ان نحوه استفاده</th>
                                <th>  مفدار گارانتی</th>
                                <th>مدت زمان انجام</th>
                                <th> قیمت پایه</th>
                                <th>سهم سامانه(درصد)</th>
                                <th>عملیات</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 67 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                             foreach (var service in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 70 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                   Write(service.ServiceTitleEngTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 71 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                   Write(service.BrandEngTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 72 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                   Write(service.ModelEngTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 73 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                   Write(service.TypeEngTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 74 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                   Write(service.UsageTypeEngTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <p>\r\n                                            ضمانت :\r\n");
#nullable restore
#line 78 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                             if (service.WarrantyTypeId == WarrantyTypeId.Hour)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"item\"> تا ");
#nullable restore
#line 80 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                                                  Write(service.WarrantyAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ساعت</span>\r\n");
#nullable restore
#line 81 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                             if (service.WarrantyTypeId == WarrantyTypeId.Day)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"item\"> تا ");
#nullable restore
#line 84 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                                                  Write(service.WarrantyAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" روز</span>\r\n");
#nullable restore
#line 85 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                             if (service.WarrantyTypeId == WarrantyTypeId.Mounth)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"item\"> تا ");
#nullable restore
#line 88 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                                                  Write(service.WarrantyAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ماه</span>\r\n");
#nullable restore
#line 89 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                             if (service.WarrantyTypeId == WarrantyTypeId.Year)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"item\"> تا ");
#nullable restore
#line 92 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                                                  Write(service.WarrantyAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" سال</span>\r\n");
#nullable restore
#line 93 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </p>\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 97 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                   Write(service.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 98 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                   Write(service.BaseFeePrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</td>\r\n                                    <td>");
#nullable restore
#line 99 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                                   Write(service.SystemSharePercent);

#line default
#line hidden
#nullable disable
            WriteLiteral(" %</td>\r\n                                    <td>\r\n                                        <div class=\"d-flex\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 4920, "\"", 4972, 2);
            WriteAttributeValue("", 4927, "/administrator/SystemService/Edit/", 4927, 34, true);
#nullable restore
#line 102 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
WriteAttributeValue("", 4961, service.Id, 4961, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary shadow btn-xs sharp mr-1""><i class=""fa fa-pencil""></i></a>
                                            <a href=""#"" class=""btn btn-danger shadow btn-xs sharp""><i class=""fa fa-trash""></i></a>
                                        </div>
                                    </td>

                                </tr>
");
#nullable restore
#line 108 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\SystemService\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<!--Scripts-->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0013e65d3a2353cf087a48992c60d3e515d406616329", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0013e65d3a2353cf087a48992c60d3e515d406617369", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!--Datatable JavaScript-->\r\n<script src=\"/AdminTheme/vendor/datatables/js/jquery.dataTables.min.js\"></script>\r\n<script src=\"/AdminTheme/js/plugins-init/datatables.init.js\"></script>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<RepairWorkShopManagement.Application.Contracts.SystemService.SystemServiceViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

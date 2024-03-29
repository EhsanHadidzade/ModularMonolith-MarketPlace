#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\MySetting\_RejectionReason.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b55335110be7f91bc01fcd88d7a2931bd8545126"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_MySetting__RejectionReason), @"mvc.1.0.view", @"/Areas/Administrator/Views/MySetting/_RejectionReason.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b55335110be7f91bc01fcd88d7a2931bd8545126", @"/Areas/Administrator/Views/MySetting/_RejectionReason.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administrator_Views_MySetting__RejectionReason : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AccountManagement.Application.Contract.RejectionReason.RejectionReasonViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\MySetting\_RejectionReason.cshtml"
  
        ViewData["Title"] = "مدیریت دلایل رد درخواست ارتقا حساب کاربری";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""card"">
            <div class=""card-header"">
                <button type=""button"" class=""btn btn-rounded btn-info"" onclick=""window.location.href ='#showmodal=/administrator/Mysetting/_RejectionReasonCreate'"">
                    <span class=""btn-icon-left text-info"">
                        <i class=""fa fa-plus color-info""></i>
                    </span>افزودن
                </button>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-responsive-md"">
                     <thead>
                            <tr>
                                <th>عنوان دلیل</th>
                                <th>عملیات</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 26 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\MySetting\_RejectionReason.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 29 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\MySetting\_RejectionReason.cshtml"
                                   Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <div class=\"d-flex\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 1414, "\"", 1486, 2);
            WriteAttributeValue("", 1421, "#showmodal=/administrator/MySetting/_RejectionReasonEdit/", 1421, 57, true);
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\MySetting\_RejectionReason.cshtml"
WriteAttributeValue("", 1478, item.Id, 1478, 8, false);

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
#line 37 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\MySetting\_RejectionReason.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AccountManagement.Application.Contract.RejectionReason.RejectionReasonViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

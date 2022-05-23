#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e51300b5ace16ac18df77871ed7768f947b84ec9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_UserCooperationRequest_Index), @"mvc.1.0.view", @"/Areas/Administrator/Views/UserCooperationRequest/Index.cshtml")]
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
#line 1 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
using AccountManagement.Application.Contract.UserCooperationRequest;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e51300b5ace16ac18df77871ed7768f947b84ec9", @"/Areas/Administrator/Views/UserCooperationRequest/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administrator_Views_UserCooperationRequest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<UserRequestedForCooperationViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
  
    ViewData["Title"] = "مدیریت درخواست های همکاری کاربران";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
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
            BeginWriteAttribute("href", " href=\"", 614, "\"", 621, 0);
            EndWriteAttribute();
            WriteLiteral(@"> مدیریت درخواست های همکاری کاربران </a></li>
        </ol>
    </div>
</div>


<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">لیست کاربرانی که درخواست همکاری داده اند </h4>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-responsive-sm"">
                        <thead>
                            <tr>
                                <th>نام و نام خانوادگی</th>
                                <th>تاریخ درخواست </th>
                                <th>وضعیت</th>
                                <th>عملیات</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 41 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
                             foreach (var user in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 44 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
                                   Write(user.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 45 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
                                   Write(user.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 47 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
                                         if(user.IsRecognizedByAdmin)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge light badge-success\">بررسی شده توسط ادمین </span>\r\n");
#nullable restore
#line 50 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span class=\"badge light badge-warning\">در انتظار بررسی </span>\r\n");
#nullable restore
#line 54 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n                                        <div class=\"d-flex\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 2462, "\"", 2555, 2);
            WriteAttributeValue("", 2469, "#showModal=/administrator/UserCooperationRequest/ShowAndSetRequestedRoles/", 2469, 74, true);
#nullable restore
#line 58 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
WriteAttributeValue("", 2543, user.UserId, 2543, 12, false);

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
#line 63 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<UserRequestedForCooperationViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a2232650ae475d211ae5d569b42f7249d237096"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SellerPanel_SellerTransition), @"mvc.1.0.view", @"/Views/SellerPanel/SellerTransition.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a2232650ae475d211ae5d569b42f7249d237096", @"/Views/SellerPanel/SellerTransition.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SellerPanel_SellerTransition : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.Transition.TransitionViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
  
    ViewData["Title"] = "مدیریت ارسالی های شما";

#line default
#line hidden
#nullable disable
            DefineSection("header", async() => {
                WriteLiteral("\r\n<!-- Datatable -->\r\n<link href=\"/MainTheme/vendor/datatables/css/jquery.dataTables.min.css\" rel=\"stylesheet\">\r\n");
            }
            );
            WriteLiteral(@"
<div class=""row page-titles mx-0"">
    <div class=""col-sm-6 p-md-0"">
        <div class=""welcome-text"">
            <h4>
                سلام، خوش آمدید
            </h4>
            <p class=""mb-0"">پنل فروشندگی</p>
        </div>
    </div>
    <div class=""col-sm-6 p-md-0 justify-content-sm-end mt-2 mt-sm-0 d-flex"">
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a href=""javascript:void(0)"">پنل ها </a></li>
            <li class=""breadcrumb-item ""><a href=""javascript:void(0)"">پنل فروشندگی </a></li>
            <li class=""breadcrumb-item active""><a href=""javascript:void(0)"">مدیریت ارسالی ها</a></li>
        </ol>
    </div>
</div>

");
#nullable restore
#line 28 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
 if (ViewData["message"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-xl-12 col-xxl-12\">\r\n        <div class=\"card-body\">\r\n            <div class=\"alert alert-success solid alert-dismissible fade show\">\r\n                <strong> ");
#nullable restore
#line 33 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                    Write(ViewData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </strong>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 37 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">مدیریت ارسالی ها</h4>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table id=""example4"" class=""display"" style=""min-width: 845px"">
                        <thead>
                            <tr>
                                <th>کد رهگیری</th>
                                <th>تاریخ ایجاد</th>
                                <th> نام دریافت کننده</th>
                                <th>زمان تعیید شده بر حسب ساعت</th>
                                <th>وضعیت</th>
                                <th>  عملیات</th>

                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 61 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                             if (Model.Count > 0)
                            {
                                foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                     <td>");
#nullable restore
#line 66 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                                    Write(item.TrackingNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                     <td>");
#nullable restore
#line 67 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                                    Write(item.TransitionDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                     <td>");
#nullable restore
#line 68 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                                    Write(item.ReceiverFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                     <td>");
#nullable restore
#line 69 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                                    Write(item.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                     <td>\r\n");
#nullable restore
#line 71 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                                          if(item.IsFinished)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <p class=\"text-success\">\r\n                                                    با موفقیت به دست خریدار رسید\r\n                                                </p>\r\n");
#nullable restore
#line 76 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                  <p class=\"text-warning\" > \r\n                                                    با موفقیت به دست خریدار رسید\r\n                                                </p>\r\n");
#nullable restore
#line 82 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                        <td>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3522, "\"", 3589, 2);
            WriteAttributeValue("", 3529, "#showModal=/SellerPanel/DisplayTransitionOrderItems/", 3529, 52, true);
#nullable restore
#line 85 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
WriteAttributeValue("", 3581, item.Id, 3581, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">مشاهده جزئیات</a>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3680, "\"", 3741, 2);
            WriteAttributeValue("", 3687, "#showModal=/SellerPanel/SetTransitionFinished/", 3687, 46, true);
#nullable restore
#line 86 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
WriteAttributeValue("", 3733, item.Id, 3733, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\">گزارش اتمام ارسال</a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 89 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SellerTransition.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n<!-- Datatable -->\r\n<script src=\"/MainTheme/vendor/datatables/js/jquery.dataTables.min.js\"></script>\r\n<script src=\"/MainTheme/js/plugins-init/datatables.init.js\"></script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShopManagement.Application.Contract.Transition.TransitionViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

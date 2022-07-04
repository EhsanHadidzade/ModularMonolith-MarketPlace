#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\ShowOrderItems.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "913c313e00cb4c8a6fc1762b6cae3991e951c5d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_ShowOrderItems), @"mvc.1.0.view", @"/Views/User/ShowOrderItems.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"913c313e00cb4c8a6fc1762b6cae3991e951c5d5", @"/Views/User/ShowOrderItems.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User_ShowOrderItems : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.OrderItem.OrderItemViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"


<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">جرِئیات سفارش</h4>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-responsive-md"">
                        <thead>
                            <tr>
                                <th><strong>تصویر محصول</strong></th>
                                <th><strong> نام محصول</strong></th>
                                <th><strong> نام فروشگاه</strong></th>
                                <th><strong>تعداد </strong></th>
                                <th><strong>قیمت کل </strong></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 25 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\ShowOrderItems.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"sorting_1\">\r\n                                        <img class=\"rounded-circle\" width=\"35\"");
            BeginWriteAttribute("src", " src=\"", 1251, "\"", 1288, 2);
            WriteAttributeValue("", 1257, "/UploadedFiles/", 1257, 15, true);
#nullable restore
#line 29 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\ShowOrderItems.cshtml"
WriteAttributeValue("", 1272, item.PictureURL, 1272, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1289, "\"", 1295, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 31 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\ShowOrderItems.cshtml"
                                   Write(item.SellerProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\ShowOrderItems.cshtml"
                                   Write(item.SellerShopName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 33 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\ShowOrderItems.cshtml"
                                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 34 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\ShowOrderItems.cshtml"
                                   Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</td>\r\n                                </tr>\r\n");
#nullable restore
#line 36 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\ShowOrderItems.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShopManagement.Application.Contract.OrderItem.OrderItemViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

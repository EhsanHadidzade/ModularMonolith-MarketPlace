#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d022fcc03f4f5fafa022cee7ef3d837f60ff7432"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MainShop_LeftBarOrderItem), @"mvc.1.0.view", @"/Views/MainShop/LeftBarOrderItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d022fcc03f4f5fafa022cee7ef3d837f60ff7432", @"/Views/MainShop/LeftBarOrderItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_MainShop_LeftBarOrderItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.OrderItem.OrderItemViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""card mb-sm-3 mb-md-0 contacts_card"">
    <div class=""card-header chat-list-header text-center"">
        <a href=""#""><svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""18px"" height=""18px"" viewBox=""0 0 24 24"" version=""1.1""><g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd""><rect x=""0"" y=""0"" width=""24"" height=""24""></rect><circle fill=""#000000"" cx=""5"" cy=""12"" r=""2""></circle><circle fill=""#000000"" cx=""12"" cy=""12"" r=""2""></circle><circle fill=""#000000"" cx=""19"" cy=""12"" r=""2""></circle></g></svg></a>
        <div>
            <h6 class=""mb-1"">اعلانات</h6>
            <p class=""mb-0"">نمایش همه</p>
        </div>
        <a href=""#""><svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""18px"" height=""18px"" viewBox=""0 0 24 24"" version=""1.1""><g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd""><rect x=""0"" y=""0"" width=""24"" height=""24""></rect><path d=""M14.2928932,16.7071068 C13.9023689,16.3165825 13.90");
            WriteLiteral(@"23689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3""></path><path d=""M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z"" fill=""#000000"" fill-rule=""nonzero""></path></g></svg></a>
    </div>
    <div class=""card-body contacts_body p-0 dz-scroll ps"" id=""DZ_W_Contacts_Body1"">
        <ul class=""contacts"">
");
#nullable restore
#line 15 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml"
             if (Model.Count == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><h3>خالیه</h3></li>\r\n");
#nullable restore
#line 18 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>\r\n                        <a href=\"/Order/CurrentOrder\">\r\n                            <div class=\"d-flex bd-highlight\">\r\n");
            WriteLiteral("                                <div class=\"img_cont primary\">\r\n                                    <img");
            BeginWriteAttribute("src", " src=\"", 2497, "\"", 2534, 2);
            WriteAttributeValue("", 2503, "/UploadedFiles/", 2503, 15, true);
#nullable restore
#line 28 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml"
WriteAttributeValue("", 2518, item.PictureURL, 2518, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rounded-lg mr-1\" width=\"24\"");
            BeginWriteAttribute("alt", " alt=\"", 2570, "\"", 2576, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </div>\r\n                                <div class=\"user_info\">\r\n                                    <span>");
#nullable restore
#line 31 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml"
                                     Write(item.SellerProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    <p> قیمت : ");
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml"
                                          Write(item.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</p>\r\n                                </div>\r\n                            </div>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 37 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\MainShop\LeftBarOrderItem.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </ul>
        <div class=""ps__rail-x"" style=""left: 0px; bottom: 0px;""><div class=""ps__thumb-x"" tabindex=""0"" style=""left: 0px; width: 0px;""></div></div><div class=""ps__rail-y"" style=""top: 0px; left: -4px;""><div class=""ps__thumb-y"" tabindex=""0"" style=""top: 0px; height: 0px;""></div></div>
    </div>
    <div class=""card-footer""></div>
</div>");
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

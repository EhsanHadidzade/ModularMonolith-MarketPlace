#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1cf9fbeeee3f022a71482971f9e841198e63171d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User__UserProfileAddress), @"mvc.1.0.view", @"/Views/User/_UserProfileAddress.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1cf9fbeeee3f022a71482971f9e841198e63171d", @"/Views/User/_UserProfileAddress.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User__UserProfileAddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AccountManagement.Application.Contract.UserAddress.UserAddressViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"UserAddress\" class=\"tab-pane fade\">\r\n    <div class=\"pt-3\">\r\n        <div class=\"settings-form\">\r\n            <h4 class=\"text-primary\">آدرس ها</h4>\r\n\r\n            <div class=\"widget-media\">\r\n                <ul class=\"timeline\">\r\n");
#nullable restore
#line 10 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <li>
                            <div class=""timeline-panel"">
                                <div class=""media mr-2"">
                                    <img alt=""image"" width=""50"" src=""/maintheme/images/avatar/4.jpg"">
                                </div>
                                <div class=""media-body"">
                                    <h5 class=""mb-1"">");
#nullable restore
#line 18 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
                                                Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    <label class=\"d-block\">استان :");
#nullable restore
#line 19 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
                                                             Write(item.Capital);

#line default
#line hidden
#nullable disable
            WriteLiteral(" -شهر :");
#nullable restore
#line 19 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
                                                                                 Write(item.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n                                    <label class=\"d-block\">کد پستی :");
#nullable restore
#line 20 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
                                                               Write(item.PostalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </label>\r\n                                    <label class=\"d-block\">شماره همراه :");
#nullable restore
#line 21 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
                                                                   Write(item.MobileNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </label>
                                </div>
                                <div class=""dropdown"">
                                    <button type=""button"" class=""btn btn-primary light sharp"" data-toggle=""dropdown"" aria-expanded=""false"">
                                        <svg width=""18px"" height=""18px"" viewBox=""0 0 24 24"" version=""1.1""><g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd""><rect x=""0"" y=""0"" width=""24"" height=""24""></rect><circle fill=""#000000"" cx=""5"" cy=""12"" r=""2""></circle><circle fill=""#000000"" cx=""12"" cy=""12"" r=""2""></circle><circle fill=""#000000"" cx=""19"" cy=""12"" r=""2""></circle></g></svg>
                                    </button>
                                    <div class=""dropdown-menu"" x-placement=""bottom-start"" style=""position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(0px, 33px, 0px);"">
                                        <a class=""dropdown-item""");
            BeginWriteAttribute("href", " href=\"", 2070, "\"", 2114, 2);
            WriteAttributeValue("", 2077, "#showModal=/User/EditAddress/", 2077, 29, true);
#nullable restore
#line 28 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
WriteAttributeValue("", 2106, item.Id, 2106, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">ویرایش</a>\r\n                                        <a class=\"dropdown-item\"");
            BeginWriteAttribute("href", " href=\"", 2192, "\"", 2238, 2);
            WriteAttributeValue("", 2199, "#showModal=/User/RemoveAddress/", 2199, 31, true);
#nullable restore
#line 29 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
WriteAttributeValue("", 2230, item.Id, 2230, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">حذف</a>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </li>\r\n");
#nullable restore
#line 34 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileAddress.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n                <a href=\"#showModal=/User/CreateAddress\" class=\"btn btn-outline-info\">افزودن ادرس جدید</a>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AccountManagement.Application.Contract.UserAddress.UserAddressViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

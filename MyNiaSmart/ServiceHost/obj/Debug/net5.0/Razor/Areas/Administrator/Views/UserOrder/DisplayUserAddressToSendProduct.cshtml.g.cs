#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserOrder\DisplayUserAddressToSendProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2cbd5125f3edb09acdefafe3031fbd8e70f0f1c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_UserOrder_DisplayUserAddressToSendProduct), @"mvc.1.0.view", @"/Areas/Administrator/Views/UserOrder/DisplayUserAddressToSendProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cbd5125f3edb09acdefafe3031fbd8e70f0f1c6", @"/Areas/Administrator/Views/UserOrder/DisplayUserAddressToSendProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administrator_Views_UserOrder_DisplayUserAddressToSendProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AccountManagement.Application.Contract.UserAddress.UserAddressViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-xl-12"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""profile-news"">
                    <h5 class=""text-primary d-inline"">آدرس انتخاب شده توسط کاربر برای ارسال محصول</h5>
");
#nullable restore
#line 10 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserOrder\DisplayUserAddressToSendProduct.cshtml"
                     if (Model == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"alert alert-info\">\r\n                            ادرسی انتخاب نشده\r\n                        </div>\r\n");
#nullable restore
#line 15 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserOrder\DisplayUserAddressToSendProduct.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"media pt-3 pb-3\">\r\n                        <div class=\"media-body\">\r\n                            <h5 class=\"m-b-5\"> استان :");
#nullable restore
#line 18 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserOrder\DisplayUserAddressToSendProduct.cshtml"
                                                 Write(Model.Capital);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - شهر : ");
#nullable restore
#line 18 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserOrder\DisplayUserAddressToSendProduct.cshtml"
                                                                        Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <strong class=\"mb-0\"> آدرس  : ");
#nullable restore
#line 19 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserOrder\DisplayUserAddressToSendProduct.cshtml"
                                                     Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                            <p>شماره همراه : ");
#nullable restore
#line 20 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserOrder\DisplayUserAddressToSendProduct.cshtml"
                                        Write(Model.MobileNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccountManagement.Application.Contract.UserAddress.UserAddressViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

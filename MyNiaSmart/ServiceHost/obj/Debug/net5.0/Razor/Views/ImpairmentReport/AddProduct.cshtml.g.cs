#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3a1e747b942d4c354a1930183e7aea5fb2d2349"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ImpairmentReport_AddProduct), @"mvc.1.0.view", @"/Views/ImpairmentReport/AddProduct.cshtml")]
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
#nullable restore
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
using RepairWorkShopManagement.Application.Contracts.UserImapairmentReport;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3a1e747b942d4c354a1930183e7aea5fb2d2349", @"/Views/ImpairmentReport/AddProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ImpairmentReport_AddProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.Product.ProductViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/ImpairmentReport/AddProduct"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
  
    
   var userImpairmentReportId = ViewData["UserImpairmentReportId"];
    var selectedProductIds = _userImpairmentReportApplication.GetSelectedProductIds((long)userImpairmentReportId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12\">\r\n        <div class=\"card\">\r\n            <div class=\"card-header\">\r\n                <h4 class=\"card-title\">لیست محصولات جهت افزودن به خرابی</h4>\r\n            </div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a3a1e747b942d4c354a1930183e7aea5fb2d23494991", async() => {
                WriteLiteral(@"
                <div class=""card-body"" id=""SystemServices"">
                    <div class=""table-responsive"">
                        <table id=""example3"" class=""display"" style=""min-width: 845px"">
                            <thead>
                                <tr>
                                    <th>انتخاب</th>
                                    <th>تصویر محصول</th>
                                    <th>عنوان محصول</th>
                                    <th> پارت نامبر</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 31 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            <input type=\"checkbox\" class=\"form-check\"");
                BeginWriteAttribute("value", " value=\"", 1603, "\"", 1619, 1);
#nullable restore
#line 35 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
WriteAttributeValue("", 1611, item.Id, 1611, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"productIds\"  ");
#nullable restore
#line 35 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
                                                                                                                      Write((selectedProductIds.Any(x=>x==item.Id))? "Checked":"");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                                        </td>\r\n                                        <td>\r\n                                            <img");
                BeginWriteAttribute("src", " src=\"", 1840, "\"", 1877, 2);
                WriteAttributeValue("", 1846, "/UploadedFiles/", 1846, 15, true);
#nullable restore
#line 38 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
WriteAttributeValue("", 1861, item.PictureURL, 1861, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"rounded-circle\" width=\"35\">\r\n                                        </td>\r\n                                        <td>");
#nullable restore
#line 40 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
                                       Write(item.EngTitle);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 41 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
                                       Write(item.PartNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 43 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n                <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 2332, "\"", 2375, 1);
#nullable restore
#line 48 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\ImpairmentReport\AddProduct.cshtml"
WriteAttributeValue("", 2340, ViewData["UserImpairmentReportId"], 2340, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"userImpairmentReportId\" />\r\n                    <button type=\"submit\" class=\"btn btn-success\">افزودن</button>\r\n\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserImpairmentReportApplication _userImpairmentReportApplication { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShopManagement.Application.Contract.Product.ProductViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

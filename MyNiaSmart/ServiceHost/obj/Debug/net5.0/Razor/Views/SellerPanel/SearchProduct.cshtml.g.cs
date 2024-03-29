#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SearchProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c25ea66c86cb1841bcfd5bf6aef7753540cc53e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SellerPanel_SearchProduct), @"mvc.1.0.view", @"/Views/SellerPanel/SearchProduct.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c25ea66c86cb1841bcfd5bf6aef7753540cc53e7", @"/Views/SellerPanel/SearchProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SellerPanel_SearchProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.Product.ProductViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- Custom Stylesheet -->
<link href=""/MainTheme/vendor/datatables/css/jquery.dataTables.min.css"" rel=""stylesheet"">
<link href=""/MainTheme/vendor/bootstrap-select/dist/css/bootstrap-select.min.css"" rel=""stylesheet"">


<div class=""row"">
    <div class=""col-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">لیست  محصولات سازمان</h4>
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table id=""example3"" class=""display"" style=""min-width: 845px"">
                        <thead>
                            <tr>
                                <th>تصویر محصول</th>
                                <th>عنوان محصول</th>
                                <th> پارت نامبر</th>
                                <th>عملیات</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 26 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SearchProduct.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 1261, "\"", 1298, 2);
            WriteAttributeValue("", 1267, "/UploadedFiles/", 1267, 15, true);
#nullable restore
#line 30 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SearchProduct.cshtml"
WriteAttributeValue("", 1282, item.PictureURL, 1282, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rounded-circle\" width=\"35\">\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SearchProduct.cshtml"
                                   Write(item.EngTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 33 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SearchProduct.cshtml"
                                   Write(item.PartNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <div class=\"d-flex\">\r\n                                            <button");
            BeginWriteAttribute("onclick", " onclick=\"", 1658, "\"", 1688, 3);
            WriteAttributeValue("", 1668, "addproduct(", 1668, 11, true);
#nullable restore
#line 36 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SearchProduct.cshtml"
WriteAttributeValue("", 1679, item.Id, 1679, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1687, ")", 1687, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary shadow btn-xs sharp mr-1\"><i class=\"fa fa-plus\"></i></button>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 40 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\SearchProduct.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

<!--Datatable JavaScript-->
<script src=""/MainTheme/vendor/datatables/js/jquery.dataTables.min.js""></script>
<script src=""/MainTheme/js/plugins-init/datatables.init.js""></script>


<script>
    function addproduct(productid){
        debugger
        $.ajax({
            url:""/sellerpanel/addproduct"",
            data:{id:productid},
            dataType:'json',
            success:function(result){
                $(""#ProductTitle"").val(result.FarsiTitle);
                $(""#ProductId"").val(result.Id);
                $(""#MainModal"").modal(""hide"");
            }
        })
    }
</script>





















");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShopManagement.Application.Contract.Product.ProductViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

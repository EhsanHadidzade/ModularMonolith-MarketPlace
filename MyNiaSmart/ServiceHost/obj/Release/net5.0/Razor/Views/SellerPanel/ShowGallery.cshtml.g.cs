#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f1a7bb8f678c7ec4778d4d00c85f1bf5742269e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SellerPanel_ShowGallery), @"mvc.1.0.view", @"/Views/SellerPanel/ShowGallery.cshtml")]
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
#line 1 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
using ShopManagement.Application.Contract.SellerProductMedia;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f1a7bb8f678c7ec4778d4d00c85f1bf5742269e", @"/Views/SellerPanel/ShowGallery.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_SellerPanel_ShowGallery : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<List<SellerGalleryViewModel>,List<long>,long>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminTheme/vendor/sweetalert2/dist/sweetalert2.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("150"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("MyForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8f1a7bb8f678c7ec4778d4d00c85f1bf5742269e5816", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<style>
    img {
        border: 1px solid #ddd;
        border-radius: 4px;
        padding: 5px;
        width: 150px;
    }

    .selectedd {
        border: 5px solid green;
    }

</style>
<div class=""row"">
    <div class=""col-xl-12 col-lg-12"">
        <div class=""card"">
            <div class=""card-header"">
                <h4 class=""card-title"">ورودی پرونده سفارشی</h4>
            </div>
            <div class=""card-body"">
                <div class=""basic-form custom_file_input"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f1a7bb8f678c7ec4778d4d00c85f1bf5742269e7481", async() => {
                WriteLiteral(@"
                        <div class=""form-group col-md-12 gallery"">
                            <label>تصویر محصول</label>
                            <input type=""file"" class=""form-control Upload"" id=""newMedia"" name=""newMedia"" multiple>
                            <div class=""main""></div>
");
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
                             if (Model.Item1.Count > 0)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
                                 foreach (var image in Model.Item1)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8f1a7bb8f678c7ec4778d4d00c85f1bf5742269e8679", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1330, "~/UploadedFiles/", 1330, 16, true);
#nullable restore
#line 36 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
AddHtmlAttributeValue("", 1346, image.MediaURL, 1346, 15, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 36 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
AddHtmlAttributeValue("", 1379, image.Id, 1379, 9, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 36 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
AddHtmlAttributeValue("", 1397, (Model.Item2.Any(x=>x==image.Id)?"selectedd":""), 1397, 51, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1510, "\"", 1565, 1);
#nullable restore
#line 37 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
WriteAttributeValue("", 1518, (Model.Item2.Any(x=>x==image.Id)?image.Id:0), 1518, 47, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"selectedMedia\"");
                BeginWriteAttribute("class", " class=\"", 1587, "\"", 1604, 1);
#nullable restore
#line 37 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
WriteAttributeValue("", 1595, image.Id, 1595, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"mediaId\">\r\n");
#nullable restore
#line 38 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n                        <button type=\"submit\" class=\"btn btn-outline-success\">تایید</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <br />
                    <button onclick=""DeleteMedia()"" class=""btn btn-outline-danger deleteMedia"">حذف تصاویر </button>
                </div>
            </div>
        </div>
    </div>

</div>

<script>
    function DeleteMedia(){
        var formValues= $(""form.MyForm"").serialize();
        $.ajax({
            url:""/SellerPanel/DeleteMedia"",
            type:""Post"",
            data:formValues,
            success:function(result){
                debugger
                $("".deleteResult"").empty();
                $("".deleteResult"").append(""<div class='alert alert-info'>""+""<p>""+""حذف یا موفقیت انجام شد""+""</p>""+""</div>"");
                $(""#MainModal"").modal(""hide"");
            }
        })
    }


        $(function(){
            var output = $('#output');
            $('img')
                //.each(function(i, el){
                //    $(this).addClass('img' + i); // identtify imgs by index (class=""imgN"")
                //})
                ");
            WriteLiteral(@".click(function(){
                    $(this).fadeOut(1,function(){$(this).fadeIn(500)});
                    var $img = $(this).toggleClass('selectedd');
                    var selectedMediaId=$(this).attr(""id"");
                    $("".""+selectedMediaId).val(selectedMediaId);
                    if($img.hasClass('selectedd'))
                    {

                          output.append($img.clone().removeClass('selectedd'));
                    }
                    else
                    {

                        output.find('.' + $img[0].className).remove();
                           var selectedMediaId=$(this).attr(""id"");
                           $(""input.""+selectedMediaId).val(0);
                    }
                });

        });

           $(document).ready(function(){
            $(""form.MyForm"").on(""submit"", function(event){
                event.preventDefault();
                debugger
                var formValues= $(this).serialize();

                ");
            WriteLiteral(@"  $.post(""/SellerPanel/ChooseMedia"", formValues, function(data){
                        $("".ShowMedia"").empty();
                        $(jQuery.parseJSON(data)).each(function() {
                              var ID = this.Id;
                              var MediaURL = this.MediaURL;
                         $("".ShowMedia"").append(""<img src='/UploadedFiles/""+MediaURL+""'""+""width='150' />"" +
                                                ""<input type='hidden' value='"" + ID + ""'"" +""name='SelectedMediaIds' id='SelectedMediaIds'>"");

                           });
                        $(""#MainModal"").modal(""hide"");
                    });
            });
        });

                            $("".Upload"").change(function(){
                                  var fd = new FormData();
                             var files = $(""#newMedia"").get(0).files;
                             fd.append(""newMedia"",files[0]);

                              $.ajax({
                                  ");
            WriteLiteral(@"type:""Post"",
                                  url:""/sellerpanel/AddMediaToGallery"",
                                  data:fd,
                                  processData: false,
                                  contentType: false,
                                  dataType: ""json"",
                                  success:function(result){
                                      $("".main"").empty();
                                          debugger
                                            if(result.IsSuccedded===false){
                                          debugger
                                      $("".main"").append(""<div class='alert alert-danger'><p>نوع فایل باید png و یا jpg باشد </p></div>"");
                                      }

                                      else
                                      {
                                          let id=");
#nullable restore
#line 139 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\SellerPanel\ShowGallery.cshtml"
                                            Write(Model.Item1.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"+1;
                                          debugger
                                      $("".gallery"").append(""<img src='/UploadedFiles/""+result.Message+""'""+""width='150' id='""+result.Id+""'""+""/>""+ ""<input type='hidden' value='0' class='""+result.Id+""'""+"" name='selectedMedia'>"");
                                      $("".main"").append(""<div class='alert alert-success'> <p >موفقیت آمیز بود</p></div>"");
                                        $('img')
                                        .each(function(i, el){
                                            $(this).addClass('img' + i); // identtify imgs by index (class=""imgN"")
                                             })
                                      }

                                  }
                              })
                            })


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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<List<SellerGalleryViewModel>,List<long>,long>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

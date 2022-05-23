#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c234806203f1021c184c80dfadd288deca21b90"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Administrator_Views_UserCooperationRequest_ShowAndSetRequestedRoles), @"mvc.1.0.view", @"/Areas/Administrator/Views/UserCooperationRequest/ShowAndSetRequestedRoles.cshtml")]
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
#line 1 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
using AccountManagement.Application.Contract.RoleType;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
using AccountManagement.Application.Contract.UserCooperationRequest;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c234806203f1021c184c80dfadd288deca21b90", @"/Areas/Administrator/Views/UserCooperationRequest/ShowAndSetRequestedRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Areas/Administrator/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Administrator_Views_UserCooperationRequest_ShowAndSetRequestedRoles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<List<RoleTypeViewModel>,List<long>,long>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Administrator/UserCooperationRequest/SetRolesForUser"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 5 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
  
    var requestedRoles = _userCooperationRequestAppliation.GetRequestedRolesByRoleIds(Model.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7c234806203f1021c184c80dfadd288deca21b905542", async() => {
                WriteLiteral(@"
    <div class=""modal-content"">
        <div class=""modal-header"">
            <h5 class=""modal-title"">مدیریت نقش های انتخابی کاربر </h5>
            <button type=""button"" class=""close"" data-dismiss=""modal"">
                <span>×</span>
            </button>
        </div>
        <div class=""modal-body"">
            <div class=""row"">
                <div class=""col-xl-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                            <h4 class=""card-title"">مدیریت نقش  کاربر </h4>
                        </div>
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col-xl-3"">
                                    <div class=""nav flex-column nav-pills mb-3"">
");
#nullable restore
#line 30 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                         foreach (var roleType in Model.Item1)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <a");
                BeginWriteAttribute("href", " href=\"", 1462, "\"", 1490, 2);
                WriteAttributeValue("", 1469, "#v-pills-", 1469, 9, true);
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
WriteAttributeValue("", 1478, roleType.Id, 1478, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" data-toggle=\"pill\"");
                BeginWriteAttribute("class", " class=\"", 1510, "\"", 1577, 2);
                WriteAttributeValue("", 1518, "nav-link", 1518, 8, true);
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
WriteAttributeValue(" ", 1526, (Model.Item1.IndexOf(roleType)==0)? "active":"", 1527, 50, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("> ");
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                                                                                                                                               Write(roleType.RoleTypeName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n");
#nullable restore
#line 33 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </div>
                                </div>
                                <div class=""col-xl-9"" style="" border-right: 1px solid rgba(192,192,192, .5) ;"">
                                    <div class=""tab-content"">
");
#nullable restore
#line 38 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                         foreach (var roleType in Model.Item1)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <div");
                BeginWriteAttribute("id", " id=\"", 2082, "\"", 2107, 2);
                WriteAttributeValue("", 2087, "v-pills-", 2087, 8, true);
#nullable restore
#line 40 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
WriteAttributeValue("", 2095, roleType.Id, 2095, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("class", " class=\"", 2108, "\"", 2185, 3);
                WriteAttributeValue("", 2116, "tab-pane", 2116, 8, true);
                WriteAttributeValue(" ", 2124, "fade", 2125, 5, true);
#nullable restore
#line 40 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
WriteAttributeValue(" ", 2129, (Model.Item1.IndexOf(roleType)==0)? "active show":"", 2130, 55, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 41 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                                 foreach (var role in roleType.Roles)
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                    <div class=""form-check mb-2"">
                                                        9
                                                        <input type=""checkbox"" class=""form-check-input"" id=""check1"" name=""ConfirmedRoleIds""");
                BeginWriteAttribute("value", " value=\"", 2608, "\"", 2624, 1);
#nullable restore
#line 45 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
WriteAttributeValue("", 2616, role.Id, 2616, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" ");
#nullable restore
#line 45 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                                                                                                                                         Write((Model.Item2.Any(x=>x==role.Id))? "Checked":"");

#line default
#line hidden
#nullable disable
                WriteLiteral(">\r\n                                                        <label class=\"form-check-label\" for=\"check1\"> ");
#nullable restore
#line 46 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                                                                                 Write(role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                                    </div>\r\n");
#nullable restore
#line 48 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            </div>\r\n");
#nullable restore
#line 50 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n\r\n                            <input type=\"hidden\" name=\"userId\"");
                BeginWriteAttribute("value", " value=\"", 3190, "\"", 3210, 1);
#nullable restore
#line 55 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
WriteAttributeValue("", 3198, Model.Item3, 3198, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                        </div>
                    </div>
                </div>
                <div class=""col-xl-12"">
                    <div class=""card"">
                        <div class=""card-header"">
                              <h4 class=""card-title"">نقش های درخواستی کاربر</h4>
                        </div>
                        <div class=""card-body"">
                            <div class=""row"">
                                <ul>
");
#nullable restore
#line 67 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                   foreach(var role in requestedRoles)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                          <li> ");
#nullable restore
#line 69 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                          Write(role.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n");
#nullable restore
#line 70 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Areas\Administrator\Views\UserCooperationRequest\ShowAndSetRequestedRoles.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""modal-footer"">
        <button type=""button"" class=""btn btn-danger light"" data-dismiss=""modal"">بستن</button>
        <button type=""submit"" class=""btn btn-primary"">ذخیره تغییرات</button>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserCooperationRequestApplication _userCooperationRequestAppliation { get; private set; } = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<List<RoleTypeViewModel>,List<long>,long>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

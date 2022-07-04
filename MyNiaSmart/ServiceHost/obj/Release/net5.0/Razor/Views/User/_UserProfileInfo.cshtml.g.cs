#pragma checksum "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41f3457362319bda928e68ef1d28e4b787832bb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User__UserProfileInfo), @"mvc.1.0.view", @"/Views/User/_UserProfileInfo.cshtml")]
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
#line 2 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
using AccountManagement.Application.Contract.UpAccountRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
using AccountManagement.Application.Contract.UserCooperationRequest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
using AccountManagement.Application.Contract.UserPersonality;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
using ShopManagement.Application.Contract.SellerPanel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
using _0_Framework.Utilities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41f3457362319bda928e68ef1d28e4b787832bb8", @"/Views/User/_UserProfileInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c7b8880ea49463149f587326c9bcfc64cd7c9e9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User__UserProfileInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<_0_MyNiaSmartQuery.Contract.User.UserInfoQueryModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 11 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
  
    var acceptedPersonalityIds = _userPersonalityApplication.GetAllPersonalityIdsOfOneUserByUserId(Model.Id);
    var requestedPersonalities = _userCooperaitonRequestApplication.GetRequestedPersonalitiesByUserId(Model.Id);
    var HasUserRequestedForSellerPanel = _sellerPanelApplication.HasUserRequestedForSellerPanel(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div id=""about-me"" class=""tab-pane fade active show"">
    <div class=""profile-personal-info"" style=""padding:20px"">
        <h4 class=""text-primary mb-4"">اطلاعات شخصی</h4>
        <div class=""row mb-2"">
            <div class=""col-12"">
                <h5 class=""f-w-500"">
                    نام و نام خانوادگی :  <span>");
#nullable restore
#line 25 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                           Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </h5>\r\n            </div>\r\n        </div>\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-12\">\r\n                <h5 class=\"f-w-500\">\r\n                    کد ملی :      <span>");
#nullable restore
#line 32 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                   Write(Model.NationalCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </h5>\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-12\">\r\n                <h5 class=\"f-w-500\">\r\n                    تاریخ تولد :         <span>");
#nullable restore
#line 40 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                          Write(Model.Birthday);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </h5>\r\n            </div>\r\n        </div>\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-12\">\r\n                <h5 class=\"f-w-500\">\r\n                    نام و نام خانوادگی معرف  : <span>");
#nullable restore
#line 47 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                Write(Model.IntroductorFullname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                </h5>\r\n            </div>\r\n        </div>\r\n        <div class=\"row mb-2\">\r\n            <div class=\"col-12\">\r\n                <h5 class=\"f-w-500\">\r\n                    شماره همراه معرف  :  <span> ");
#nullable restore
#line 54 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                           Write(Model.IntroductorMobileNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </h5>\r\n            </div>\r\n        </div>\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
         if (_uPAccountRequestApplication.GetByUserId(Model.Id) != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <hr />
            <br />
            <div class=""row mb-2"">
                <div class=""col-3"">
                    <h5 class=""f-w-500"">وضعیت درخواست ارتقا حساب کاربری <span class=""pull-right"">:</span></h5>
                </div>
                <div class=""col-9"">
");
#nullable restore
#line 76 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                     if (!_uPAccountRequestApplication.IsUpAccountRequestConfirmedWithAdminByUserId(Model.Id))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"alert alert-warning\" style=\"padding:20px;margin-left:10px\">\r\n                            درخواست شما در حال بررسی میباشد\r\n                        </span>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 3309, "\"", 3370, 2);
            WriteAttributeValue("", 3316, "/user/EditUpgradeAccount/", 3316, 25, true);
#nullable restore
#line 81 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
WriteAttributeValue("", 3341, Model.UserUpAccountRequestId, 3341, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\">ویرایش درخواست</a>\r\n");
#nullable restore
#line 82 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"alert alert-success\">\r\n                            درخواست شما با موفقیت تایید شد\r\n                        </span>\r\n");
#nullable restore
#line 88 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n\r\n            </div>\r\n");
#nullable restore
#line 92 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 94 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
         if (_userCooperaitonRequestApplication.IsUserRequestedForCooperation(Model.Id))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br />\r\n            <hr />\r\n            <br />\r\n            <div class=\"row mb-2\">\r\n\r\n");
#nullable restore
#line 101 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                 if (!_userCooperaitonRequestApplication.IsUserRequestForCooperationRecognizedByAdmin(Model.Id))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-3"">
                        <h5 class=""f-w-500"">وضعیت درخواست همکاری <span class=""pull-right"">:</span></h5>
                    </div>
                    <div class=""col-9"">
                        <span class=""alert alert-warning"" style=""padding:20px;"">
                            درخواست شما در حال بررسی میباشد
                        </span>
                    </div>
");
#nullable restore
#line 111 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""col-12"">
                        <h5 class=""f-w-500"">وضعیت درخواست همکاری <span class=""pull-right"">:</span></h5>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div class=""col-xl-12"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <!-- Nav tabs -->
                        <div class=""default-tab"">
                                    <ul class=""nav nav-tabs"" role=""tablist"">
");
#nullable restore
#line 126 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                         if (requestedPersonalities.Any(x => x.PersonalityTypeId == PersonalityTypeId.Seller))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <li class=""nav-item"">
                                                <a class=""nav-link active"" data-toggle=""tab"" href=""#seller""> لیست واحد هایی که شما جهت همکاری در زمینه فروش درخواست کرده اید</a>
                                            </li>
");
#nullable restore
#line 131 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 132 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                         if (requestedPersonalities.Any(x => x.PersonalityTypeId == PersonalityTypeId.Marketer))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <li class=""nav-item"">
                                                <a class=""nav-link "" data-toggle=""tab"" href=""#marketer""> لیست واحد هایی که شما جهت همکاری در زمینه بازاریابی درخواست کرده اید</a>
                                            </li>
");
#nullable restore
#line 137 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 138 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                         if (requestedPersonalities.Any(x => x.PersonalityTypeId == PersonalityTypeId.ServiceMan))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <li class=""nav-item"">
                                                <a class=""nav-link "" data-toggle=""tab"" href=""#serviceman""> لیست واحد هایی که شما جهت همکاری در زمینه خدمات فنی و تعمیرات درخواست کرده اید</a>
                                            </li>
");
#nullable restore
#line 143 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </ul>\r\n                                    <div class=\"tab-content\">\r\n");
#nullable restore
#line 146 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                         if (requestedPersonalities.Any(x => x.PersonalityTypeId == PersonalityTypeId.Seller))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""tab-pane fade active show"" id=""seller"" role=""tabpanel"">
                                                <div class=""pt-4"">
                                                    <div class=""col-xl-12 col-lg-12 col-sm-12"">
                                                        <div class=""card"">

                                                            <div class=""card-body pb-0"">

");
#nullable restore
#line 155 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                 foreach (var item in requestedPersonalities.Where(x => x.PersonalityTypeId == PersonalityTypeId.Seller))
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <div");
            BeginWriteAttribute("class", " class=\"", 7697, "\"", 7819, 6);
            WriteAttributeValue("", 7705, "alert", 7705, 5, true);
            WriteAttributeValue(" ", 7710, "alert-outline", 7711, 14, true);
#nullable restore
#line 157 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
WriteAttributeValue("", 7724, (acceptedPersonalityIds.Any(x=>x==item.Id))?"-success":"-danger", 7724, 67, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 7791, "alert-dismissible", 7792, 18, true);
            WriteAttributeValue(" ", 7809, "fade", 7810, 5, true);
            WriteAttributeValue(" ", 7814, "show", 7815, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                        <p>");
#nullable restore
#line 158 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                                    </div>\r\n");
#nullable restore
#line 160 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            </div>\r\n                                                        </div>\r\n                                                            <a href=\"#ShowModal=/user/CreateSellerPanel\"");
            BeginWriteAttribute("class", " class=\"", 8294, "\"", 8389, 4);
            WriteAttributeValue("", 8302, "btn", 8302, 3, true);
            WriteAttributeValue(" ", 8305, "btn-square", 8306, 11, true);
            WriteAttributeValue(" ", 8316, "btn-outline-secondary", 8317, 22, true);
#nullable restore
#line 163 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
WriteAttributeValue(" ", 8338, (HasUserRequestedForSellerPanel)?"disabledd":"", 8339, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" >ساخت پنل بازاریابی</a>\r\n                                                    </div>\r\n                                                </div>\r\n                                            </div>\r\n");
#nullable restore
#line 167 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 168 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                         if (requestedPersonalities.Any(x => x.PersonalityTypeId == PersonalityTypeId.Marketer))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""tab-pane fade"" id=""marketer"" role=""tabpanel"">
                                                <div class=""pt-4"">
                                                    <div class=""col-xl-12 col-lg-12 col-sm-12"">
                                                        <div class=""card"">

                                                            <div class=""card-body pb-0"">

");
#nullable restore
#line 177 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                 foreach (var item in requestedPersonalities.Where(x => x.PersonalityTypeId == PersonalityTypeId.Marketer))
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <div");
            BeginWriteAttribute("class", " class=\"", 9550, "\"", 9672, 6);
            WriteAttributeValue("", 9558, "alert", 9558, 5, true);
            WriteAttributeValue(" ", 9563, "alert-outline", 9564, 14, true);
#nullable restore
#line 179 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
WriteAttributeValue("", 9577, (acceptedPersonalityIds.Any(x=>x==item.Id))?"-success":"-danger", 9577, 67, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 9644, "alert-dismissible", 9645, 18, true);
            WriteAttributeValue(" ", 9662, "fade", 9663, 5, true);
            WriteAttributeValue(" ", 9667, "show", 9668, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                        <p>");
#nullable restore
#line 180 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                                    </div>\r\n");
#nullable restore
#line 182 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
");
#nullable restore
#line 188 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 189 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                         if (requestedPersonalities.Any(x => x.PersonalityTypeId == PersonalityTypeId.ServiceMan))
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""tab-pane fade"" id=""serviceman"" role=""tabpanel"">
                                                <div class=""pt-4"">
                                                    <div class=""col-xl-12 col-lg-12 col-sm-12"">
                                                        <div class=""card"">

                                                            <div class=""card-body pb-0"">

");
#nullable restore
#line 198 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                 foreach (var item in requestedPersonalities.Where(x => x.PersonalityTypeId == PersonalityTypeId.ServiceMan))
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <div");
            BeginWriteAttribute("class", " class=\"", 11183, "\"", 11305, 6);
            WriteAttributeValue("", 11191, "alert", 11191, 5, true);
            WriteAttributeValue(" ", 11196, "alert-outline", 11197, 14, true);
#nullable restore
#line 200 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
WriteAttributeValue("", 11210, (acceptedPersonalityIds.Any(x=>x==item.Id))?"-success":"-danger", 11210, 67, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 11277, "alert-dismissible", 11278, 18, true);
            WriteAttributeValue(" ", 11295, "fade", 11296, 5, true);
            WriteAttributeValue(" ", 11300, "show", 11301, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                        <p>");
#nullable restore
#line 201 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                      Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                                    </div>\r\n");
#nullable restore
#line 203 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
");
#nullable restore
#line 209 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
#nullable restore
#line 215 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 217 "C:\Work\Projects\MyNiaSmart\MyNiaSmart\ServiceHost\Views\User\_UserProfileInfo.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ISellerPanelApplication _sellerPanelApplication { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserPersonalityApplication _userPersonalityApplication { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUserCooperationRequestApplication _userCooperaitonRequestApplication { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUPAccountRequestApplication _uPAccountRequestApplication { get; private set; } = default!;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<_0_MyNiaSmartQuery.Contract.User.UserInfoQueryModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

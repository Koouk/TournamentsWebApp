#pragma checksum "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91d4896c898355969e7ba1d2696c33c170ae3124"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tournaments_Started), @"mvc.1.0.view", @"/Views/Tournaments/Started.cshtml")]
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
#line 1 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\_ViewImports.cshtml"
using TournamentsWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
using TournamentsWebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91d4896c898355969e7ba1d2696c33c170ae3124", @"/Views/Tournaments/Started.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"825d69cea22e889366087c85584e1ce1cc88ee9b", @"/Views/_ViewImports.cshtml")]
    public class Views_Tournaments_Started : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TournamentsWebApp.Models.ViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Matches", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1> \"");
#nullable restore
#line 11 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
 Write(Model.tournament.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" Tournament Details  </h1>

<h3> Tournament has started! </h3>

<fieldset>
    <legend style=""font-family: 'Segoe UI'; color: rgb(73,171,210); font-size: large;"">Tournament location:</legend>
    <iframe width=""100%""
            height=""400px""
            style=""border:0""
            loading=""lazy""
            allowfullscreen");
            BeginWriteAttribute("src", "\r\n            src=\"", 671, "\"", 809, 2);
            WriteAttributeValue("", 690, "https://www.google.com/maps/embed/v1/place?key=AIzaSyBkScl8QvQwXr1qdINMPHMC1tEuMx3Va34&q=", 690, 89, true);
#nullable restore
#line 22 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
WriteAttributeValue("", 779, Model.tournament.localization, 779, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
    </iframe>
    <!--
    <div id=""googleMap"" style=""height:400px;width:100%;""></div>
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js""></script>
    <script>

        function myMap() {
            var myCenter = new google.maps.LatLng(52.403440, 16.950744);
            var geocoder = new google.maps.Geocoder();
            geocoder.geocode({ 'address': """);
#nullable restore
#line 33 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                      Write(Model.tournament.localization);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" }, function (results, status) {
                if (status == 'OK') {
                    myCenter = results[0].geometry.locationl
                    alert('Geocode was OK' );
                } else {
                    alert('Geocode was not successful for the following reason: ' + status);
                }
            });

            var mapProp = { center: myCenter, zoom: 12, scrollwheel: false, draggable: true, mapTypeId: google.maps.MapTypeId.ROADMAP };
            var map = new google.maps.Map(document.getElementById(""googleMap""), mapProp);
            var marker = new google.maps.Marker({ position: myCenter });
            marker.setMap(map);
        }
    </script>
     <script src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyBkScl8QvQwXr1qdINMPHMC1tEuMx3Va34&callback=myMap""></script> -->
</fieldset>

<div>
    <hr />
    <dl class=""row"">
        <dt class=""col-sm-2"">
            ");
#nullable restore
#line 55 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayNameFor(model => model.tournament.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 58 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayFor(model => model.tournament.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 61 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayNameFor(model => model.tournament.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 64 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayFor(model => model.tournament.StartDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 67 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayNameFor(model => model.tournament.Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 70 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayFor(model => model.tournament.Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 73 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayNameFor(model => model.tournament.Discipline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 76 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayFor(model => model.tournament.Discipline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 79 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayNameFor(model => model.tournament.localization));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 82 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayFor(model => model.tournament.localization));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 85 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayNameFor(model => model.tournament.currentPart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 88 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayFor(model => model.tournament.currentPart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 91 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayNameFor(model => model.tournament.maxPart));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 94 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
       Write(Html.DisplayFor(model => model.tournament.maxPart));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </dd>
    </dl>
</div>
<div>

    <table class=""table"">
        <thead>
            <tr>
                <th>
                    <p> First opponent</p>
                </th>
                <th>
                    <p> Second Opponent</p>
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 113 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
             foreach (var item in Model.allMatches)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n");
#nullable restore
#line 117 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                         if (item.OpponentFirst is null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p> TBD </p>");
#nullable restore
#line 119 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                        }
                        else
                        {
                            var toShow = item.OpponentFirst.FirstName + " Licence:" + item.LicenceNumberFirst;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                       Write(Html.DisplayFor(modelItem => toShow));

#line default
#line hidden
#nullable disable
#nullable restore
#line 123 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                                                 
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 127 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                         if (item.OpponentSecond is null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p> TBD </p>");
#nullable restore
#line 129 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                        }
                        else
                        {
                            var toShow = item.OpponentSecond.FirstName + " Licence:" + item.LicenceNumberSecond;
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                       Write(Html.DisplayFor(modelItem => toShow));

#line default
#line hidden
#nullable disable
#nullable restore
#line 133 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                                                 
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 138 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 141 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
     if (Model.allMatches.Last().WinnerID != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2> Winner: ");
#nullable restore
#line 143 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
        Write(Model.allMatches.Last().WinnerID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 144 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 146 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
     if (User.Identity.IsAuthenticated && Model.userMatches.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <h3> Your next matches:</h3>
        <table class=""table"">
            <thead>
                <tr>
                    <th>
                        <p> First opponent</p>
                    </th>
                    <th>
                        <p> Second Opponent</p>
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 162 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                 foreach (var item in Model.userMatches)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n");
#nullable restore
#line 166 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                             if (item.OpponentFirst is null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p> TBD </p>");
#nullable restore
#line 168 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                            }
                            else
                            {
                                var toShow = item.OpponentFirst.FirstName + " Licence:" + item.LicenceNumberFirst;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 172 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                           Write(Html.DisplayFor(modelItem => toShow));

#line default
#line hidden
#nullable disable
#nullable restore
#line 172 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                                                     
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 176 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                             if (item.OpponentSecond is null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <p> TBD </p>");
#nullable restore
#line 178 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                            }
                            else
                            {
                                var toShow = item.OpponentSecond.FirstName + " Licence:" + item.LicenceNumberSecond;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 182 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                           Write(Html.DisplayFor(modelItem => toShow));

#line default
#line hidden
#nullable disable
#nullable restore
#line 182 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                                                     
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 187 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                             if (item.OpponentSecondID != null && item.OpponentFirstID != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91d4896c898355969e7ba1d2696c33c170ae312420813", async() => {
                WriteLiteral("Set result");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 189 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                                                                                WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 190 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 195 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 198 "C:\Users\Aleksander\Desktop\studia\PAI\TournamentsWebApp\Views\Tournaments\Started.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91d4896c898355969e7ba1d2696c33c170ae312424013", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TournamentsWebApp.Models.ViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

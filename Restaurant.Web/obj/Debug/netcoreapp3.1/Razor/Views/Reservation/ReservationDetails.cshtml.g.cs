#pragma checksum "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "989d67c6fe7a3a0df5bdd2206c5d229118ca55a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservation_ReservationDetails), @"mvc.1.0.view", @"/Views/Reservation/ReservationDetails.cshtml")]
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
#line 1 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\_ViewImports.cshtml"
using Restaurant.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\_ViewImports.cshtml"
using Restaurant.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"989d67c6fe7a3a0df5bdd2206c5d229118ca55a8", @"/Views/Reservation/ReservationDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"485c25638e878be3fd8368c1c632d215895379af", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservation_ReservationDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Restaurant.Shared.ReservationDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
  
    ViewData["Title"] = "Reservation Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Reservation Details</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ReservationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayFor(model => model.ReservationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.GuestNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayFor(model => model.GuestNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ReservationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayFor(model => model.ReservationDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.MenuTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
        Write(Enum.GetName(typeof(Restaurant.Shared.Enums.MenuTypeEnum), Model.MenuTypeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Notes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "D:\Ismail\Projects\Restaurant\Restaurant.Web\Views\Reservation\ReservationDetails.cshtml"
       Write(Html.DisplayFor(model => model.Notes));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Restaurant.Shared.ReservationDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
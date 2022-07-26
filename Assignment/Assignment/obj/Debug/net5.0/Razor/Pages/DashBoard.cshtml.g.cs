#pragma checksum "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\DashBoard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9fd52813d5050fa18a0ee0a877093e924cc5ef9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Assignment.Pages.Pages_DashBoard), @"mvc.1.0.razor-page", @"/Pages/DashBoard.cshtml")]
namespace Assignment.Pages
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
#line 1 "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\_ViewImports.cshtml"
using Assignment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9fd52813d5050fa18a0ee0a877093e924cc5ef9", @"/Pages/DashBoard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49eaff204b995226a63d064c3bca75c87fbc22ec", @"/Pages/_ViewImports.cshtml")]
    public class Pages_DashBoard : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<p class=""h1 text-center mb-2"">Dashboard</p>
<div class=""d-flex justify-content-around"">
    <div class=""card text-center m-1"">
        <div class=""card-header bg-success text-white h2"">
            User In System:
        </div>
        <div class=""card-body"">
            <h5 class=""card-title"">Number of User:</h5>
            <p class=""card-text""><strong>");
#nullable restore
#line 14 "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\DashBoard.cshtml"
                                    Write(Model.UserNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></p>
        </div>
    </div>
    <div class=""card text-center m-1"">
        <div class=""card-header bg-secondary text-white h2"">
            Comment In System:
        </div>
        <div class=""card-body"">
            <h5 class=""card-title"">Number of Comment</h5>
            <p class=""card-text""><strong>");
#nullable restore
#line 23 "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\DashBoard.cshtml"
                                    Write(Model.CommentNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</strong></p>
        </div>
    </div>
    <div class=""card text-center m-1"">
        <div class=""card-header bg-warning text-white h2"">
            Rating In System:
        </div>
        <div class=""card-body"">
            <h5 class=""card-title"">Number of Rating</h5>
            <p class=""card-text""><Strong>");
#nullable restore
#line 32 "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\DashBoard.cshtml"
                                    Write(Model.RatingNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</Strong></p>\r\n        </div>\r\n    </div>\r\n</div>\r\n<canvas id=\"myChart\" style=\"width:100%;max-width:600px\" class=\"mt-2\"></canvas>\r\n\r\n<script>\r\n    var xValues = [\"User\", \"Comment\", \"Rating\"];\r\n    var yValues = [");
#nullable restore
#line 40 "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\DashBoard.cshtml"
              Write(Model.UserNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 40 "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\DashBoard.cshtml"
                                Write(Model.CommentNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 40 "C:\Users\MY LAPTOP\source\repos\Assignment\Assignment\Pages\DashBoard.cshtml"
                                                     Write(Model.RatingNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"];
    var barColors = [""green"", ""blue"",""yellow""];

new Chart(""myChart"", {
  type: ""bar"",
  data: {
    labels: xValues,
    datasets: [{
      backgroundColor: barColors,
      data: yValues
    }]
  },
  options: {
    legend: {display: false},
    title: {
      display: true,
      text: ""System""
    }
  }
});
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Assignment.Pages.DashBoardModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Assignment.Pages.DashBoardModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Assignment.Pages.DashBoardModel>)PageContext?.ViewData;
        public Assignment.Pages.DashBoardModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

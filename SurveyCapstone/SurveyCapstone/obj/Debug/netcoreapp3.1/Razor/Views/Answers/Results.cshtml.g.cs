#pragma checksum "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84540d1970beb8dbf48d7e3ba739fb18e71dd660"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Answers_Results), @"mvc.1.0.view", @"/Views/Answers/Results.cshtml")]
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
#line 1 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\_ViewImports.cshtml"
using SurveyCapstone;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\_ViewImports.cshtml"
using SurveyCapstone.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84540d1970beb8dbf48d7e3ba739fb18e71dd660", @"/Views/Answers/Results.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03f818b6a2b523203be44b6e749f3fe98e6fb1d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Answers_Results : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SurveyCapstone.Models.Answer>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n");
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n");
            WriteLiteral("            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml"
           Write(Html.DisplayNameFor(model => model.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml"
           Write(Html.DisplayNameFor(model => model.Question));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Answer\r\n");
            WriteLiteral("\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 36 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n");
            WriteLiteral("            <td>\r\n                ");
#nullable restore
#line 45 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml"
           Write(Html.DisplayFor(modelItem => item.User.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml"
           Write(Html.DisplayFor(modelItem => item.Question.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml"
           Write(Html.DisplayFor(modelItem => item.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n\r\n");
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 61 "C:\Users\Mikael\Documents\GitHub\CS-460\SurveyCapstone\SurveyCapstone\Views\Answers\Results.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SurveyCapstone.Models.Answer>> Html { get; private set; }
    }
}
#pragma warning restore 1591

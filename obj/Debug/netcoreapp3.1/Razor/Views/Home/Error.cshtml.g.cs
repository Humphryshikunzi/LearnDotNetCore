#pragma checksum "C:\Users\user\source\repos\LearnDotNetCore\Views\Home\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38faf2abf3a163ede25466c6a626e897fedca90a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LearnDotNetCore.Pages.Home.Views_Home_Error), @"mvc.1.0.view", @"/Views/Home/Error.cshtml")]
namespace LearnDotNetCore.Pages.Home
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
#line 1 "C:\Users\user\source\repos\LearnDotNetCore\Views\_ViewImports.cshtml"
using LearnDotNetCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\LearnDotNetCore\Views\_ViewImports.cshtml"
using LearnDotNetCore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\source\repos\LearnDotNetCore\Views\_ViewImports.cshtml"
using LearnDotNetCore.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\source\repos\LearnDotNetCore\Views\_ViewImports.cshtml"
using LearnDotNetCore.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38faf2abf3a163ede25466c6a626e897fedca90a", @"/Views/Home/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8624801dcc4a48c7f5e42c6938dd17801657581", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\user\source\repos\LearnDotNetCore\Views\Home\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"text-danger\">Error.</h1>\r\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\user\source\repos\LearnDotNetCore\Views\Home\Error.cshtml"
 if (Model.ShowRequestId)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        <strong>Request ID:</strong> <code>");
#nullable restore
#line 11 "C:\Users\user\source\repos\LearnDotNetCore\Views\Home\Error.cshtml"
                                      Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\r\n    </p>\r\n");
#nullable restore
#line 13 "C:\Users\user\source\repos\LearnDotNetCore\Views\Home\Error.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>Development Mode</h3>
<p>
    Swapping to the <strong>Development</strong>
    environment displays detailed information about the error that occurred.
</p>
<p>
    <strong>The Development environment shouldn't be enabled for deployed applications.</strong>
    It can result in displaying sensitive information from exceptions to end users.
    For local debugging, enable the <strong>Development</strong> environment by setting the
    <strong>ASPNETCORE_ENVIRONMENT</strong> environment variable to <strong>Development</strong>
    and restarting the app.
</p>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\Home\HotMeal.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "cdb66706ab56b2e9c24f424da9fe2691c65e5325099b0e286c65878bc65de7b4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCoreGeneratedDocument.Views_Home_HotMeal), @"mvc.1.0.view", @"/Views/Home/HotMeal.cshtml")]
namespace AspNetCoreGeneratedDocument
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\_ViewImports.cshtml"
using intro

#nullable disable
    ;
#nullable restore
#line 2 "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\_ViewImports.cshtml"
using intro.Models

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"cdb66706ab56b2e9c24f424da9fe2691c65e5325099b0e286c65878bc65de7b4", @"/Views/Home/HotMeal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"14aa81cfd07bcfe1b330094d1ee797cb6d33a182b2bc74a49cdb0be020ccba8b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    internal sealed class Views_Home_HotMeal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<
#nullable restore
#line 1 "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\Home\HotMeal.cshtml"
       IEnumerable<intro.entity.HotMeal>

#line default
#line hidden
#nullable disable
    >
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cdb66706ab56b2e9c24f424da9fe2691c65e5325099b0e286c65878bc65de7b43461", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\Home\HotMeal.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable

                WriteLiteral("        <div>\r\n            <h2>Id: ");
                Write(
#nullable restore
#line 7 "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\Home\HotMeal.cshtml"
                     item.id

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("</h2>\r\n            <h2>Name:");
                Write(
#nullable restore
#line 8 "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\Home\HotMeal.cshtml"
                      item.name

#line default
#line hidden
#nullable disable
                );
                WriteLiteral(" </h2>\r\n            <h2>Price: ");
                Write(
#nullable restore
#line 9 "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\Home\HotMeal.cshtml"
                        item.price

#line default
#line hidden
#nullable disable
                );
                WriteLiteral("</h2>\r\n        </div>\r\n");
#nullable restore
#line 11 "C:\Users\User\Desktop\GitHub\asp.net\intro\intro\Views\Home\HotMeal.cshtml"
    }

#line default
#line hidden
#nullable disable

            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<intro.entity.HotMeal>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "D:\.NetCore\ZumbaApp\ZumbaApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dcc32e5acfa6fa5ff9dc2daf0c62c8e297cee113"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\.NetCore\ZumbaApp\ZumbaApp\Views\_ViewImports.cshtml"
using ZumbaApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\.NetCore\ZumbaApp\ZumbaApp\Views\_ViewImports.cshtml"
using ZumbaApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dcc32e5acfa6fa5ff9dc2daf0c62c8e297cee113", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a816288a7adc527d9d9667a5083900a67c176afa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "alpha", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "old-new", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "new-old", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "recent", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex align-items-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\.NetCore\ZumbaApp\ZumbaApp\Views\Home\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""main-container"">
    <section class=""bg-dark space-sm"">
        <div class=""main-carousel""
        data-flickity='{ ""cellAlign"": ""center"", ""contain"": true, ""prevNextButtons"": false, ""pageDots"":false, ""wrapAround"":true, ""autoPlay"":5000, ""imagesLoaded"":true }'>

            <div class=""carousel-cell col-9 col-md-8 col-lg-5 text-center"">
                <a href=""#"" class=""d-block mb-3"">
                    <img alt=""Image"" src=""assets/img/graphic-product-bench.jpg"" class=""img-fluid rounded"" />
                </a>
                <span class=""h6"">Bench - Accounting for creative people</span>
            </div>

            <div class=""carousel-cell col-9 col-md-8 col-lg-5 text-center"">
                <a href=""#"" class=""d-block mb-3"">
                    <img alt=""Image"" src=""assets/img/graphic-product-kin.jpg"" class=""img-fluid rounded"" />
                </a>
                <span class=""h6"">Kin - The digital fashion assistant</span>
            </div>

            <div class=""c");
            WriteLiteral(@"arousel-cell col-9 col-md-8 col-lg-5 text-center"">
                <a href=""#"" class=""d-block mb-3"">
                    <img alt=""Image"" src=""assets/img/graphic-product-paydar.jpg"" class=""img-fluid rounded"" />
                </a>
                <span class=""h6"">Paydar - Location based touch payments</span>
            </div>

            <div class=""carousel-cell col-9 col-md-8 col-lg-5 text-center"">
                <a href=""#"" class=""d-block mb-3"">
                    <img alt=""Image"" src=""assets/img/graphic-product-pitstop.jpg"" class=""img-fluid rounded"" />
                </a>
                <span class=""h6"">Pitstop - Browser-based project management</span>
            </div>

        </div>
    </section>
    <section class=""space-sm"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col text-center"">
                    <div class=""mb-3"">
                        <a href=""#"" class=""btn btn-secondary mb-1"">Technology</a>
                    ");
            WriteLiteral(@"    <a href=""#"" class=""btn btn-secondary mb-1"">Lifestyle</a>
                        <a href=""#"" class=""btn btn-secondary mb-1"">Marketing</a>
                        <a href=""#"" class=""btn btn-secondary mb-1"">Health &amp; Fitness</a>
                        <a href=""#"" class=""btn btn-secondary mb-1"">Music</a>
                        <a href=""#"" class=""btn btn-secondary mb-1"">Productivity</a>
                    </div>
                    <a href=""#"" class=""text-small"">Explore all categories &rsaquo;</a>
                </div>
                <!--end of col-->
            </div>
            <!--end of row-->
        </div>
        <!--end of container-->
    </section>
    <!--end of section-->
    <section class=""space-sm flush-with-above"">
        <div class=""container"">
            <div class=""row mb-4"">
                <div class=""col-12 d-flex justify-content-between"">
                    <div>
                        <span class=""text-muted text-small"">Results 1 - 12 of 25</span>
   ");
            WriteLiteral("                 </div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc32e5acfa6fa5ff9dc2daf0c62c8e297cee1138317", async() => {
                WriteLiteral("\r\n                        <span class=\"mr-2 text-muted text-small text-nowrap\">Sort by:</span>\r\n                        <select class=\"custom-select\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc32e5acfa6fa5ff9dc2daf0c62c8e297cee1138761", async() => {
                    WriteLiteral("Alphabetical");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc32e5acfa6fa5ff9dc2daf0c62c8e297cee11310018", async() => {
                    WriteLiteral("Newest");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc32e5acfa6fa5ff9dc2daf0c62c8e297cee11311593", async() => {
                    WriteLiteral("Popular");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dcc32e5acfa6fa5ff9dc2daf0c62c8e297cee11312846", async() => {
                    WriteLiteral("Recently Updated");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </select>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </div>
                <!--end of col-->
            </div>
            <!--end of row-->
            <ul class=""row feature-list feature-list-sm"">

                <li class=""col-12 col-md-6 col-lg-4"">
                    <div class=""card"">
                        <a href=""#"">
                            <img class=""card-img-top"" src=""assets/img/graphic-product-sidekick.jpg""
                            alt=""Card image cap"">
                        </a>
                        <div class=""card-body"">
                            <h4 class=""card-title"">Sidekick</h4>
                            <p class=""card-text"">Holistic fitness tracking</p>
                        </div>
                        <div class=""card-footer card-footer-borderless d-flex justify-content-between"">
                            <div class=""text-small"">
                                <ul class=""list-inline"">
                                    <li class=""list-inline-item""><i class=""icon-heart""></i> ");
            WriteLiteral(@"221</li>
                                    <li class=""list-inline-item""><i class=""icon-message""></i> 14</li>
                                </ul>
                            </div>
                            <div class=""dropup"">
                                <button class=""btn btn-sm btn-outline-primary dropdown-toggle dropdown-toggle-no-arrow""
                                type=""button"" id=""SidekickButton"" data-toggle=""dropdown"" aria-haspopup=""true""
                                aria-expanded=""false"">
                                    <i class=""icon-dots-three-horizontal""></i>
                                </button>
                                <div class=""dropdown-menu dropdown-menu-sm"" aria-labelledby=""SidekickButton"">
                                    <a class=""dropdown-item"" href=""#"">Save</a>
                                    <a class=""dropdown-item"" href=""#"">Share</a>
                                    <a class=""dropdown-item"" href=""#"">Comment</a>
                    ");
            WriteLiteral(@"                <div class=""dropdown-divider""></div>
                                    <a class=""dropdown-item"" href=""#"">Report</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <!--end of col-->

                <li class=""col-12 col-md-6 col-lg-4"">
                    <div class=""card"">
                        <a href=""#"">
                            <img class=""card-img-top"" src=""assets/img/graphic-product-pitstop.jpg"" alt=""Card image cap"">
                        </a>
                        <div class=""card-body"">
                            <h4 class=""card-title"">Pitstop</h4>
                            <p class=""card-text"">Browser-based project management</p>
                        </div>
                        <div class=""card-footer card-footer-borderless d-flex justify-content-between"">
                            <div class=""text-small"">
               ");
            WriteLiteral(@"                 <ul class=""list-inline"">
                                    <li class=""list-inline-item""><i class=""icon-heart""></i> 90</li>
                                    <li class=""list-inline-item""><i class=""icon-message""></i> 34</li>
                                </ul>
                            </div>
                            <div class=""dropup"">
                                <button class=""btn btn-sm btn-outline-primary dropdown-toggle dropdown-toggle-no-arrow""
                                type=""button"" id=""PitstopButton"" data-toggle=""dropdown"" aria-haspopup=""true""
                                aria-expanded=""false"">
                                    <i class=""icon-dots-three-horizontal""></i>
                                </button>
                                <div class=""dropdown-menu dropdown-menu-sm"" aria-labelledby=""PitstopButton"">
                                    <a class=""dropdown-item"" href=""#"">Save</a>
                                    <a class=""dropdo");
            WriteLiteral(@"wn-item"" href=""#"">Share</a>
                                    <a class=""dropdown-item"" href=""#"">Comment</a>
                                    <div class=""dropdown-divider""></div>
                                    <a class=""dropdown-item"" href=""#"">Report</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <!--end of col-->

                <li class=""col-12 col-md-6 col-lg-4"">
                    <div class=""card"">
                        <a href=""#"">
                            <img class=""card-img-top"" src=""assets/img/graphic-product-pipeline.jpg""
                            alt=""Card image cap"">
                        </a>
                        <div class=""card-body"">
                            <h4 class=""card-title"">pipeline.js</h4>
                            <p class=""card-text"">Snappy UI interaction library with flexible API</p>
                        <");
            WriteLiteral(@"/div>
                        <div class=""card-footer card-footer-borderless d-flex justify-content-between"">
                            <div class=""text-small"">
                                <ul class=""list-inline"">
                                    <li class=""list-inline-item""><i class=""icon-heart""></i> 84</li>
                                    <li class=""list-inline-item""><i class=""icon-message""></i> 25</li>
                                </ul>
                            </div>
                            <div class=""dropup"">
                                <button class=""btn btn-sm btn-outline-primary dropdown-toggle dropdown-toggle-no-arrow""
                                type=""button"" id=""pipeline.jsButton"" data-toggle=""dropdown"" aria-haspopup=""true""
                                aria-expanded=""false"">
                                    <i class=""icon-dots-three-horizontal""></i>
                                </button>
                                <div class=""dropdown-menu");
            WriteLiteral(@" dropdown-menu-sm"" aria-labelledby=""pipeline.jsButton"">
                                    <a class=""dropdown-item"" href=""#"">Save</a>
                                    <a class=""dropdown-item"" href=""#"">Share</a>
                                    <a class=""dropdown-item"" href=""#"">Comment</a>
                                    <div class=""dropdown-divider""></div>
                                    <a class=""dropdown-item"" href=""#"">Report</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <!--end of col-->

                <li class=""col-12 col-md-6 col-lg-4"">
                    <div class=""card"">
                        <a href=""#"">
                            <img class=""card-img-top"" src=""assets/img/graphic-product-paydar.jpg"" alt=""Card image cap"">
                        </a>
                        <div class=""card-body"">
                            <h4 class=");
            WriteLiteral(@"""card-title"">Paydar</h4>
                            <p class=""card-text"">Location based touch payments</p>
                        </div>
                        <div class=""card-footer card-footer-borderless d-flex justify-content-between"">
                            <div class=""text-small"">
                                <ul class=""list-inline"">
                                    <li class=""list-inline-item""><i class=""icon-heart""></i> 253</li>
                                    <li class=""list-inline-item""><i class=""icon-message""></i> 19</li>
                                </ul>
                            </div>
                            <div class=""dropup"">
                                <button class=""btn btn-sm btn-outline-primary dropdown-toggle dropdown-toggle-no-arrow""
                                type=""button"" id=""PaydarButton"" data-toggle=""dropdown"" aria-haspopup=""true""
                                aria-expanded=""false"">
                                    <i class=""ico");
            WriteLiteral(@"n-dots-three-horizontal""></i>
                                </button>
                                <div class=""dropdown-menu dropdown-menu-sm"" aria-labelledby=""PaydarButton"">
                                    <a class=""dropdown-item"" href=""#"">Save</a>
                                    <a class=""dropdown-item"" href=""#"">Share</a>
                                    <a class=""dropdown-item"" href=""#"">Comment</a>
                                    <div class=""dropdown-divider""></div>
                                    <a class=""dropdown-item"" href=""#"">Report</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <!--end of col-->

                <li class=""col-12 col-md-6 col-lg-4"">
                    <div class=""card"">
                        <a href=""#"">
                            <img class=""card-img-top"" src=""assets/img/graphic-product-kin.jpg"" alt=""Card image c");
            WriteLiteral(@"ap"">
                        </a>
                        <div class=""card-body"">
                            <h4 class=""card-title"">Kin</h4>
                            <p class=""card-text"">The digital fashion assistant</p>
                        </div>
                        <div class=""card-footer card-footer-borderless d-flex justify-content-between"">
                            <div class=""text-small"">
                                <ul class=""list-inline"">
                                    <li class=""list-inline-item""><i class=""icon-heart""></i> 84</li>
                                    <li class=""list-inline-item""><i class=""icon-message""></i> 21</li>
                                </ul>
                            </div>
                            <div class=""dropup"">
                                <button class=""btn btn-sm btn-outline-primary dropdown-toggle dropdown-toggle-no-arrow""
                                type=""button"" id=""KinButton"" data-toggle=""dropdown"" aria-haspop");
            WriteLiteral(@"up=""true""
                                aria-expanded=""false"">
                                    <i class=""icon-dots-three-horizontal""></i>
                                </button>
                                <div class=""dropdown-menu dropdown-menu-sm"" aria-labelledby=""KinButton"">
                                    <a class=""dropdown-item"" href=""#"">Save</a>
                                    <a class=""dropdown-item"" href=""#"">Share</a>
                                    <a class=""dropdown-item"" href=""#"">Comment</a>
                                    <div class=""dropdown-divider""></div>
                                    <a class=""dropdown-item"" href=""#"">Report</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <!--end of col-->

                <li class=""col-12 col-md-6 col-lg-4"">
                    <div class=""card"">
                        <a href=""#"">");
            WriteLiteral(@"
                            <img class=""card-img-top"" src=""assets/img/graphic-product-bench.jpg"" alt=""Card image cap"">
                        </a>
                        <div class=""card-body"">
                            <h4 class=""card-title"">Bench</h4>
                            <p class=""card-text"">Accounting for creative people</p>
                        </div>
                        <div class=""card-footer card-footer-borderless d-flex justify-content-between"">
                            <div class=""text-small"">
                                <ul class=""list-inline"">
                                    <li class=""list-inline-item""><i class=""icon-heart""></i> 373</li>
                                    <li class=""list-inline-item""><i class=""icon-message""></i> 62</li>
                                </ul>
                            </div>
                            <div class=""dropup"">
                                <button class=""btn btn-sm btn-outline-primary dropdown-toggle dro");
            WriteLiteral(@"pdown-toggle-no-arrow""
                                type=""button"" id=""BenchButton"" data-toggle=""dropdown"" aria-haspopup=""true""
                                aria-expanded=""false"">
                                    <i class=""icon-dots-three-horizontal""></i>
                                </button>
                                <div class=""dropdown-menu dropdown-menu-sm"" aria-labelledby=""BenchButton"">
                                    <a class=""dropdown-item"" href=""#"">Save</a>
                                    <a class=""dropdown-item"" href=""#"">Share</a>
                                    <a class=""dropdown-item"" href=""#"">Comment</a>
                                    <div class=""dropdown-divider""></div>
                                    <a class=""dropdown-item"" href=""#"">Report</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
                <!--end of col-->

         ");
            WriteLiteral("   </ul>\r\n            <!--end of row-->\r\n        </div>\r\n        <!--end of container-->\r\n    </section>\r\n</div>");
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

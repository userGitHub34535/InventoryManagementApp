#pragma checksum "C:\Users\sheila.subbiah\source\repos\InventoryManagementApp\InventoryManagementApp\Views\TakeInventory\ModalPopUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "765c26570b78be3eeec155b4e718c12bb4f10dbf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TakeInventory_ModalPopUp), @"mvc.1.0.view", @"/Views/TakeInventory/ModalPopUp.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"765c26570b78be3eeec155b4e718c12bb4f10dbf", @"/Views/TakeInventory/ModalPopUp.cshtml")]
    public class Views_TakeInventory_ModalPopUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\sheila.subbiah\source\repos\InventoryManagementApp\InventoryManagementApp\Views\TakeInventory\ModalPopUp.cshtml"
  
    ViewBag.Title = "Add Inventory - Modal PopUp";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<title>");
#nullable restore
#line 6 "C:\Users\sheila.subbiah\source\repos\InventoryManagementApp\InventoryManagementApp\Views\TakeInventory\ModalPopUp.cshtml"
  Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</title>\r\n\r\n<!-- Button to trigger modal -->\r\n<a href=\"#\" id=\"addItem\" ");
            WriteLiteral(">Add Item?</a>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var PostBackURL = '/TakeInventory/Details';
        alert('Javascript loaded=scripts running');

        $(""#addItem"").click(function () {
        //$(""#anchorDetail"").click(function () {
            alert('anchor link was clicked');
            var $buttonClicked = $(this);
            var id = $buttonClicked.attr('data-id');
            var options = { ""backdrop"": ""static"", keyboard: true };
            $.ajax({
                type: ""GET"",
                url: PostBackURL,
                contentType: ""application/json; charset=utf-8"",
                data: { ""Id"": id },
                datatype: ""json"",
                success: function (data) {
                    $('#myModalContent').html(data);
                    $('#myModal').modal(options);
                    $('#myModal').modal('show');
                },
                error: function () {
                    alert(""Dynamic content load failed."");
                }
            });
        });

  ");
                WriteLiteral("      $(document).on(\"click\", \"#closbtn\", function () {\r\n            alert(\'closbtn was clicked\');\r\n            $(\'#myModal\').modal(\'hide\');\r\n        });\r\n    </script>\r\n");
            }
            );
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

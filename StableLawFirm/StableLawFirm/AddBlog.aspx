<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddBlog.aspx.cs" Inherits="StableLawFirm.AddBlog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="blog-single-page">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right blog-page-main-content">
                            <div class="single-news-postTwo">
                                <div class="img-container headingcontainer">
                                    <h1 class="Quote_title1">
                                        <asp:Label ID="lblHeadText" runat="server"></asp:Label></h1>
                                </div>


                                <div class="post posts">
                                    <div class="col-md-12">
                                        <div class="col-md-4">

                                            <asp:Label ID="Label1" runat="server" CssClass="labelcls" Text="Image"></asp:Label>
                                        </div>
                                        <div class="col-md-4">
                                            <asp:FileUpload ID="FileUpload" runat="server" />
                                            <asp:HiddenField ID="Updateid" runat="server" />



                                            <%--  <cc1:AsyncFileUpload  runat="server" ID="AsyncFileUpload1" Width="400px" OnUploadedComplete = "AsyncFileUpload1_UploadedComplete"   />--%>

                                            <%--  <cc1:AsyncFileUpload runat="server" ID="AsyncFileUpload1" Width="400px" UploaderStyle="Modern" />--%>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4"></div>
                                        <div class="col-md-4">
                                            <div id="image-holder" style="width: 150px;"></div>
                                            <asp:Image ID="img" runat="server" />
                                        </div>
                                    </div>


                                    <div class="col-md-12" style="margin-top: 20px;">
                                        <div class="col-md-4">
                                            <asp:Label ID="Label2" runat="server" CssClass="labelcls" Text="Title"></asp:Label>
                                        </div>
                                        <div class="col-md-4">

                                            <asp:TextBox CssClass="inputcls" placeholder="Title" ID="txtTitle" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <asp:Label ID="Label3" runat="server" CssClass="labelcls" Text="Text"></asp:Label>
                                        </div>
                                        <div class="col-md-4">

                                            <asp:TextBox CssClass="txtwidth" placeholder="Text" Columns="50" Rows="5" TextMode="MultiLine" ID="txtText" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <asp:Label ID="Label4" runat="server" CssClass="labelcls" Text="Publish Date"></asp:Label>
                                        </div>
                                        <div class="col-md-4">

                                            <asp:TextBox CssClass="inputcls savebtnnn" Placeholder="PublishDate" ID="txtPublishDate" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                            <asp:Label ID="Label5" runat="server" CssClass="labelcls" Text="Category"></asp:Label>
                                        </div>

                                        <div class="col-md-4">
                                            <asp:DropDownList ID="ddlCategory" AppendDataBoundItems="true" CssClass="inputcls savebtnnn" runat="server">
                                                <asp:ListItem Value="0" Text="select Category"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-4">
                                        </div>
                                        <div class="col-md-3 savebtnn">

                                            <%-- <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>--%>
                                            <asp:Button ID="btnSaveblog" runat="server" CssClass="theme-button1 hvr-bounce-to-right tran3s p-color-bg hvr-bounce-to-rightTwo" OnClientClick=" return ValidateBlog()" OnClick="btnSaveblog_Click"></asp:Button>
 <asp:Label runat="server" ID="ShowErrorMessage"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveblog" />
        </Triggers>
    </asp:UpdatePanel>


    <script>
        localStorage.setItem('lastTab1', "liAddBlog");
        $(('#<%= txtPublishDate.ClientID %>')).datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "-116:+0",
//        dateFormat: 'dd-mm-yy',
    });



    function ValidateBlog() {
        var Id = (!$('#<%= Updateid.ClientID %>').val());
        if (Id == true) {

            if (!$('#<%= FileUpload.ClientID %>').val()) {
                if ($('#<%= FileUpload.ClientID %>').parent().next(".validation").length == 0) // only add if not added
                {
                    $('#<%= FileUpload.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Select image</div>");
                }
                $('#<%= FileUpload.ClientID %>').focus();
                focusSet = true;
            }
            else {
                $('#<%= FileUpload.ClientID %>').parent().next(".validation").remove(); // remove it
            }
        }

        if (!$('#<%= txtTitle.ClientID %>').val()) {
            if ($('#<%= txtTitle.ClientID %>').parent().next(".validation").length == 0) // only add if not added
            {
                $('#<%= txtTitle.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Title</div>");
            }

        }
        else {
            $('#<%= txtTitle.ClientID %>').parent().next(".validation").remove(); // remove it
        }
        if (!$('#<%= txtText.ClientID %>').val()) {
            if ($('#<%= txtText.ClientID %>').parent().next(".validation").length == 0) // only add if not added
            {
                $('#<%= txtText.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Text</div>");
            }

        }
        else {
            $('#<%= txtText.ClientID %>').parent().next(".validation").remove(); // remove it
        }

        if (!$('#<%= txtPublishDate.ClientID %>').val()) {
            if ($('#<%= txtPublishDate.ClientID %>').parent().next(".validation").length == 0) // only add if not added
            {
                $('#<%= txtPublishDate.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Publish Date</div>");
            }

        }
        else {
            $('#<%= txtPublishDate.ClientID %>').parent().next(".validation").remove(); // remove it
        }

        if ($('#<%= ddlCategory.ClientID %>').val() == 0) {
            if ($('#<%= ddlCategory.ClientID %>').parent().next(".validation").length == 0) // only add if not added
            {
                $('#<%= ddlCategory.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Category</div>");
            }

        }
        else {
            $('#<%= ddlCategory.ClientID %>').parent().next(".validation").remove(); // remove it
        }

        Title = $('#<%= txtTitle.ClientID %>').val();
        Text = $('#<%= txtText.ClientID %>').val();
        published_Date = $('#<%= txtPublishDate.ClientID %>').val();
        Category = $('#<%= ddlCategory.ClientID %>').val();
        var files = $('#<%= FileUpload.ClientID %>').val();
        if (Id == true) {
            if (Title == "" || Text == "" || published_Date == "" || files == "" || Category == 0) {

                return false;
            }
        }
        else {
            if (Title == "" || Text == "" || published_Date == "" || Category == 0) {
                return false;
            }
        }
    };


    $('#<%= FileUpload.ClientID %>').on('change', function () {
            alert
            debugger;

            $('#<%= img.ClientID %>').hide();
        //Get count of selected files
        var countFiles = $(this)[0].files.length;
        var imgPath = $(this)[0].value;
        var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
        var image_holder = $("#image-holder");
        image_holder.empty();
        if (extn == "gif" || extn == "png" || extn == "jpg" || extn == "jpeg") {
            if (typeof (FileReader) != "undefined") {
                //loop for each file selected for uploaded.
                for (var i = 0; i < countFiles; i++) {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $("<img />",
                            {
                                "src": e.target.result,
                                "class": "thumb-image"
                            }).appendTo(image_holder);
                    }
                    image_holder.show();
                    reader.readAsDataURL($(this)[0].files[i]);
                }
            } else {

                alert("This browser does not support FileReader.");
            }
        }

        else {
            alert("Pls select only images");
            $('#<%= FileUpload.ClientID %>').val('');
        }
    });

    </script>

</asp:Content>

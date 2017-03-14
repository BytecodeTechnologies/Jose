<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/NJ_ClientAdmin.Master" CodeBehind="Excel.aspx.cs" Inherits="Excel.Excel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="https://fonts.googleapis.com/css?family=Roboto:400,300,100,500,700,900" rel="stylesheet" type="text/css" />
    <link href="assets/css/icons/icomoon/styles.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/core.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/components.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/colors.css" rel="stylesheet" type="text/css" />
    <!-- /global stylesheets -->

    <!-- Core JS files -->
    <script type="text/javascript" src="assets/js/plugins/loaders/pace.min.js"></script>
    <script type="text/javascript" src="assets/js/core/libraries/jquery.min.js"></script>
    <script type="text/javascript" src="assets/js/core/libraries/bootstrap.min.js"></script>
    <script type="text/javascript" src="assets/js/plugins/loaders/blockui.min.js"></script>
    <!-- /core JS files -->

    <!-- Theme JS files -->
    <script type="text/javascript" src="assets/js/plugins/uploaders/fileinput.min.js"></script>

    <script type="text/javascript" src="assets/js/core/app.js"></script>
    <script type="text/javascript" src="assets/js/pages/uploader_bootstrap.js"></script>
    <link href="css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-flat">
                    <div class="panel-heading">
                        <div class="col-md-12 homeheader">
                            File Upload
                        </div>
                    </div>
                    <div class="gridtopMargin">
                        <form class="form-horizontal">
                            <div class="form-group">
                                <center><label class="col-lg-6 control-label text-semibold"> file upload:</label></center>
                                <asp:FileUpload class="browser" ID="fileupload" runat="server" AllowMultiple="true" ></asp:FileUpload>
                                <div class="col-lg-6">
                                </div>
                            </div>
                            <asp:Button ID="btnSaveFile" class="btn btn-primary" runat="server" OnClick="Button1_Click" Text="Save Data" />
                        </form>
                    </div>
                    <div class="panel-body">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script>

        $(document).ready(function () {
            localStorage.setItem('lastTab', "LiSideHome");
            localStorage.setItem('lastTab1', "liTopHome");
            function loaderStart() {
                $('.loadercont').fadeIn();
            };
        });

        $('#<%= btnSaveFile.ClientID %>').click(function () {
            $('.loadercont').fadeIn();
        });

        $('#<%= fileupload.ClientID %>').on('change', function () {
            $('.loadercont').fadeIn();
            
            var countFiles = $(this)[0].files.length;
            var imgPath = $(this)[0].value;
            var extn = imgPath.substring(imgPath.lastIndexOf('.') + 1).toLowerCase();
            if (extn != "xls" && extn != "xlsx") {
                bootbox.alert("Please select only Excel File")
                $('#<%= fileupload.ClientID %>').val('');
                $('.loadercont').fadeOut();
            }
            $('.loadercont').fadeOut();
        });

        $(window).load(function () {
            $('.loadercont').fadeOut();
        })
    </script>
</asp:Content>





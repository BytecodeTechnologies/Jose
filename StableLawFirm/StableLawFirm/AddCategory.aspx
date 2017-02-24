<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="StableLawFirm.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="blog-single-page">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 pull-right blog-page-main-content">
                    <div class="single-news-postTwo">
                        <div class="img-container headingcontainer">
                           
                        </div>

                         <div class="col-md-12">

                            <h1 class="Quote_title1"><asp:Label ID="lblHeadText" runat="server"></asp:Label></h1>
                                  </div>
                        <div class="post posts">
                          

                              <div class="col-md-12">
                                <div class="col-md-4">
                                    <asp:HiddenField ID="Updateid" runat="server" />
                            <asp:Label ID="Label2" runat="server" CssClass="labelcls" Text="Category Name"></asp:Label>
                                    </div>
                                <div class="col-md-4">

                            <asp:TextBox  ID="txtCategory" placeholder="Category" CssClass="txtwidth" runat="server"></asp:TextBox>
                                      </div>
                                </div>
                       

            
                             <div class="col-md-12">
                                  <div class="col-md-4"></div>
                                <div class="col-md-4 savebtnn">

                            <asp:Button ID="btnSaveCategory" runat="server" CssClass="theme-button1 hvr-bounce-to-right tran3s p-color-bg hvr-bounce-to-rightTwo" OnClientClick ="SaveCategory(); return false "/>
                                    <%-- <button id="btnSendEmail" class="tran3s p-color-bg hvr-bounce-to-rightTwo">SEND EMAIL</button>--%>
                                    </div>
                                 </div>

                       
                        </div>
                        <!-- /.post -->
                    </div>
                    <!-- /.single-news-postTwo -->
                </div>
                <!-- /.blog-page-main-content -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </div>

     <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script>
        localStorage.setItem('lastTab1', "liAddCategory");


        //  $('#<%= btnSaveCategory.ClientID %>').click(function (evt) {

        function SaveCategory() {
            $('#<%= btnSaveCategory.ClientID %>').parent().next(".validation").remove();
            var focusSet = false;
            if (!$('#<%= txtCategory.ClientID %>').val().trim()) {
                   if ($('#<%= txtCategory.ClientID %>').parent().next(".validation").length == 0) // only add if not added
                   {
                       $('#<%= txtCategory.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter CAtegory</div>");
                   }
                   $('#<%= txtCategory.ClientID %>').focus();
                   focusSet = true;
               }
               else {
                   $('#<%= txtCategory.ClientID %>').parent().next(".validation").remove(); // remove it
               }


            var categoryName = $('#<%= txtCategory.ClientID %>').val().trim();
          
            var updateid = $('#<%= Updateid.ClientID %>').val();


            if (categoryName == "") {
                return
            }
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/AddCategory.aspx/AddCategorys",
                data: JSON.stringify({ categoryName: categoryName,updateid: updateid }),
                dataType: "Json",
                success: function (response) {
                    $('#<%= btnSaveCategory.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>" + response.d + "</div>");

                   },
                   error: function (response) {
                       alert(response.d);
                   }
               });



               };


</script>









</asp:Content>

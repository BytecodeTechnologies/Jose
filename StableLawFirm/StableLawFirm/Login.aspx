<%@ Page Title="" Language="C#" MasterPageFile="~/Stable.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StableLawFirm.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="blog-single-page">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 pull-right blog-page-main-content">
                    <div class="single-news-postTwo">
                        <div class="img-container headingcontainer">
                           
                        </div>

                         <div class="col-md-12">

                            <h1 class="Quote_title1"><asp:Label ID="lblHeadText" runat="server" Text="Admin Login"></asp:Label></h1>
                                  </div>
                        <div class="post posts">
                          

                              <div class="col-md-12">
                                <div class="col-md-4">
                                  
                            <asp:Label ID="Label2" runat="server" CssClass="labelcls" Text="UserName"></asp:Label>
                                    </div>
                                <div class="col-md-4">

                            <asp:TextBox  ID="txtUserName" CssClass="txtwidth" placeholder="UserName" runat="server"></asp:TextBox>
                                      </div>
                                </div>
                       

                              <div class="col-md-12">
                                <div class="col-md-4">
                            <asp:Label ID="Label4" runat="server" CssClass="labelcls" Text="Password"></asp:Label>
                                    </div>
                                <div class="col-md-4"> 
                                   <asp:TextBox id="txtUserPassword" CssClass="txtwidth"  placeholder="Password" TextMode="Password"  runat="server"  />
                                      </div>
                                </div>
                             <div class="col-md-12">
                                  <div class="col-md-4"></div>
                                <div class="col-md-4 savebtnn">

                            <asp:Button ID="btnLogin" runat="server" CssClass="theme-button1 hvr-bounce-to-right tran3s p-color-bg hvr-bounce-to-rightTwo" Text="Login" OnClientClick="Login(); return false" />
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



        //  $('#<%= btnLogin.ClientID %>').click(function (evt) {

        function Login() {

            $('#<%= btnLogin.ClientID %>').parent().next(".validation").remove();
            var focusSet = false;
            if (!$('#<%= txtUserName.ClientID %>').val().trim()) {
                   if ($('#<%= txtUserName.ClientID %>').parent().next(".validation").length == 0) // only add if not added
                   {
                       $('#<%= txtUserName.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter UserName</div>");
                   }
                   $('#<%= txtUserName.ClientID %>').focus();
                   focusSet = true;
               }
               else {
                   $('#<%= txtUserName.ClientID %>').parent().next(".validation").remove(); // remove it
               }
               if (!$('#<%= txtUserPassword.ClientID %>').val().trim()) {
                if ($('#<%= txtUserPassword.ClientID %>').parent().next(".validation").length == 0) // only add if not added
                {
                    $('#<%= txtUserPassword.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Password</div>");
                   }

               }
               else {
                   $('#<%= txtUserPassword.ClientID %>').parent().next(".validation").remove(); // remove it
            }
            var UserName = $('#<%= txtUserName.ClientID %>').val().trim();
            var Password = $('#<%= txtUserPassword.ClientID %>').val().trim();


            if (UserName == "" || Password == "") {
                return
            }
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Login.aspx/Logins",
                data: JSON.stringify({ UserName: UserName, Password: Password }),
                dataType: "Json",
                success: function (response) {

                    if (response.d == 1) {
                        $('#<%= btnLogin.ClientID %>').parent().next(".validation").remove();
                        window.location.href = "ResultList.aspx";
                    }
                    else {

                        $('#<%= btnLogin.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please check usrename or password</div>");
                  
                        $('#<%= txtUserPassword.ClientID %>').val('');
                       
                    }
                   },
                   error: function (response) {
                       alert(response.d);
                   }
               });
           };
</script>



</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddResult.aspx.cs" Inherits="StableLawFirm.Add_Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


           <div class="blog-single-page">
        <div class="container">
            <div class="row">
                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right blog-page-main-content">
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
                            <asp:Label ID="Label2" runat="server" CssClass="labelcls" Text="Result Heading"></asp:Label>
                                    </div>
                                <div class="col-md-4">

                            <asp:TextBox  ID="txtResultHeading" CssClass="txtwidth" placeholder="Result Heading" runat="server"></asp:TextBox>
                                      </div>
                                </div>
                       

                              <div class="col-md-12">
                                <div class="col-md-4">
                            <asp:Label ID="Label4" runat="server" CssClass="labelcls" Text="Result"></asp:Label>
                                    </div>
                                <div class="col-md-4">
                                   <asp:TextBox id="TxtResult" CssClass="txtwidth"  placeholder="Text" TextMode="multiline" Columns="50" Rows="5" runat="server"  />
                                      </div>
                                </div>
                             <div class="col-md-12">
                                  <div class="col-md-4"></div>
                                <div class="col-md-4 savebtnn">

                            <asp:Button ID="btnSaveResult" runat="server" CssClass="theme-button1 hvr-bounce-to-right tran3s p-color-bg hvr-bounce-to-rightTwo" OnClientClick="SaveResult(); return false" />
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
        localStorage.setItem('lastTab1', "liAddResult");
       

      //  $('#<%= btnSaveResult.ClientID %>').click(function (evt) {

        function SaveResult()
        {
             
               $('#<%= btnSaveResult.ClientID %>').parent().next(".validation").remove();
               var focusSet = false;
               if (!$('#<%= txtResultHeading.ClientID %>').val().trim()) {
                   if ($('#<%= txtResultHeading.ClientID %>').parent().next(".validation").length == 0) // only add if not added
                   {
                       $('#<%= txtResultHeading.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Result heading</div>");
                   }
                   $('#<%= txtResultHeading.ClientID %>').focus();
                   focusSet = true;
               }
               else {
                   $('#<%= txtResultHeading.ClientID %>').parent().next(".validation").remove(); // remove it
               }
            if (!$('#<%= TxtResult.ClientID %>').val().trim()) {
                   if ($('#<%= TxtResult.ClientID %>').parent().next(".validation").length == 0) // only add if not added
                   {
                       $('#<%= TxtResult.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter result</div>");
                   }

               }
               else {
                   $('#<%= TxtResult.ClientID %>').parent().next(".validation").remove(); // remove it
               }


            var Result_Heading = $('#<%= txtResultHeading.ClientID %>').val().trim();
            var Result_Text = $('#<%= TxtResult.ClientID %>').val().trim();
            var updateid = $('#<%= Updateid.ClientID %>').val();

             
               if (Result_Heading == "" || Result_Text == "") {
                   return
               }
               $.ajax({
                   type: "POST",
                   contentType: "application/json; charset=utf-8",
                   url: "/AddResult.aspx/AddResults",
                   data: JSON.stringify({ Result_Heading: Result_Heading, Result_Text: Result_Text, updateid: updateid }),
                   dataType: "Json",
                   success: function (response) {
                       $('#<%= btnSaveResult.ClientID %>').parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>"+ response.d+ "</div>");
                       $('#<%= txtResultHeading.ClientID %>').val('');
                       $('#<%= TxtResult.ClientID %>').val('');
                   },
                   error: function (response) {
                       alert(response.d);
                   }
               });
           };
           
        
</script>

</asp:Content>

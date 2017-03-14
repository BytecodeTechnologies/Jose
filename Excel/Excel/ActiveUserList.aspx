<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActiveUserList.aspx.cs" Inherits="Excel.ActiveUserList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Scripts/DataTable/bootstrap.min.css" rel="stylesheet" />
    <link href="Scripts/DataTable/dataTables.bootstrap.min.css" rel="stylesheet" />

<%--    <link href="Scripts/DataTable/bootstrap.min.css" rel="stylesheet" />
    <link href="Scripts/DataTable/dataTables.bootstrap.min.css" rel="stylesheet" />--%>
</head>
<body>
   
    <form id="form1" runat="server">
       
       <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
            <asp:Repeater id="repeater2" runat="server" >
                <HeaderTemplate>
    <thead>
        <tr>
             <th>First Name</th>
             <th>Last Name</th>
            <th>Address1</th>
             <th>Address2</th>
             <th>List Type</th>
             <th>File Date</th>
             <th>Court Name</th>
             <th>CourtDate</th>
            
             <th>MI</th>
             <th>City</th>
             <th>ST</th>
             <th>ZIP</th>
             <th>DOB</th>
             <th>Violation</th>
             <th>Description</th>
             <th>DateIssued</th>
             <th>Salutation</th>
             <th>Summons</th>
            <th>Summons</th>
            <%-- <th>Address1</th>--%>
            
        </tr>
    </thead>
                     </HeaderTemplate>
                 <ItemTemplate> 
        <tr>
            <td> <%# DataBinder.Eval(Container.DataItem, "F_Name")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "L_Name")%> <br /></td>
            <td> <%# DataBinder.Eval(Container.DataItem, "Address1")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "Address2")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "List_Type")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "File_Date")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "Court_Name")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "CourtDate")%> <br /></td>
            
             <td> <%# DataBinder.Eval(Container.DataItem, "MI")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "City")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "ST")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "ZIP")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "DOB")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "Violation")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "Description")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "DateIssued")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "Salutation")%> <br /></td>
             <td> <%# DataBinder.Eval(Container.DataItem, "Summons")%> <br /></td>
            

            <td><%--<button id="<%# DataBinder.Eval(Container.DataItem, "id")%>" CmmandName="cmd_Delete" CommandArgument='<%# Eval("customer_ID")%>'>IsUser</button>--%></td>

           
             
                     </ItemTemplate>
                 </asp:Repeater>
    </table>
                
    </form>
</body>
</html>


<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
<script src="Scripts/jquery-1.7.1.min.js"></script>
<script src="Scripts/jquery-1.7.1.js"></script>
<script src="Scripts/DataTable/jquery-1.12.3.js"></script>
<script src="Scripts/DataTable/jquery.dataTables.min.js"></script>
<script src="Scripts/DataTable/dataTables.bootstrap.min.js"></script>

<script>

    $(document).ready(function () {
        $('#example').DataTable();
    });


    function IsUser(id) {
        alert(id)
            $.ajax({
                type: "POST",
               contentType: "application/json; charset=utf-8",
                url: "/userlist.aspx/SaveExcel",
              //  data: JSON.stringify({file:'file'}) ,
                dataType: "json",
                //contentType: false,
                //processData: false,
                success: function (response) {
                   
                    alert(response.d);
                },
                error: function (response) {
                    alert("error");  
                }
            });
    }

</script>



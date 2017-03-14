<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Excel.Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <div class="row">
            <div class="col-lg-12" style="min-height: 100px !important;">

                <!-- Traffic sources -->
                <div class="panel panel-flat">
                    <div class="panel-heading">
                        <div class="col-md-12 homeheader">
                            Staff
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin">
                        <div class="col-md-12">
                            <div class="form-group">
                                <%--  <label class="control-label col-lg-2"> <asp:LinkButton ID="btnaddnewStaff" runat="server">Add New Staff Member</asp:LinkButton></label>--%>
                                <asp:HiddenField ID="hdnRole" runat="server" />
                                <label id="lblAddNewStaff" class="control-label col-lg-2"><a href="AddStaffMember.aspx" class="btn btn-primary">Add New Staff Member</a></label>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label class="control-label col-lg-2">UserRole</label>
                                    <div class="col-lg-10">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <select id="ddlSearchbyDate" class="form-control">
                                                    <option value="0">All</option>
                                                    <option value="1">Admin</option>
                                                    <option value="2">Users</option>

                                                </select>
                                               <%-- <div class="label-block">
                                                    <span class="label label-primary">Text</span>
                                                </div>--%>
                                            </div>

                                            <%--  <label class="control-label col-lg-2">Contains in</label>--%>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-12">
                                        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="190%">
                                            <thead>
                                                <tr class="top123">

                                                    <th>First Name</th>
                                                    <th>Last Name</th>
                                                    <th>State</th>
                                                    <th>Role</th>
                                                    <th>Delete</th>
                                                     <th>Edit</th>
                                                    <%--  <th>Total Payment</th>
                                                <th>Paid</th>
                                                <th>Balance</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody id="tblbody">
                                            </tbody>
                                        </table>
                                        <div id="dvPaging"></div>
                                    </div>
                                    <%--              <div id="popup1" class="overlay">
                                    <div class="popup">
                                        <h2>User Detail</h2>
                                        <a class="close" href="#">&times;</a>
                                        <div id="PopupData" class="content" style="max-height: 400px; overflow-y: scroll; max-width: 800px !important;">
                                        </div>
                                    </div>
                                </div>--%>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="Scripts/jquery-1.7.1.min.js"></script>
        <script src="Scripts/jquery-1.7.1.js"></script>
        <script src="Scripts/DataTable/jquery-1.12.3.js"></script>
        <script src="Scripts/DataTable/jquery.dataTables.min.js"></script>
        <script src="Scripts/DataTable/dataTables.bootstrap.min.js"></script>

        <script>

            $(document).ready(function () {
                $('.loadercont').fadeOut();
                //localStorage.setItem('lastTab', "liTopEmployee");
                localStorage.setItem('lastTab1', "liTopEmployee");
                Employees();
                var id = $('#<%= hdnRole.ClientID %>').val()
            if (id == 2) {
                $("#lblAddNewStaff").hide();
            }


        });

        $("#ddlSearchbyDate").change(function () {
            Employees();
            $('.loadercont').fadeOut();;
        });


        function Employees() {

            $('.loadercont').fadeIn();
            var Search = $("#ddlSearchbyDate").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Employee.aspx/Employees",
                data: JSON.stringify({ Search: Search, PageIndex: 0 }),
                dataType: "json",
                success: function (response) {
                 
                    $('#tblbody').empty();
                    console.log(response)
                    var tr;
                    var TotalRecords = "";
                    if (response.d.length > 0) {

                        for (var i = 0; i < response.d.length; i++) {
                            TotalRecords = response.d[i].TotalCount;
                            tr = $('<tr/>');
                            tr.append("<td> <a id=" + response.d[i].tblUserId + " onclick='userDetail(this.id)' style='cursor: pointer;'>" + response.d[i].First_Name + "  </a> </td>");
                            tr.append("<td>" + response.d[i].Last_Name + "</td>");
                            tr.append("<td>" + response.d[i].Email + "</td>");
                            if (response.d[i].tbl_RoleId == 1) {
                                tr.append("<td>admin</td>");
                            }
                            else {
                                tr.append("<td>Staff</td>");
                            }
                            tr.append("<td class='btndeletebyAdmin'> <input type='button' value='Delete' id=" + response.d[i].tblUserId + " onclick='DeleteEmployee(this.id)' style='cursor: pointer;' class='btn btn-primary '/></td>");
                            tr.append("<td class='btndeletebyAdmin'> <input type='button' value='Edit' id=" + response.d[i].tblUserId + " onclick='EditEmployee(this.id)' style='cursor: pointer;' class='btn btn-primary '/></td>");

                            $('#example').append(tr);
                        }
                    }
                    else {
                        tr = $('<tr/>');
                        tr.append("<td colspan='7'> No Item to Display</td>");
                        $('#example').append(tr);
                    }
                    $('#example').show();
                    $('.loadercont').fadeOut();

                    $('#dvPaging').empty();
                    if (TotalRecords != "") {
                        var paginglength = TotalRecords / 15;

                       
                        if (paginglength % 1 != 0) {
                            paginglength = paginglength + 1;
                            paginglength = Math.trunc(paginglength);
                        }

                        for (var p = 0; p < paginglength; p++) {
                          
                            $('#dvPaging').append('<input type="button" class="pagingstyle" id="' + p + '" value ="' + (p + 1) + '" onclick="Paging(this.id)"/>');
                        }
                        $("#dvPaging #0").addClass("activePage");

                    }
                },
                error: function (response) {
                }

            });
        };

        function Paging(Pageno) {
            $('.loadercont').fadeIn();
            var Search = $("#ddlSearchbyDate").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Employee.aspx/Employees",
                data: JSON.stringify({ Search: Search, PageIndex: Pageno }),
                dataType: "json",
                success: function (response) {
                  
                    $('#tblbody').empty();
                    console.log(response)
                    var tr;
                    var TotalRecords = "";
                    if (response.d.length > 0) {

                        for (var i = 0; i < response.d.length; i++) {
                            TotalRecords = response.d[i].TotalCount;
                            tr = $('<tr/>');
                            tr.append("<td> <a id=" + response.d[i].tblUserId + " onclick='userDetail(this.id)' style='cursor: pointer;'>" + response.d[i].First_Name + "  </a> </td>");
                            tr.append("<td>" + response.d[i].Last_Name + "</td>");
                            tr.append("<td>" + response.d[i].Email + "</td>");
                            if (response.d[i].tbl_RoleId == 1) {
                                tr.append("<td>admin</td>");
                            }
                            else {
                                tr.append("<td>Staff</td>");
                            }
                            $('#example').append(tr);
                        }
                    }
                    else {
                        tr = $('<tr/>');
                        tr.append("<td colspan='7'> No Item to Display</td>");
                        $('#example').append(tr);
                    }
                    $('#example').show();
                    $('.loadercont').fadeOut();

                    $('#dvPaging').empty();
                    if (TotalRecords != "") {
                        var paginglength = TotalRecords / 15;

                      
                        if (paginglength % 1 != 0) {
                            paginglength = paginglength + 1;
                            paginglength = Math.trunc(paginglength);
                        }

                        for (var p = 0; p < paginglength; p++) {
                           
                            $('#dvPaging').append('<input type="button" class="pagingstyle" id="' + p + '" value ="' + (p + 1) + '" onclick="Paging(this.id)"/>');
                        }
                        $("#dvPaging #" + Pageno + "").addClass("activePage");

                    }
                },
                error: function (response) {
                }

            });
        };




        function userDetail(id) {
            window.location.href = "ShowUsersbyEmployee.aspx?id=" + id;
        };
        function EditEmployee(id) {
            window.location.href = "AddStaffMember.aspx?id=" + id;
        };
        function DeleteEmployee(id) {
            bootbox.confirm("Are you sure?<br/> you want to delete.", function (result) {
                if (result) {
                    var Id = id;
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Employee.aspx/DeleteEmployee",
                        data: JSON.stringify({
                            Id: Id
                        }),
                        dataType: "Json",
                        dataType: "Json",
                        success: function (response) {
                            bootbox.alert('Employee Deleted Successfully');
                            Employees();
                            $('.loadercont').fadeOut();
                        },
                        error: function (response) {
                            $('.loadercont').fadeOut();
                        }
                    });
                }
            });
           
        }

        </script>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="ShowUsersbyEmployee.aspx.cs" Inherits="Excel.ShowUsersbyEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <asp:HiddenField ID="HdnUserRole" runat="server" />
        <div class="row">
            <div class="col-lg-12" style="min-height: 100px !important;">

                <!-- Traffic sources -->
                <div class="panel panel-flat">
                    <div class="panel-heading">
                        <div class="col-md-12 homeheader">
                            Sales By
                            <asp:Label ID="lblAddedby" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-lg-2">Search</label>
                                <div class="col-lg-10">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <asp:HiddenField ID="Userid" runat="server"></asp:HiddenField>
                                            <select id="ddlSearchbyDate" class="form-control">
                                                <option value="0">All</option>
                                                <option value="1">Today</option>
                                                <option value="2">Yesterday</option>
                                                <option value="14">Custom</option>
                                                <option value="3">This Week</option>
                                                <option value="4">This Month</option>
                                                <option value="5">This Quarter</option>
                                                <option value="6">This Year</option>
                                                <option value="7">Last Week</option>
                                                <option value="8">Last Two Weeks</option>
                                                <option value="9">Last Month</option>
                                                <option value="10">Last Two Months</option>
                                                <option value="11">Past Six Months</option>
                                                <option value="12">Last Year</option>
                                            </select>
                                            <div class="label-block">
                                                <span class="label label-primary">Text</span>
                                            </div>
                                        </div>

                                        
                                            <div class="col-md-3" id="startDateDiv" style="display: none;">
                                                <input id="txtStartDate" placeholder="Start Date" class="form-control pressenter" type="text" readonly="true" />

                                            </div>

                                            <div class="col-md-3" id="EndDateDiv" style="display: none;">
                                                <input id="txtEndDate" placeholder="End Date" class="form-control pressenter" type="text" readonly="true" />
                                            </div>
                                        
                                        <%--  <label class="control-label col-lg-2">Contains in</label>--%>
                                        <%--<div class="col-md-3">

                                            <label id="TotalPayment" style="margin-left: 68px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-primary">Total Payment</span>
                                            </div>
                                        </div>

                                        <div class="col-md-3">

                                            <label id="paidPayment" style="margin-left: 68px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-primary">Paid Payment</span>
                                            </div>
                                        </div>

                                        <div class="col-md-3">

                                            <label id="RemainingPayment" style="margin-left: 68px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-danger">Balance Payment</span>
                                            </div>
                                        </div>--%>
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
                                                <th>City</th>
                                                <th>Total Payment</th>
                                                <th>Paid</th>
                                                <th>Balance</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tblbody">
                                        </tbody>
                                    </table>
                                    <div id="dvPaging"></div>
                                </div>
                                <div id="popup1" class="overlay">
                                    <div class="popup">
                                        <h2>User Detail</h2>
                                        <a class="close" href="#">&times;</a>
                                        <div id="PopupData" class="content" style="max-height: 400px; overflow-y: scroll; max-width: 800px !important;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="Payment">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-7">

                                    </div>
                                    <div class="col-md-1">

                                            <label id="TotalPayment" style="margin-left: 30px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-primary">Total Payment</span>
                                            </div>
                                        </div>

                                        <div class="col-md-2">

                                            <label id="paidPayment" style="margin-left: 68px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-primary">Paid Payment</span>
                                            </div>
                                        </div>

                                        <div class="col-md-2">

                                            <label id="RemainingPayment" style="margin-left: 68px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-danger">Balance Payment</span>
                                            </div>
                                        </div>
                                </div>
                            </div>
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
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>

        $(document).ready(function () {
            //localStorage.setItem('lastTab', "liSideClients");
            //localStorage.setItem('lastTab1', "liTopClients");
            Clients();
            Payment();
            $('#txtStartDate,#txtEndDate').datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-116:+0",
                dateFormat: "m/d/yy"
            });
            var Roleid = $('#<%= HdnUserRole.ClientID %>').val()
            //Hide Admin Part for staff Members
            if (Roleid == "2") {
                $("#Payment").hide();
            }
        });

        $('#txtStartDate,#txtEndDate').change(function () {
            if ($('#txtStartDate').val() != "" && $('#txtEndDate').val() != "") {
                Clients();
                Payment();
            }
        });

        $("#ddlSearchbyDate").change(function () {
            debugger;
            $('#txtStartDate,#txtEndDate').val("");
            if ($("#ddlSearchbyDate").val() == '14') {
                $("#TotalPayment").empty();
                $("#paidPayment").empty();
                $("#RemainingPayment").empty();
                $("#TotalPayment").html('0');
                $("#paidPayment").html('0');
                $("#RemainingPayment").html('0');
                $('#tblbody').empty();
                $('#dvPaging').empty();               
                $('#startDateDiv,#EndDateDiv').css("display", "block");
            }
            else {
                $('#startDateDiv,#EndDateDiv').css("display", "none");
                Clients();
                Payment();
            }           
            
            $('.loadercont').fadeOut();;
        });




        function Clients() {
            var id = $('#<%= Userid.ClientID %>').val()

            $('.loadercont').fadeIn();
            var Search = $("#ddlSearchbyDate").val();
            var sDate = $('#txtStartDate').val();
            var eDate = $('#txtEndDate').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/ShowUsersbyEmployee.aspx/UserDetailsbyEmployeeAdded",
                data: JSON.stringify({ Search: Search, id: id, PageIndex: 0, sDate: sDate, eDate: eDate }),
                dataType: "Json",
                success: function (response) {

                    $('#tblbody').empty();
                    //var totalpayment = 0;
                    //var PaidPayment = 0;
                    //var BalancePayment = 0;
                    console.log(response)
                    var tr;
                    if (response.d.length > 0) {
                        var TotalRecords = "";
                        for (var i = 0; i < response.d.length; i++) {
                            TotalRecords = response.d[i].TotalRecords;
                            //totalpayment = totalpayment + response.d[i].Payment_Total;
                            //PaidPayment = PaidPayment + response.d[i].Payment_Paid;
                            //BalancePayment = BalancePayment + response.d[i].Payment_Balance;
                            tr = $('<tr/>');
                            //  tr.append("<td> <a id=" + response.d[i].Id + " onclick='userDetail(this.id)' style='cursor: pointer;'>" + response.d[i].F_Name + "  </a> </td>");
                            tr.append("<td>" + response.d[i].F_Name + "</td>");
                            tr.append("<td>" + response.d[i].L_Name + "</td>");
                            tr.append("<td>" + response.d[i].ST + "</td>");
                            tr.append("<td>" + response.d[i].City + "</td>");
                            if (response.d[i].Payment_Total != null) {
                                tr.append("<td>" + response.d[i].Payment_Total + "&nbsp;$</td>");
                            }
                            else {
                                tr.append("<td>0&nbsp;$</td>");
                            }
                            if (response.d[i].Payment_Paid != null) {
                                tr.append("<td>" + response.d[i].Payment_Paid + "&nbsp;$</td>");
                            }
                            else {
                                tr.append("<td>0&nbsp;$</td>");
                            }
                            if (response.d[i].Payment_Balance != null) {
                                tr.append("<td>" + response.d[i].Payment_Balance + "&nbsp;$</td>");
                            }
                            else {
                                tr.append("<td>0&nbsp;$</td>");
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
                    //$("#TotalPayment").empty();
                    //$("#paidPayment").empty();
                    //$("#RemainingPayment").empty();
                    //$("#TotalPayment").html(totalpayment);
                    //$("#paidPayment").html(PaidPayment);
                    //$("#RemainingPayment").html(BalancePayment);

                    // for paging
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

                    $('.loadercont').fadeOut();
                }

            });
        };

        function Paging(Pageno) {
            var id = $('#<%= Userid.ClientID %>').val()

            $('.loadercont').fadeIn();
            var Search = $("#ddlSearchbyDate").val();
            var sDate = $('#txtStartDate').val();
            var eDate = $('#txtEndDate').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/ShowUsersbyEmployee.aspx/UserDetailsbyEmployeeAdded",
                data: JSON.stringify({ Search: Search, id: id, PageIndex: Pageno, sDate: sDate, eDate: eDate }),
                dataType: "Json",
                success: function (response) {

                    $('#tblbody').empty();
                    //var totalpayment = 0;
                    //var PaidPayment = 0;
                    //var BalancePayment = 0;
                    console.log(response)
                    var tr;
                    if (response.d.length > 0) {
                        var TotalRecords = "";
                        for (var i = 0; i < response.d.length; i++) {
                            TotalRecords = response.d[i].TotalRecords;
                            //totalpayment = totalpayment + response.d[i].Payment_Total;
                            //PaidPayment = PaidPayment + response.d[i].Payment_Paid;
                            //BalancePayment = BalancePayment + response.d[i].Payment_Balance;
                            tr = $('<tr/>');
                            //  tr.append("<td> <a id=" + response.d[i].Id + " onclick='userDetail(this.id)' style='cursor: pointer;'>" + response.d[i].F_Name + "  </a> </td>");
                            tr.append("<td>" + response.d[i].F_Name + "</td>");
                            tr.append("<td>" + response.d[i].L_Name + "</td>");
                            tr.append("<td>" + response.d[i].ST + "</td>");
                            tr.append("<td>" + response.d[i].City + "</td>");
                            if (response.d[i].Payment_Total != null) {
                                tr.append("<td>" + response.d[i].Payment_Total + "&nbsp;$</td>");
                            }
                            else {
                                tr.append("<td>0&nbsp;$</td>");
                            }
                            if (response.d[i].Payment_Paid != null) {
                                tr.append("<td>" + response.d[i].Payment_Paid + "&nbsp;$</td>");
                            }
                            else {
                                tr.append("<td>0&nbsp;$</td>");
                            }
                            if (response.d[i].Payment_Balance != null) {
                                tr.append("<td>" + response.d[i].Payment_Balance + "&nbsp;$</td>");
                            }
                            else {
                                tr.append("<td>0&nbsp;$</td>");
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
                    //$("#TotalPayment").empty();
                    //$("#paidPayment").empty();
                    //$("#RemainingPayment").empty();
                    //$("#TotalPayment").html(totalpayment);
                    //$("#paidPayment").html(PaidPayment);
                    //$("#RemainingPayment").html(BalancePayment);

                    // for paging
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

                    $('.loadercont').fadeOut();
                }

            });
        };

        function Payment() {
            var id = $('#<%= Userid.ClientID %>').val()
            debugger;

            $('.loadercont').fadeIn();
            var Search = $("#ddlSearchbyDate").val();
            var sDate = $('#txtStartDate').val();
            var eDate = $('#txtEndDate').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/ShowUsersbyEmployee.aspx/ShowPayment",
                data: JSON.stringify({ Search: Search, id: id, sDate: sDate, eDate: eDate }),
                dataType: "Json",
                success: function (response) {
                    var totalpayment = 0;
                    var PaidPayment = 0;
                    var BalancePayment = 0;
                    if (response.d.length > 0) {
                        for (var i = 0; i < response.d.length; i++) {
                            totalpayment = totalpayment + response.d[i].Payment_Total;
                            PaidPayment = PaidPayment + response.d[i].Payment_Paid;
                            BalancePayment = BalancePayment + response.d[i].Payment_Balance;
                        }
                    }
                    $('.loadercont').fadeOut();
                    $("#TotalPayment").empty();
                    $("#paidPayment").empty();
                    $("#RemainingPayment").empty();
                    $("#TotalPayment").html(totalpayment);
                    $("#paidPayment").html(PaidPayment);
                    $("#RemainingPayment").html(BalancePayment);
                },
                error: function (response) {

                    $('.loadercont').fadeOut();
                }

            });
        };






    </script>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="Excel.Clients" %>

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
                            Client List
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin">
                        <div class="col-md-12">
                            <div class="form-group">
                                <asp:HiddenField ID="HdnUserRole" runat="server" />
                                <label class="control-label col-lg-1">Search</label>
                                <div class="col-lg-10">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <select id="ddlSearchbyDate" class="form-control">
                                                <option value="0">All</option>
                                                <option value="1" selected="selected">Today</option>
                                                <option value="2">Yesterday</option>
                                                <option value="14">Custom</option>
                                                <%--<option value="13">Day before Yesterday</option>--%>
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

                                            <%-- <div class="label-block">
                                                <span class="label label-primary">Text</span>
                                            </div>--%>
                                        </div>

                                        <%--  <label class="control-label col-lg-2">Contains in</label>--%>
                                        <div class="form-group">
                                            <div class="col-md-2" id="startDateDiv" style="display: none;">
                                                <input id="txtStartDate" placeholder="Start Date" class="form-control pressenter" type="text" readonly="true" />

                                            </div>

                                            <div class="col-md-2" id="EndDateDiv" style="display: none;">
                                                <input id="txtEndDate" placeholder="End Date" class="form-control pressenter" type="text" readonly="true" />
                                            </div>
                                            <label class="control-label col-lg-1">Added by</label>
                                            <div class="col-md-2">

                                                <select id="ddlStaff" class="form-control">
                                                    <option value="">Select</option>
                                                </select>
                                            </div>
                                            <div class="col-md-1">
                                                <label class="control-label col-lg-2">
                                                    <input type="button" id="btnreset" class="btn btn-primary" value="Reset" /></label>
                                            </div>
                                            <div class="col-md-2">
                                                <input type="button" id="btnEmailTodayRecords" class="btn btn-primary form-control" value="Mail Today's Report">
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <input type="button" value="Print" id="btnPrintFullGrid" class="btn btn-primary" style="float: right;" onclick="PrintFullGrid()" />
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
                                                    <th>Added By</th>
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
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                        </div>
                                        <div id="Payment">
                                            <div class="col-md-2" style="width: 13.666667%">


                                                <label id="TotalPayment" style="margin-left: 30px;" class="control-label"></label>
                                                <div>
                                                    <span class="label label-primary">Agreement Amount</span>
                                                </div>
                                            </div>
                                            <div class="col-md-2" style="width: 12.666667%">

                                                <label id="paidPayment" style="margin-left: 30px;" class="control-label"></label>
                                                <div>
                                                    <span class="label label-primary">Collected Amount</span>
                                                </div>

                                            </div>
                                            <div class="col-md-1">


                                                <label id="RemainingPayment" style="margin-left: 18px;" class="control-label"></label>
                                                <div>
                                                    <span class="label label-danger">Balance Payment</span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="printClients" style="display: none; border: 0px solid black;">
                    </div>
                </div>
            </div>
        </div>

        <script src="Scripts/jquery-1.7.1.min.js"></script>
        <script src="Scripts/jquery-1.7.1.js"></script>
        <script src="Scripts/DataTable/jquery-1.12.3.js"></script>
        <script src="Scripts/DataTable/jquery.dataTables.min.js"></script>
        <script src="Scripts/DataTable/dataTables.bootstrap.min.js"></script>

        <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">--%>
        <%--<script src="//code.jquery.com/jquery-1.10.2.js"></script>--%>
        <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

        <script>

            $(document).ready(function () {
                localStorage.setItem('lastTab', "liSideClients");
                localStorage.setItem('lastTab1', "liTopClients");
                BindDropDown();
                Clients();
                GenerateTableForAll();
                var Roleid = $('#<%= HdnUserRole.ClientID %>').val()
                //Hide Admin Part for staff Members
                if (Roleid == "2") {
                    $("#Payment").hide();
                }
                $('#txtStartDate,#txtEndDate').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    yearRange: "-116:+0",
                    dateFormat: "m/d/yy"
                });
            });

            $("#btnreset").click(function () {
                $("#ddlSearchbyDate").val(0);
                $("#ddlStaff").val("");
                $('#txtStartDate,#txtEndDate').val("");
                $('#startDateDiv,#EndDateDiv').css("display", "none");
                Clients();
                BindDropDown();
                GenerateTableForAll();
                $('.loadercont').fadeOut();
            });

            $('#txtStartDate,#txtEndDate').change(function () {
                if ($('#txtStartDate').val() != "" && $('#txtEndDate').val() != "") {
                    Clients();
                    GenerateTableForAll();
                    //BindDropDown();
                }
            });

            function PrintFullGrid() {
                var divToPrint = document.getElementById('printClients');
                var htmlToPrint = '' +
                    '<style type="text/css">' +
                    'table th, table td {' +
                    'padding:5px; font-size:20px;border:1px solid black;' +
                    '}' +
                    'table { width:100%; }' +
                    '.TotalAmounts { text-align:center; font-size:23px; font-weight:bold; }'+
                    '</style>';
                htmlToPrint += divToPrint.innerHTML;
                newWin = window.open("");
                newWin.document.write(htmlToPrint);
                newWin.print();
                newWin.close();
            }

            function GenerateTableForAll() {

                $('.loadercont').fadeIn();
                var Search = $("#ddlSearchbyDate").val();
                var id = $("#ddlStaff").val();
                var sDate = $('#txtStartDate').val();
                var eDate = $('#txtEndDate').val();

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Clients.aspx/PrintClients",
                    data: JSON.stringify({ Search: Search, id: id, sDate: sDate, eDate: eDate }),
                    dataType: "json",
                    success: function (response) {

                        $('#printClients').empty();
                        var tblDataPrint = "<table>" +
                            "<tr>" +
                            "<th>First Name</th>" +
                            "<th>Last Name</th>" +
                            "<th>State</th>" +
                            "<th>City</th>" +
                            "<th>Total Payment</th>" +
                            "<th>Paid</th>" +
                            "<th>Balance</th>" +
                            "<th>Added By</th></tr>";
                        console.log(response)

                        var totalpayment = 0;
                        var PaidPayment = 0;
                        var BalancePayment = 0;
                        if (response.d.length > 0) {
                            for (var i = 0; i < response.d.length; i++) {
                                TotalRecords = response.d[i].TotalRecords;
                                totalpayment = totalpayment + response.d[i].Payment_Total;
                                PaidPayment = PaidPayment + response.d[i].Payment_Paid;
                                BalancePayment = BalancePayment + response.d[i].Payment_Balance;
                                tblDataPrint += "<tr><td>" + response.d[i].F_Name + "</td>";
                                tblDataPrint += "<td>" + response.d[i].L_Name + "</td>";
                                tblDataPrint += "<td>" + response.d[i].ST + "</td>";
                                tblDataPrint += "<td>" + response.d[i].City + "</td>";

                                if (response.d[i].Payment_Total != null) {
                                    tblDataPrint += "<td>$" + response.d[i].Payment_Total + "</td>";
                                }
                                else {
                                    tblDataPrint += "<td>$&nbsp;0</td>";
                                }
                                if (response.d[i].Payment_Paid != null) {
                                    tblDataPrint += "<td>$" + response.d[i].Payment_Paid + "</td>";
                                }
                                else {
                                    tblDataPrint += "<td>$&nbsp;0</td>";
                                }
                                if (response.d[i].Payment_Balance != null) {
                                    tblDataPrint += "<td>$" + response.d[i].Payment_Balance + "</td>";
                                }
                                else {
                                    tblDataPrint += "<td>$&nbsp;0</td>";
                                }
                                tblDataPrint += "<td>" + response.d[i].IsaddedbyFirstName + "</td></tr>";
                            }
                            tblDataPrint += "<tr><td colspan=8></td>&nbsp;</tr>";
                            tblDataPrint += "<tr><td class='TotalAmounts' colspan=4>Total</td>";
                            tblDataPrint += "<td class='TotalAmounts'>$" + totalpayment + "</td>";
                            tblDataPrint += "<td class='TotalAmounts'>$" + PaidPayment + "</td>";
                            tblDataPrint += "<td class='TotalAmounts'>$" + BalancePayment + "</td>";
                            tblDataPrint += "<td class='TotalAmounts'></td></tr>";
                            $('#printClients').append(tblDataPrint);
                            //$('#printClients').append("<div style='margin-top:20px; margin-left:55%; font-size:20px;'>Total &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + totalpayment + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + PaidPayment + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + BalancePayment + "</div>>")

                        }
                        else {
                            tblDataPrint += "<tr><td colspan='8'> No Item to Display</td></tr>";
                            $('#printClients').append(tblDataPrint);
                        }
                        $('.loadercont').fadeOut();
                    },
                    error: function (response) {
                    }

                });
            };

            function Clients() {
                $('.loadercont').fadeIn();
                var Search = $("#ddlSearchbyDate").val();
                var id = $("#ddlStaff").val();
                var sDate = $('#txtStartDate').val();
                var eDate = $('#txtEndDate').val();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Clients.aspx/ClientList",
                    data: JSON.stringify({ Search: Search, id: id, PageIndex: 0, sDate: sDate, eDate: eDate }),
                    dataType: "Json",
                    success: function (response) {

                        $('#tblbody').empty();
                        var totalpayment = 0;
                        var PaidPayment = 0;
                        var BalancePayment = 0;
                        console.log(response)
                        var tr;
                        var array = [];

                        var ArrayValue = [];
                        var TotalRecords = "";
                        if (response.d.length > 0) {
                            for (var i = 0; i < response.d.length; i++) {
                                TotalRecords = response.d[i].TotalRecords;
                                totalpayment = totalpayment + response.d[i].Payment_Total;
                                PaidPayment = PaidPayment + response.d[i].Payment_Paid;
                                BalancePayment = BalancePayment + response.d[i].Payment_Balance;
                                tr = $('<tr/>');
                                tr.append("<td> <a id=" + response.d[i].Id + " onclick='userDetail(this.id)' style='cursor: pointer;'>" + response.d[i].F_Name + "  </a> </td>");
                                tr.append("<td>" + response.d[i].L_Name + "</td>");
                                tr.append("<td>" + response.d[i].ST + "</td>");
                                tr.append("<td>" + response.d[i].City + "</td>");
                                if (response.d[i].Payment_Total != null) {
                                    tr.append("<td>$&nbsp;" + response.d[i].Payment_Total + "</td>");
                                }
                                else {
                                    tr.append("<td>$&nbsp;0</td>");
                                }
                                if (response.d[i].Payment_Paid != null) {
                                    tr.append("<td>$&nbsp;" + response.d[i].Payment_Paid + "</td>");
                                }
                                else {
                                    tr.append("<td>$&nbsp;0</td>");
                                }
                                if (response.d[i].Payment_Balance != null) {
                                    tr.append("<td>$&nbsp;" + response.d[i].Payment_Balance + "</td>");
                                }
                                else {
                                    tr.append("<td>$&nbsp;0</td>");
                                }
                                tr.append("<td>" + response.d[i].IsaddedbyFirstName + "</td>");
                                $('#example').append(tr);

                            }
                        }
                        else {
                            tr = $('<tr/>');
                            tr.append("<td colspan='8'> No Item to Display</td>");
                            $('#example').append(tr);
                        }
                        $('#example').show();
                        $('.loadercont').fadeOut();
                        $("#TotalPayment").empty();
                        $("#paidPayment").empty();
                        $("#RemainingPayment").empty();
                        $("#TotalPayment").html(totalpayment);
                        $("#paidPayment").html(PaidPayment);
                        $("#RemainingPayment").html(BalancePayment);



                        //-------------------------------------for paging------------------------------
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

                        /// end paging



                    },
                    error: function (response) {

                        $('.loadercont').fadeOut();
                    }

                });
            };

            function Paging(Pageno) {
                $('.loadercont').fadeIn();
                var Search = $("#ddlSearchbyDate").val();
                var id = $("#ddlStaff").val();
                var sDate = $('#txtStartDate').val();
                var eDate = $('#txtEndDate').val();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Clients.aspx/ClientList",
                    data: JSON.stringify({ Search: Search, id: id, PageIndex: Pageno, sDate: sDate, eDate: eDate }),
                    dataType: "Json",
                    success: function (response) {

                        $('#tblbody').empty();
                        //var totalpayment = 0;
                        //var PaidPayment = 0;
                        //var BalancePayment = 0;
                        console.log(response)
                        var tr;

                        var array = [];


                        var ArrayValue = [];


                        var TotalRecords = "";
                        if (response.d.length > 0) {
                            for (var i = 0; i < response.d.length; i++) {
                                TotalRecords = response.d[i].TotalRecords;
                                //totalpayment = totalpayment + response.d[i].Payment_Total;
                                //PaidPayment = PaidPayment + response.d[i].Payment_Paid;
                                //BalancePayment = BalancePayment + response.d[i].Payment_Balance;
                                tr = $('<tr/>');
                                tr.append("<td> <a id=" + response.d[i].Id + " onclick='userDetail(this.id)' style='cursor: pointer;'>" + response.d[i].F_Name + "  </a> </td>");
                                tr.append("<td>" + response.d[i].L_Name + "</td>");
                                tr.append("<td>" + response.d[i].ST + "</td>");
                                tr.append("<td>" + response.d[i].City + "</td>");
                                if (response.d[i].Payment_Total != null) {
                                    tr.append("<td>$&nbsp;" + response.d[i].Payment_Total + "</td>");
                                }
                                else {
                                    tr.append("<td>$&nbsp;0</td>");
                                }
                                if (response.d[i].Payment_Paid != null) {
                                    tr.append("<td>$&nbsp;" + response.d[i].Payment_Paid + "</td>");
                                }
                                else {
                                    tr.append("<td>$&nbsp;0</td>");
                                }
                                if (response.d[i].Payment_Balance != null) {
                                    tr.append("<td>$&nbsp;" + response.d[i].Payment_Balance + "</td>");
                                }
                                else {
                                    tr.append("<td>$&nbsp;0</td>");
                                }
                                tr.append("<td>" + response.d[i].IsaddedbyFirstName + "</td>");
                                $('#example').append(tr);
                            }
                        }
                        else {
                            tr = $('<tr/>');
                            tr.append("<td colspan='8'> No Item to Display</td>");
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



                        //-------------------------------------for paging------------------------------
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

                        /// end paging
                    },
                    error: function (response) {

                        $('.loadercont').fadeOut();
                    }

                });
            };

            function userDetail(id) {
                window.location.href = "ClientDetail.aspx?id=" + id;
            };





            $("#ddlSearchbyDate").change(function () {
                $('#txtStartDate,#txtEndDate').val("");
                $("#TotalPayment").empty();
                $("#paidPayment").empty();
                $("#RemainingPayment").empty();
                $("#ddlStaff").val("");
                if ($("#ddlSearchbyDate").val() == '14') {
                    $('#tblbody').empty();
                    $('#dvPaging').empty();
                    //$("#ddlStaff").empty();
                    //$("#ddlStaff").val("");
                    $('#startDateDiv,#EndDateDiv').css("display", "block");
                }
                else {
                    $('#startDateDiv,#EndDateDiv').css("display", "none");
                    Clients();
                    GenerateTableForAll();
                    // BindDropDown();
                }
                //Clients();
                //BindDropDown()
                $('.loadercont').fadeOut();;
            });


            $("#ddlStaff").change(function () {
                // BindDropDown(); 
                if ($('#ddlSearchbyDate').val() == '14') {
                    if ($('#txtStartDate').val() != "" && $('#txtEndDate').val() != "") {
                        Clients();
                        GenerateTableForAll();
                        //BindDropDown();
                    }
                }
                else {
                    Clients();
                    GenerateTableForAll();
                }
                $('.loadercont').fadeOut();;
            });

            function BindDropDown() {
                $('.loadercont').fadeIn();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Clients.aspx/AddedByDropdownList",
                    data: {},
                    dataType: "Json",
                    success: function (response) {

                        console.log(response.d);
                        $('#ddlStaff').empty();
                        $('#ddlStaff').append('<option  value="""">Select</option>')
                        //var totalpayment = 0;
                        //var PaidPayment = 0;
                        //var BalancePayment = 0;
                        for (var n = 0; n < response.d.length; n++) {
                            if (response.d[n].IsAddedBy != 0 && response.d[n].IsaddedbyFirstName != null) {
                                //totalpayment = totalpayment + response.d[n].Payment_Total;
                                //PaidPayment = PaidPayment + response.d[n].Payment_Paid;
                                //BalancePayment = BalancePayment + response.d[n].Payment_Balance;
                                $('#ddlStaff').append('<option  value="' + response.d[n].IsAddedBy + '">' + response.d[n].IsaddedbyFirstName + '</option>')

                                if (response.d.length == 1) {
                                    $('#ddlStaff').val(response.d[0].IsAddedBy)
                                }
                            }
                        }
                        //$("#TotalPayment").empty();
                        //$("#paidPayment").empty();
                        //$("#RemainingPayment").empty();
                        //$("#TotalPayment").html("$&nbsp;" + totalpayment);
                        //$("#paidPayment").html("$&nbsp;" + PaidPayment);
                        //$("#RemainingPayment").html("$&nbsp;" + BalancePayment);

                    },
                    error: function (response) {

                        $('.loadercont').fadeOut();
                    }

                });
            };

            $("#btnEmailTodayRecords").click(function () {
                $('.loadercont').fadeIn();
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/Clients.aspx/ClientTodayReport",
                    data: JSON.stringify({ Search: "1" }),
                    dataType: "Json",
                    success: function (response) {
                        bootbox.alert(response.d);
                        $('.loadercont').fadeOut();
                    },
                    error: function (response) {
                        $('.loadercont').fadeOut();
                    },
                });
            });










            //function BindDropDown() {
            //    $('.loadercont').fadeIn();
            //    var Search = $("#ddlSearchbyDate").val();
            //    var id = $("#ddlStaff").val();
            //    var sDate = $('#txtStartDate').val();
            //    var eDate = $('#txtEndDate').val();
            //    $.ajax({
            //        type: "POST",
            //        contentType: "application/json; charset=utf-8",
            //        url: "/Clients.aspx/DropdownList",
            //        data: JSON.stringify({ Search: Search, id: id, sDate: sDate, eDate: eDate }),
            //        dataType: "Json",
            //        success: function (response) {

            //            console.log(response.d);
            //            $('#ddlStaff').empty();
            //            $('#ddlStaff').append('<option  value="""">Select</option>')
            //            var totalpayment = 0;
            //            var PaidPayment = 0;
            //            var BalancePayment = 0;
            //            for (var n = 0; n < response.d.length; n++) {
            //                if (response.d[n].IsAddedBy != 0 && response.d[n].IsaddedbyFirstName != null) {
            //                    totalpayment = totalpayment + response.d[n].Payment_Total;
            //                    PaidPayment = PaidPayment + response.d[n].Payment_Paid;
            //                    BalancePayment = BalancePayment + response.d[n].Payment_Balance;
            //                    $('#ddlStaff').append('<option  value="' + response.d[n].IsAddedBy + '">' + response.d[n].IsaddedbyFirstName + '</option>')

            //                    if (response.d.length == 1) {
            //                        $('#ddlStaff').val(response.d[0].IsAddedBy)
            //                    }
            //                }
            //            }
            //            $("#TotalPayment").empty();
            //            $("#paidPayment").empty();
            //            $("#RemainingPayment").empty();
            //            $("#TotalPayment").html("$&nbsp;" + totalpayment);
            //            $("#paidPayment").html("$&nbsp;" + PaidPayment);
            //            $("#RemainingPayment").html("$&nbsp;" + BalancePayment);

            //        },
            //        error: function (response) {

            //            $('.loadercont').fadeOut();
            //        }

            //    });
            //};

        </script>
</asp:Content>

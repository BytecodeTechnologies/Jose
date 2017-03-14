<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="PotentialClient.aspx.cs" Inherits="Excel.PotentialClient" %>

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
                            Potential Client List
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-lg-2">Search</label>
                                <div class="col-lg-10">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <select id="ddlSearchbyDate" class="form-control">
                                                <option value="0">All</option>
                                                <option value="1" selected="selected">Today</option>
                                                <option value="2">Yesterday</option>
                                                <option value="13">Custom</option>
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
                                            <%--<div class="label-block">
                                                <span class="label label-primary">Text</span>
                                            </div>--%>
                                        </div>

                                        <%--  <label class="control-label col-lg-2">Contains in</label>--%>
                                        <div class="col-md-3">

                                            <%--<label id="TotalPayment" style="margin-left: 68px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-primary">AGREEMENT AMOUNT</span>
                                            </div> --%>

                                            <input id="txtStartDate" style="display:none;"  placeholder="Start Date" class="form-control pressenter" type="text" readonly="true"/>
                                        </div>

                                        <div class="col-md-3">

                                           <%-- <label id="paidPayment" style="margin-left: 68px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-primary">COLLECTED AMOUNT</span>
                                            </div> --%>

                                            <input id="txtEndDate" style="display:none;"  placeholder="End Date" class="form-control pressenter" type="text" readonly="true"/>
                                        </div>

                                        <div class="col-md-3">
                                            <input type="button" value="Print" id="btnPrintFullGrid" class="btn btn-primary" style="float:right;" onclick="PrintFullGrid()" />
                                            <%--<label id="RemainingPayment" style="margin-left: 68px;" class="control-label"></label>
                                            <div class="label-block text-center">
                                                <span class="label label-danger">Balance Payment</span>
                                            </div> --%>                                             
                                        </div>

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
                                                <th>Quoted Amount</th>
                                                <%--<th>Paid</th>
                                                <th>Balance</th>--%>

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
                        </div>

                    </div>
                     <div id="printClients" style="display: none; border: 0px solid black;">
                           
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

    <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">--%>
    <%--<script src="//code.jquery.com/jquery-1.10.2.js"></script>--%>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>

    <script>

        $(document).ready(function () {
            localStorage.setItem('lastTab', "liSidePotentialClient");
            localStorage.setItem('lastTab1', "liTopPotentialClient");            
            Clients();
            GenerateTableForAll();
           // ShowPayment();
            $('#txtStartDate,#txtEndDate').datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-116:+0",
                dateFormat: "m/d/yy"
            });
        });

        $('#txtStartDate,#txtEndDate').change(function () {
            if ($('#txtStartDate').val() != "" && $('#txtEndDate').val() != "") {
                Clients();
                GenerateTableForAll();
            }         
        });

        function PrintFullGrid() {
            var divToPrint = document.getElementById('printClients');
            var htmlToPrint = '' +
                '<style type="text/css">' +
                'table th, table td {' +
                'padding:10px; font-size:20px;border:1px solid black;' +
                '}' +
                'table { width:100%; }' +                
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
            var sDate = $('#txtStartDate').val();
            var eDate = $('#txtEndDate').val();

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/PotentialClient.aspx/PrintPotentialClients",
                data: JSON.stringify({ Search: Search, sDate: sDate, eDate: eDate }),
                dataType: "json",
                success: function (response) {

                    $('#printClients').empty();
                    var tblDataPrint = "<table>" +
                        "<tr>" +
                        "<th>First Name</th>" +
                        "<th>Last Name</th>" +
                        "<th>State</th>" +
                        "<th>City</th>" +                      
                        "<th>Quoted Amount</th></tr>";
                    console.log(response)
                    if (response.d.length > 0) {

                        for (var i = 0; i < response.d.length; i++) {
                            tblDataPrint += "<tr><td>" + response.d[i].F_Name + "</td>";
                            tblDataPrint += "<td>" + response.d[i].L_Name + "</td>";
                            tblDataPrint += "<td>" + response.d[i].ST + "</td>";
                            tblDataPrint += "<td>" + response.d[i].City + "</td>";
                            if (response.d[i].Payment_Total != null) {
                                tblDataPrint += "<td>$&nbsp;" + response.d[i].Payment_Total + "</td></tr>";
                            }
                            else {
                                tblDataPrint += "<td>$&nbsp;0</td></tr>";
                            }                            
                        }
                        $('#printClients').append(tblDataPrint);
                    }
                    else {
                        tblDataPrint += "<tr><td colspan='5'> No Item to Display</td></tr>";
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
            var sDate = $('#txtStartDate').val();         
            var eDate = $('#txtEndDate').val();
            //var sDate = moment($('#txtStartDate').val(), "DD/MM/YYYY").format("YYYY-MM-DD");
            // var eDate = moment($('#txtEndDate').val(), "DD/MM/YYYY").format("YYYY-MM-DD");
            
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/PotentialClient.aspx/ClientList",
                data: JSON.stringify({ Search: Search, PageIndex: 0, sDate: sDate, eDate: eDate }),
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
                            //if (response.d[i].Payment_Paid != null) {
                            //    tr.append("<td>$&nbsp;" + response.d[i].Payment_Paid + "</td>");
                            //}
                            //else {
                            //    tr.append("<td>$&nbsp;0</td>");
                            //}
                            //if (response.d[i].Payment_Balance != null) {
                            //    tr.append("<td>$&nbsp;" + response.d[i].Payment_Balance + "</td>");
                            //}
                            //else {
                            //    tr.append("<td>$&nbsp;0</td>");
                            //}

                            $('#example').append(tr);
                        }
                    }
                    else {
                        tr = $('<tr/>');
                        tr.append("<td colspan='5'> No Item to Display</td>");
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
                        $("#dvPaging #0").addClass("activePage");
                        //-------------------------------- end paging -------------------------------
                    }
                },
                error: function (response) {

                    $('.loadercont').fadeOut();
                }

            });
        };
        function userDetail(id) {
            window.location.href = "PotentialClientDetail.aspx?id=" + id
        };

        $("#ddlSearchbyDate").change(function () {
            $('#txtStartDate,#txtEndDate').val("");
            if ($("#ddlSearchbyDate").val() == '13') {
                $('#tblbody').empty();
                $('#dvPaging').empty();
                $('#txtStartDate,#txtEndDate').css("display", "block");               
            }
            else {
                $('#txtStartDate,#txtEndDate').css("display", "none");
                Clients();
                GenerateTableForAll();
            }        
            //ShowPayment();
            $('.loadercont').fadeOut();
        });




        function GetRemainingPayment() {
            var Total = $("#txtEst").val();
            var Paid = $("#txtPaid").val();

            if (Total != "") {
                if (!$.isNumeric(Total)) {
                    alert('Please Type only numeric Value')
                    $("#txtEst").val('');
                    $('.loadercont').fadeOut();
                    return;
                }
            }

            if (Paid != "") {
                if (!$.isNumeric(Paid)) {
                    alert('Please Type only numeric Value')
                    Paid = $("#txtPaid").val('');
                    $('.loadercont').fadeOut();
                    return;
                }
            }

            var Balance = Total - Paid;
            $("#txtBalanceAmt").val(Balance);
        };



        function validateExpireyDate() {
            var Month = $('#txtExpirayDateMonth').val();
            var Year = $('#txtExpirayDateYear').val();
           
            if (Month != "") {
                if (!$.isNumeric(Month)) {
                    alert('Please Type only numeric Value in Month')
                    $('#txtExpirayDateMonth').val('');
                    $('.loadercont').fadeOut();
                    return;
                }
                if (Month > 12) {
                    alert("value must be less then or equal to 12")
                    $('#txtExpirayDateMonth').val('');
                    return;
                }
            }
            if (Year != "") {
                if (!$.isNumeric(Year)) {
                    alert('Please Type only numeric Value in Year')
                    $('#txtExpirayDateYear').val('');
                    $('.loadercont').fadeOut();
                    return;
                }
            }
        }

        // validate cvv on blur
        function validateCvv() {
            var CVV = $("#txtCVV").val();
            if (CVV != "") {
                if (!$.isNumeric(CVV)) {
                    alert('Please Type numeric value in CVV')
                    $("#txtCVV").val('');
                    $('.loadercont').fadeOut();
                    return;
                }
            }
        };


        function validateExpireyDate() {
            var Month = $('#txtExpirayDateMonth').val();
            var Year = $('#txtExpirayDateYear').val();
           
            if (Month != "") {
                if (!$.isNumeric(Month)) {

                    alert('Please Type only numeric Value in Month')
                    $('#txtExpirayDateMonth').val('');
                    $('.loadercont').fadeOut();
                    return;
                }
                if (Month > 12) {
                    alert("value must be less then or equal to 12")
                    $('#txtExpirayDateMonth').val('');
                    return;
                }
            }
            if (Year != "") {
                if (!$.isNumeric(Year)) {
                    alert('Please Type only numeric Value in Year')
                    $('#txtExpirayDateYear').val('');
                    $('.loadercont').fadeOut();
                    return;
                }
            }
        }

        // validate cvv on blur
        function validateCvv() {
            var CVV = $("#txtCVV").val();
            if (CVV != "") {
                if (!$.isNumeric(CVV)) {
                    alert('Please Type numeric value in CVV')
                    $("#txtCVV").val('');
                    $('.loadercont').fadeOut();
                    return;
                }
            }
        };


        function ValidateEmail(email) {
            // Validate email format
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };


        function MakeClient(id) {

            $('.loadercont').fadeIn();
            var Type = $("#ddlPayment").val();
            var Total = $("#txtEst").val();
            var Paid = $("#txtPaid").val();
            var Balance = $("#txtBalanceAmt").val();
            var Cardno = $("#txtcardno").val();
            var CVV = $("#txtCVV").val();
            var Phone = $("#txtPhone").val();
            var Email = $("#txtEmail").val();
            var Month = $('#txtExpirayDateMonth').val();
            var Year = $('#txtExpirayDateYear').val();
            var PotentialClient = false;
            var CardExpireyDate = "";

            //validate phone for int values
            if (Phone != "") {
                if (!$.isNumeric(Phone)) {
                    alert('Please Type numeric value in Phone')
                    $('.loadercont').fadeOut();
                    return;
                }
            }
            //validate cvv for int values
            if (CVV != "") {
                if (!$.isNumeric(CVV)) {
                    alert('Please Type numeric value in CVV')
                    $('.loadercont').fadeOut();
                    return;
                }
            }

            //validate email
            if (Email != "") {
                if (!ValidateEmail(Email)) {
                    $('.loadercont').fadeOut();
                    alert('Not a valid email');
                    return;
                }
            }

            //if (!$.isNumeric(Total) || !$.isNumeric(Paid) || !$.isNumeric(Balance)) {
            //    alert('Please Type only numeric Value in payment section')
            //    $('.loadercont').fadeOut();
            //    return;
            //}

            //if(Year != "" || Month != "")
            //{
            //    var today, someday;
            //    today = new Date();
            //    someday = new Date();
            //    someday.setFullYear(Year, Month, 1);

            //    if (someday < today) {
            //        alert("The expiry date is before today's date. Please select a valid expiry date");
            //        $('.loadercont').fadeOut();
            //        return false;
            //    }
            //}

            // validate cvv for int values
            if (Month != "" || Year != "") {
                if (!$.isNumeric(Month) || !$.isNumeric(Year)) {
                    alert('Invalid Expirey Date')
                    $('.loadercont').fadeOut();
                    return;
                }
            }

            if (Month != "" || Year != "") {
                var CardExpireyDate = Month + '/' + Year;
            }

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/PotentialClient.aspx/MarkasClientToPotentialClient",
                data: JSON.stringify({ id: id, Type: Type, Total: Total, Paid: Paid, Balance: Balance, Cardno: Cardno, CardExpireyDate: CardExpireyDate, CVV: CVV, Phone: Phone, Email: Email }),
                dataType: "Json",
                success: function (response) {
                    alert("Potential Client Succesfully Mark as Client");
                    window.location.href = "Clients.aspx";
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });
        };

        function Paging(Pageno) {
            $('.loadercont').fadeIn();
            var Search = $("#ddlSearchbyDate").val();
            var sDate = $('#txtStartDate').val();
            var eDate = $('#txtEndDate').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/PotentialClient.aspx/ClientList",
                data: JSON.stringify({ Search: Search, PageIndex: Pageno, sDate: sDate, eDate: eDate }),
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
                            //if (response.d[i].Payment_Paid != null) {
                            //    tr.append("<td>$&nbsp;" + response.d[i].Payment_Paid + "</td>");
                            //}
                            //else {
                            //    tr.append("<td>$&nbsp;0</td>");
                            //}
                            //if (response.d[i].Payment_Balance != null) {
                            //    tr.append("<td>$&nbsp;" + response.d[i].Payment_Balance + "</td>");
                            //}
                            //else {
                            //    tr.append("<td>$&nbsp;0</td>");
                            //}

                            $('#example').append(tr);
                        }
                    }
                    else {
                        tr = $('<tr/>');
                        tr.append("<td colspan='5'> No Item to Display</td>");
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
                        //-------------------------------- end paging -------------------------------

                    }
                },
                error: function (response) {

                    $('.loadercont').fadeOut();
                }

            });
        };



        function ShowPayment() {
            $('.loadercont').fadeIn();
            var Search = $("#ddlSearchbyDate").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/PotentialClient.aspx/Payment",
                data: JSON.stringify({ Search: Search }),
                dataType: "Json",
                success: function (response) {
                    debugger;
                    var totalpayment = 0;
                    var PaidPayment = 0;
                    var BalancePayment = 0;
                    console.log(response)
                    var tr;
                    if (response.d.length > 0) {
                        for (var i = 0; i < response.d.length; i++) {
                            totalpayment = totalpayment + response.d[i].Payment_Total;
                            PaidPayment = PaidPayment + response.d[i].Payment_Paid;
                            BalancePayment = BalancePayment + response.d[i].Payment_Balance;
                        }
                    }
                    $("#TotalPayment").empty();
                    $("#paidPayment").empty();
                    $("#RemainingPayment").empty();
                    $("#TotalPayment").html("$&nbsp;"+totalpayment);
                    $("#paidPayment").html("$&nbsp;"+PaidPayment);
                    $("#RemainingPayment").html("$&nbsp;"+BalancePayment);
                },
                error: function (response) {

                    $('.loadercont').fadeOut();
                }

            });
        };




    </script>
</asp:Content>

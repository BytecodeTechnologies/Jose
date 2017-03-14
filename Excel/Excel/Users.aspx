<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="~/NJ_ClientAdmin.Master" CodeBehind="Users.aspx.cs" Inherits="Excel.Users1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="row">
            <div class="col-lg-12" style="min-height: 100px !important;">

                <div class="panel panel-flat">
                    <div class="panel-heading">
                        <div class="col-md-12 homeheader">
                            User List
                        </div>
                    </div>


                    <div class="panel-body gridtopMargin">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-lg-2"><a href="AddNew.aspx" class="btn btn-primary">Add New Client </a></label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label col-lg-2">Search</label>
                                <div class="col-lg-10">
                                    <div class="row">
                                        <div class="col-md-3 clsSearch">
                                            <input type="text" id="txtSearch" class="form-control pressenter" />
                                            <div class="label-block">
                                                <span class="label label-primary GridSearchMargin">Text</span>
                                            </div>
                                        </div>

                                         <div class="col-md-3 clsFullName">
                                            <input type="text" id="txtFirstName" class="form-control pressenter" placeholder="First Name" />
                                            <div class="label-block">
                                                <span class="label label-primary GridSearchMargin">Text</span>
                                            </div>
                                        </div>

                                         <div class="col-md-3 clsFullName">
                                            <input type="text" id="txtLastName" class="form-control pressenter" placeholder="Last Name" />
                                            <div class="label-block">
                                                <span class="label label-primary GridSearchMargin">Text</span>
                                            </div>
                                        </div>

                                        <label class="control-label col-lg-2">Contains in</label>
                                        <div class="col-md-2">
                                            <select id="ddlSearchColumn" class="form-control">
                                                <option value="Full">Full Name</option>
                                                <option value="L_Name">Last Name</option>
                                                <option value="F_Name">First Name</option>
                                                <option value="ST">State</option>
                                                <option value="City">City</option>
                                            </select>
                                            <div class="label-block text-center">
                                                <span class="label label-danger">Search by</span>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <input type="button" id="btnSearch" class="btn btn-primary" value="Search" />
                                            <div class="label-block text-right">
                                            </div>
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
                                                <%--  <th>MakeUSer</th>--%>
                                            </tr>
                                        </thead>
                                        <tbody id="tblbody">
                                        </tbody>
                                    </table>
                                </div>
                                <div id="popup1" class="overlay">
                                    <div class="popup">
                                        <%--<img src="Images/user.png" style='width: 88px; margin-right: 50%;' />--%>
                                        <h2>User Detail</h2>
                                        <a class="close" href="#">&times;</a>
                                        <div id="PopupData" class="content" style="max-height: 400px; overflow-y: scroll; max-width: 800px !important;">
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
    <asp:HiddenField id="hdnSearch" runat="server"/>
    <asp:HiddenField id="hdnContains" runat="server"/>
    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->




    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/DataTable/jquery-1.12.3.js"></script>
    <script src="Scripts/DataTable/jquery.dataTables.min.js"></script>
    <script src="Scripts/DataTable/dataTables.bootstrap.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <script>

        $(document).ready(function () {
            var Search = $('#<%= hdnSearch.ClientID %>').val().trim();
            var Contains = $('#<%= hdnContains.ClientID %>').val().trim();
            $(".clsSearch").hide();

            $('#example').hide();
            localStorage.setItem('lastTab', "LiSideUsers");
            localStorage.setItem('lastTab1', "liTopUser");

            $("#txtSearch").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Users.aspx/GetLastNames",
                        data: JSON.stringify({ prefix: $('#txtSearch').val() }),
                        dataType: "Json",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item
                                }
                            }))
                            $('.loadercont').fadeOut();
                        },
                        error: function (response) {
                            $('.loadercont').fadeOut();
                        }
                    });
                }
            });

            $("#txtLastName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Users.aspx/GetLastNames",
                        data: JSON.stringify({ prefix: $('#txtLastName').val() }),
                        dataType: "Json",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item
                                }
                            }))
                            $('.loadercont').fadeOut();
                        },
                        error: function (response) {
                            $('.loadercont').fadeOut();
                        }
                    });
                }
            });

            $("#txtFirstName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/Users.aspx/GetFirstNames",
                        data: JSON.stringify({ prefix: $('#txtFirstName').val() }),
                        dataType: "Json",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item
                                }
                            }))
                            $('.loadercont').fadeOut();
                        },
                        error: function (response) {
                            $('.loadercont').fadeOut();
                        }
                    });
                }
            });


            if (Search != "" && Contains != "") {
                if (Contains == "Full") {
                    var name = Search.split("_");
                    $("#txtFirstName").val(name[0]);
                    $("#txtLastName").val(name[1]);
                }
                else {
                    $("#txtSearch").val(Search);
                }
                
                $("#ddlSearchColumn").val(Contains);
               
                $("#ddlSearchColumn").change();

                $("#btnSearch").click();
            }

        });





        $("#btnSearch").click(function () {
            $('.loadercont').fadeIn();
            var Column = $("#ddlSearchColumn").val();
            var SearchItem = "";
            var FirstName = $("#txtFirstName").val().trim();
            var LastName = $("#txtLastName").val().trim();
            if ($("#ddlSearchColumn").val().trim() == "Full") {
                SearchItem = FirstName + " " + LastName;
            }
            else {
                SearchItem = $("#txtSearch").val().trim();
            }

           
            if (Column == 0 || (SearchItem == "" && $("#ddlSearchColumn").val()!="Full")) {
                alert("Please enter Search item")
                $('.loadercont').fadeOut();
                return;
            }

            if (Column == 0 || (FirstName == "" && LastName == "" && $("#ddlSearchColumn").val() == "Full")) {
                alert("Please enter alteast First Name or Last Name")
                $('.loadercont').fadeOut();
                return;
            }
            //if (Column == 0 || (LastName == "" && $("#ddlSearchColumn").val() == "Full")) {
            //    alert("Please enter Last Name")
            //    $('.loadercont').fadeOut();
            //    return;
            //}
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",

                url: "/Users.aspx/List",
                data: JSON.stringify({ Column: Column, SearchItem: SearchItem }),
                dataType: "Json",
                success: function (response) {
                    $('#tblbody').empty();
                    console.log(response)
                    var tr;
                    if (response.d.length > 0) {
                        for (var i = 0; i < response.d.length; i++) {
                            tr = $('<tr/>');
                            tr.append("<td> <a id=" + response.d[i].Id + " onclick='userDetail(this.id," + response.d[i].IsPotential + ")' style='cursor: pointer;'>" + response.d[i].F_Name + "  </a> </td>");
                            tr.append("<td> <a id=" + response.d[i].Id + " onclick='userDetail(this.id," + response.d[i].IsPotential + ")' style='cursor: pointer;'>" + response.d[i].L_Name + "  </a> </td>");
                            //tr.append("<td>" + response.d[i].L_Name + "</td>");
                            tr.append("<td>" + response.d[i].ST + "</td>");
                            tr.append("<td>" + response.d[i].City + "</td>");
                            //if (response.d[i].IsUser == null) {
                            //    console.log(response.d[i].IsUser)
                            //    tr.append("<td> <a id=" + response.d[i].Id + " onclick='PopupUserFields(this.id)' style='cursor: pointer;'>Mark As User</a> </td>");
                            //}
                            $('#example').append(tr);

                        }
                    }
                    else {
                        tr = $('<tr/>');
                        tr.append("<td colspan='5'> No Item to Display</td>");
                        $('#example').append(tr);
                        $('.loadercont').fadeOut();
                    }
                    $('#example').show();
                    $('.loadercont').fadeOut();
                },
                error: function (response) {

                    $('.loadercont').fadeOut();
                }
            });
        });

        function userDetail(id, IsPotential) {
            var SearchItem = "";
            var FirstName = $("#txtFirstName").val().trim();
            var LastName = $("#txtLastName").val().trim();
            if ($("#ddlSearchColumn").val().trim() == "Full") {
                SearchItem = FirstName + "_" + LastName;
            }
            else {
                SearchItem = $("#txtSearch").val().trim();
            }
            window.location.href = "UserDetail.aspx?id=" + id + "&Search=" + SearchItem + "&Contains=" + $("#ddlSearchColumn").val() + "&IsPotential=" + IsPotential;
        }

        function PopupUserFields(id) {
            $('#PopupData').empty();
            $('#PopupData').append("<label style='width:50px;margin-top:10px'>Type:</label><input type='text' style='margin-left: 10%;' placeholder='Type' id='inputType' /><br/>")
            $('#PopupData').append("<label style='width:50px;margin-top:20px'>Payment:</label><input type='text' style='margin-left: 10%;' placeholder='Total amount in $' onblur='GetRemainingPayment()' id='inputTotal' />$&nbsp;&nbsp;<input onblur='GetRemainingPayment()' placeholder='Paid amount in $' type='text' id='inputPaid'; />$&nbsp;&nbsp;<input placeholder='Balance amount in $'  type='text' disabled='disabled' id='inputBalance'; />$<br/>")
            $('#PopupData').append("<label style='width:50px;margin-top:20px'>Sale:</label><input type='text' style='margin-left: 10%;' placeholder='Sale' id='inputSale' /><br/>")
            $('#PopupData').append("<label style='width:50px;margin-top:20px'>Advert:</label><input type='text' style='margin-left: 10%;' placeholder='Advert' id='inputAdvert' /><br/>")
            $('#PopupData').append("<label style='width:50px;margin-top:20px'>#File:</label><input type='text' style='margin-left: 10%;' placeholder='File' id='inputFile' /><br/>")
            $('#PopupData').append("</br><center><inp`  ``      ~   ut type='button' value='Submit' id=" + id + " onclick='MakeClient(this.id)'  class='btn btn-primary'></center>")
            window.location.href = "#popup1";
        }

        $(window).load(function () {
            $('.loadercont').fadeOut();
        })


        //validate expireyDate on blur
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



        // code for make a client
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
                url: "/Users.aspx/MakeClient",
                data: JSON.stringify({ id: id, Type: Type, Total: Total, Paid: Paid, Balance: Balance, Cardno: Cardno, CardExpireyDate: CardExpireyDate, CVV: CVV, Phone: Phone, Email: Email, PotentialClient: PotentialClient }),
                dataType: "Json",
                dataType: "Json",
                success: function (response) {
                    alert('Client added Successfully');
                    window.location.href = "Clients.aspx"
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });
        };

        // code for mark potential client
        function markPotentialClient(id) {

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
            var PotentialClient = true;
            var CardExpireyDate = "";

            if (Phone != "") {
                if (!$.isNumeric(Phone)) {
                    alert('Please Type numeric value in Phone')
                    $('.loadercont').fadeOut();
                    return;
                }
            }

            if (CVV != "") {
                if (!$.isNumeric(CVV)) {
                    alert('Please Type numeric value in CVV')
                    $('.loadercont').fadeOut();
                    return;
                }
            }

            if (Email != "") {
                if (!ValidateEmail(Email)) {
                    $('.loadercont').fadeOut();
                    alert('Not a valid email');
                    return;
                }
            }

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
                url: "/Users.aspx/MakeClient",
                data: JSON.stringify({ id: id, Type: Type, Total: Total, Paid: Paid, Balance: Balance, Cardno: Cardno, CardExpireyDate: CardExpireyDate, CVV: CVV, Phone: Phone, Email: Email, PotentialClient: PotentialClient }),
                dataType: "Json",
                dataType: "Json",
                success: function (response) {
                    alert('Potential Client added Successfully');
                    window.location.href = "PotentialClient.aspx"
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });
        };



        // code for autofill balance payment
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


        // validate email id
        function ValidateEmail(email) {
            // Validate email format
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };


        $("#btnPotentialClient").click(function () {
            $('.loadercont').fadeIn();
            var Column = $("#ddlSearchColumn").val();
            var SearchItem = $("#txtSearch").val();

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/Users.aspx/List",
                data: JSON.stringify({ Column: Column, SearchItem: SearchItem }),
                dataType: "Json",
                success: function (response) {
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });
        });

        // call search function on enter press
        $("#txtSearch").keypress(function (e) {
          
            if (e.which == 13) {
                $("#btnSearch").click();
                e.preventDefault();
            }
        });

        $("#ddlSearchColumn").change(function ()
        {
            $(".clsFullName").hide();
            $(".clsSearch").hide();
            if ($("#ddlSearchColumn").val() == "Full") {
                $(".clsFullName").show();
            }
            else {
                $(".clsSearch").show();
            }
        });
    </script>
</asp:Content>

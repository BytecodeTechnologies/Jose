<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="SearchUser.aspx.cs" Inherits="Excel.SearchUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="row">
            <div class="col-lg-12" style="min-height: 100px !important;">
                <div class="panel panel-flat">
                    <div class="panel-heading panel1-top">
                        <div class="col-md-12 homeheader">
                            Search User
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin list-sch-box">
                        <div class="col-md-2 right-padding23">                            
                            <div class="frm-grp">
                                <div class="form-group">
                                    <label class="control-label col-lg-12 srch-5">Search</label>
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div style="display: none;" class="col-md-12 clsSearch search-fom1">
                                                <input id="txtSearch" class="form-control pressenter" type="text">
                                                <div class="label-block">
                                                    <span class="label label-primary GridSearchMargin">Text</span>
                                                </div>
                                            </div>

                                            <label class="control-label col-lg-12 name">First Name</label>
                                            <div class="col-md-12 clsFullName">
                                                <input id="txtFirstName" class="form-control pressenter" placeholder="First Name" type="text">
                                            </div>

                                            <label class="control-label col-lg-12 name">Last Name</label>
                                            <div class="col-md-12 clsFullName">
                                                <input id="txtLastName"  class="form-control pressenter" placeholder="Last Name" type="text">
                                            </div>

                                            <label class="control-label col-lg-12 name">DOB</label>
                                            <div class="col-md-12">

                                                <input id="txtDOB"  placeholder="DOB" class="form-control pressenter" type="text">
                                            </div>

                                            <div class="col-md-12">
                                                <input id="btnSearch" value="Search" class="btn btn-primary butn-srch btn-search-sidebar" type="button">
                                                <input id="btnClear" value="Clear" class="btn btn-primary butn-srch btn-search-sidebar" type="button">
                                                <div class="label-block text-right">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-10 lef-padding23">
                            <div class="tabel-responsive tabl-list-6" style="margin-left: -11px;">
                                <table id="example" class="table table-striped table-bordered" width="100%" cellspacing="0">
                                    <thead>
                                        <tr class="top123">
                                            <th>Details</th>
                                            <th>Violation Date</th>
                                            <th style="Padding: 0px 78px 0 18px !important" class="tableth1">ViolationDescription</th>
                                            <th>Disposition</th>
                                            <th>Adjudicated Date</th>
                                            <th style="Padding: 0px 78px 0 18px !important" class="tableth1">AdjudicatedDescription</th>
                                            <th>State country</th>
                                            <th>DMW Points</th>
                                            <th>INS Points</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tblbody">
                                    </tbody>
                                </table>
                            </div>
                            <div id="popup1" style="overflow: scroll; max-height: 100%" class="overlay">
                                <div class="popup">
                                    <h2>UserInfo</h2>
                                    <a class="close" href="#">×</a>
                                    <div id="PopupData" class="content">
                                    </div>
                                    <div id="UserDetail"></div>
                                </div>
                            </div>                             
                        </div>
                    </div>


                </div>


                <asp:HiddenField ID="hdnSearch" runat="server" />
                <asp:HiddenField ID="hdnContains" runat="server" />
                <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>--%>
                <script src="Scripts/jquery-1.7.1.min.js"></script>
                <script src="Scripts/jquery-1.7.1.js"></script>
                <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/interactions.min.js"></script>
                <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/widgets.min.js"></script>
                <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/effects.min.js"></script>
                <script type="text/javascript" src="/assets/js/plugins/extensions/mousewheel.min.js"></script>
                <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/globalize/globalize.js"></script>
                <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/globalize/cultures/globalize.culture.de-DE.js"></script>
                <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/globalize/cultures/globalize.culture.ja-JP.js"></script>
                <script type="text/javascript" src="/assets/js/pages/jqueryui_forms.js"></script>

                <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">--%>
                <script src="//code.jquery.com/jquery-1.10.2.js"></script>
                <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
                <script>

                    $(document).ready(function () {
                        localStorage.setItem('lastTab1', "liTopUserbyAPI");
                        $('#txtDOB').datepicker({
                            changeMonth: true,
                            changeYear: true,
                            yearRange: "-116:+0",
                        });

                        $('#example').hide();
                        $(".clsSearch").hide();
                        $('.loadercont').fadeOut();
                    });

                    $("#btnSearch").click(function () {
                        $('.loadercont').fadeIn();
                        var FirstName = $("#txtFirstName").val().trim();
                        var LastName = $("#txtLastName").val().trim();
                        var DOB = $("#txtDOB").val().trim();;

                        if (FirstName == "") {
                            bootbox.alert("Please enter First Name")
                            $('.loadercont').fadeOut();
                            $("#txtFirstName").focus();
                            return;
                        }
                        if (LastName == "") {
                            bootbox.alert("Please enter Last Name")
                            $('.loadercont').fadeOut();
                            $("#txtLastName").focus();
                            return;
                        }
                        if (DOB == "") {
                            bootbox.alert("Please Select Date of Birth")
                            $('.loadercont').fadeOut();
                            $("#txtDOB").focus();
                            return;
                        }
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/SearchUser.aspx/GetUSerInfo",
                            data: JSON.stringify({ FirstName: FirstName, LastName: LastName, DOB: DOB }),
                            dataType: "Json",
                            success: function (response) {
                                console.log(response.d);
                                $('#tblbody').empty();
                                $('#example').show();
                                if (response.d.length > 0) {
                                    for (var i = 0; i < response.d.length; i++) {
                                       
                                        tr = $('<tr/>');
                                        tr.append("<td> <a id='an" + i + "' onclick='userDetail(this," + JSON.stringify(response.d[i]) + ")' style='cursor: pointer;font-size:23px;'>+</a> <a id='al" + i + "' onclick='userDetaildisplay(this)' style='cursor: pointer;display:none;font-size:23px;'>-</a> </td>");
                                        tr.append("<td>" + response.d[i].ViolationDate + "</td>");
                                        tr.append("<td>" + response.d[i].ViolationDescription + "</td>");
                                        tr.append("<td>" + response.d[i].Disposition + "</td>");
                                        tr.append("<td>" + response.d[i].AdjudicatedDate + "</td>");
                                        tr.append("<td>" + response.d[i].AdjudicatedDescription + "</td>");
                                        tr.append("<td>" + response.d[i].StateCode + " " + response.d[i].countryCode + "</td>");
                                        tr.append("<td>" + response.d[i].DMVPoints + "</td>");
                                        tr.append("<td>" + response.d[i].INSPoints + "</td>");
                                        $('#example').append(tr);
                                        $('#example').append("<tr id='tabletr" + i + "' style='display:none;border: 2px solid;background:#DAEBF2'><td colspan='2'><div class='inside-tabel' style='height:700px;overflow-y:scroll;overflow-x:hidden' id='userdata" + i + "'></div></td><td colspan='7'><div style='margin-top: -35%;' id='userdatata" + i + "'></div><br/><div id='userdataviolation" + i + "'></div></td></tr>");
                                    }
                                }
                                else {
                                    tr = $('<tr/>');
                                    tr.append("<td colspan='12'> No Item to Display</td>");
                                    $('#example').append(tr);
                                }
                                $('.loadercont').fadeOut();
                            },
                            error: function (response) {
                                $('.loadercont').fadeOut();
                            }
                        });
                    });
                    function userDetail(data, data1) {
                        debugger;
                        str1 = data.id.replace(/[^\d.]/g, '');
                        var res = $(data).closest('tr').css("background", "#DAEBF2");
                        $("#tabletr" + str1).show();
                        var content = "<table class='tableborder' border='1' style='border: 1px ;width: 100%;'>";
                        if (data1.FName != "" && data1.FName != null) {
                            content += '<tr><td><label class="m1weight">Name</label></td><td><label class="prize">' + data1.FName + ' ' + data1.LName + '</label></td><tr>';
                        }
                        if (data1.Address1 != "" && data1.Address1 != null) {
                            content += '<tr><td><label class="m1weight">Address</label></td><td><label class="prize">' + data1.Address1 + '</label></td><tr>';
                        }
                        if (data1.City != "" && data1.StateCode != "" && data1.countryCode != "") {
                            content += '<tr><td><label class="m1weight">City State Zip</label></td><td><label class="prize">' + data1.City + ' ' + data1.StateCode + ' ' + data1.countryCode + '</label></td><tr>';
                        }

                        if (data1.Gender != "" && data1.Gender != null) {
                            content += '<tr><td><label class="m1weight">Gender</label></td><td><label class="prize">' + data1.Gender + '</label></td><tr>';
                        }
                        if (data1.EyeColor != "" && data1.EyeColor != null) {
                            content += '<tr><td><label class="m1weight">EyeColor</label></td><td><label class="prize">' + data1.EyeColor + '</label></td><tr>';
                        }
                        for (var i = 0; i < data1.statespecified.length; i++) {
                            if (data1.statespecified[i].value != "" && data1.statespecified[i].value != null) {
                                content += '<tr><td><label class="m1weight">' + data1.statespecified[i].Key + '</label></td><td><label class="prize">' + data1.statespecified[i].value + '</label></td><tr>';
                            }
                        }
                        content += "</table>"
                        $("#userdata" + str1).append(content);
                        var content1 = "<table class='tableborder' border='1 solid black' style='border: 1px ;width: 100%;'>";
                        content1 += '<tr class="tbheadercolor"><td><label class="m1weight">CourtDate</label></td><td><label class="m1weight">Country</label></td><td> <label class="m1weight">CaseType</label></td><td><label class="m1weight">ChargeCount</label></td><td><label class="m1weight">DMV Point</label></td><td><label class="m1weight">INS Point</label></td><td><label class="m1weight">Docket</label></td><td><label class="m1weight">Summons</label></td><tr>';
                        content1 += '<tr><td><label class="m1weight1">' + data1.CourtDate + '</label></td><td><label class="m1weight1">' + data1.countryCode + '</label></td><td> <label class="m1weight1">' + data1.CaseType + '</label></td><td><label class="m1weight1">' + data1.ChargeCount + '</label></td><td><label class="m1weight1">' + data1.DMVPoints + '</label></td><td><label class="m1weight1">' + data1.INSPoints + '</label></td><td><label class="m1weight1">' + data1.Docket + '</label></td><td><label class="m1weight1">' + data1.Summons + '</label></td><tr>';
                        content1 += "</table>";

                        $("#userdatata" + str1).append(content1);
                        var content2 = "<table class='tableborder' border='1 solid black' style='border: 1px ;width: 100%;'>";
                        content2 += '<tr class="tbheadercolor"><td><label class="m1weight">Type</label></td><td><label class="m1weight">Date</label></td><td style="width:25% !important"> <label class="m1weight">Description</label></td><td><label class="m1weight">AcdCode</label></td><td><label class="m1weight">Status</label></td><td><label class="m1weight">CustomerCode</label></td><td><label class="m1weight">StateCode</label></td><td><label class="m1weight">Disposition</label></td><tr>';
                        content2 += '<tr><td><label class="m1weight">Violation</label></td><td><label class="m1weight1">' + data1.ViolationDate + '</label></td><td> <label class="m1weight1">' + data1.ViolationDescription + '</label></td><td><label class="m1weight1">' + data1.ViolationAcdCode + '</label></td><td><label class="m1weight1">' + data1.ViolationStatute + '</label></td><td><label class="m1weight1">' + data1.ViolationCustomerCode + '</label></td><td><label class="m1weight1">' + data1.ViolationStateCode + '</label></td><td><label class="m1weight1">' + data1.Disposition + '</label></td><tr>';
                        content2 += '<tr><td><label class="m1weight">Adjudicated</label></td><td><label class="m1weight1">' + data1.AdjudicatedDate + '</label></td><td> <label class="m1weight1">' + data1.AdjudicatedDescription + '</label></td><td><label class="m1weight1">' + data1.AdjudicatedAcdCode + '</label></td><td><label class="m1weight1">' + data1.AdjudicatedStatute + '</label></td>'
                        if (data1.AdjudicatedCustomerCode != null) {
                            content2 += '<td><label class="m1weight1">' + data1.AdjudicatedCustomerCode + '</label></td>'
                        }
                        else {
                            content2 += '<td><label class="m1weight1"></label></td>'
                        }

                        content2 += '<td><label class="m1weight1">' + data1.ViolationStateCode + '</label></td><td><label class="m1weight1"></label></td><tr>';
                        content2 += "</table>";
                        $("#userdataviolation" + str1).append(content2);
                        $("#userdataviolation" + str1).append("<input type='button' id=btnMarkClient" + i + "' onclick='MarkClient(" + JSON.stringify(data1) + ")' class='btn btn-primary btn-mark' value='Interested?'>")
                        $(data).hide();
                        $("#al" + str1).show();
                        $('html, body').animate({
                            'scrollTop': $("#al" + str1).offset().top - 35
                        });
                    };

                    function userDetaildisplay(data) {
                        str2 = data.id.replace(/[^\d.]/g, '');
                        var res = $(data).closest('tr').css("background", "white");
                        $("#tabletr" + str2).hide();
                        $("#userdata" + str2).empty();
                        $("#userdatata" + str2).empty();
                        $("#userdataviolation" + str2).empty();
                        $(data).hide();
                        $("#an" + str2).show();
                    }
                    function MarkClient(data) {
                        var ViolationDate = data.ViolationDate;
                        var ViolationDescription = data.ViolationDescription;
                        var Disposition = data.Disposition;
                        var AdjudicatedDate = data.AdjudicatedDate;
                        var AdjudicatedDescription = data.AdjudicatedDescription;
                        var StateCode = data.StateCode;
                        var countryCode = data.countryCode;
                        var DMVPoints = data.DMVPoints;
                        var INSPoints = data.INSPoints;
                        var CourtDate = data.CourtDate;
                        var CaseType = data.CaseType;
                        var ChargeCount = data.ChargeCount;
                        var Docket = data.Docket;
                        var Summons = data.Summons;
                        var ViolationAcdCode = data.ViolationAcdCode;
                        var AdjudicatedAcdCode = data.AdjudicatedAcdCode;
                        var AdjudicatedStatute = data.AdjudicatedStatute;
                        var ViolationStatute = data.ViolationStatute;
                        var AdjudicatedCustomerCode = data.AdjudicatedCustomerCode;
                        var ViolationCustomerCode = data.ViolationCustomerCode;
                        var ViolationStateCode = data.ViolationStateCode;
                        var FName = data.FName;
                        var LName = data.LName;
                        var Address1 = data.Address1;
                        var Address2 = data.Address2;
                        var City = data.City;
                        var State = data.StateCode;
                        var zip = data.zip;
                        var DOB = data.BirthMonth + '/' + data.BirthDay + '/' + data.BirthYear;
                        var Gender = data.Gender;
                        var Phone = "";
                        var Email = "";

                        for (var i = 0; i < data.statespecified.length; i++) {
                            if (data.statespecified[i].Key == "Phone") {
                                Phone = data.statespecified[i].value;
                            }
                            if (data.statespecified.Key == "Email") {
                                Email = data.statespecified[i].value;
                            }
                        }
                        console.log(data);
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/SearchUser.aspx/SaveInfo",
                            data: JSON.stringify({
                                ViolationDate: ViolationDate,
                                ViolationDescription: ViolationDescription,
                                Disposition: Disposition,
                                AdjudicatedDate: AdjudicatedDate,
                                AdjudicatedDescription: AdjudicatedDescription,
                                StateCode: StateCode,
                                countryCode: countryCode,
                                DMVPoints: DMVPoints,
                                INSPoints: INSPoints,
                                CourtDate: CourtDate,
                                CaseType: CaseType,
                                ChargeCount: ChargeCount,
                                Docket: Docket,
                                Summons: Summons,
                                ViolationAcdCode: ViolationAcdCode,
                                AdjudicatedAcdCode: AdjudicatedAcdCode,
                                AdjudicatedStatute: AdjudicatedStatute,
                                ViolationStatute: ViolationStatute,
                                AdjudicatedCustomerCode: AdjudicatedCustomerCode,
                                ViolationCustomerCode: ViolationCustomerCode,
                                ViolationStateCode: ViolationStateCode,
                                FName: FName,
                                LName: LName,
                                Address1: Address1,
                                Address2: Address2,
                                City: City,
                                State: StateCode,
                                zip: zip,
                                DOB: DOB,
                                Phone: Phone,
                                Email: Email,
                                Gender: Gender,
                            }),
                            dataType: "Json",
                            success: function (response) {
                                window.location.href = "UserDetail.aspx"
                            },
                            error: function (response) {
                            }
                        });
                    }

                    $('#btnClear').click(function () {
                        $('#txtFirstName').val('');
                        $('#txtLastName').val('');
                        $('#txtDOB').val('');
                    })

                    $(".pressenter").keypress(function (e) {

                        if (e.which == 13) {
                            $("#btnSearch").click();
                            e.preventDefault();
                        }
                    });

                   

                </script>
</asp:Content>




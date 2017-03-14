<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="ClientDetail.aspx.cs" Inherits="Excel.ClientDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/style.css" rel="stylesheet" />
    <style>
        .input-group {
            float: left !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="content">
        <div class="row">
            <div class="col-lg-12" style="min-height: 100px !important;">

                <div class="panel panel-flat">
                    <div class="panel-heading">
                        <div class="col-md-12 homeheader">
                            Client Detail
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="dvButtons">
                            <div class="col-md-2">
                                <asp:HiddenField ID="hdClientId" runat="server" />
                                <asp:Button ID="btnGenerate" runat="server" Text="Save Intake as PDF" OnClick="btnGenerate_Click" Style="margin-top: 5px;" CssClass="btn btn-primary" />
                            </div>
                            <div class="col-md-2">
                                <input type="button" value="Print Intake" id="btnPrint" class="btn btn-primary" style="margin-top: 5px;" onclick="PrintClientDetails()" />

                            </div>
                            <div class="col-md-2">
                                <input type="button" value="Print" id="btnPrintDetails" class="btn btn-primary" style="margin-top: 5px;" onclick="PrintingClientDetails()" />
                            </div>
                            <div class="col-md-6">
                            </div>

                        </div>
                    </div>

                    <div class="panel-body gridtopMargin">
                        <div class="col-md-12">

                            <div class="form-group">
                                <asp:HiddenField ID="hdnId" runat="server" />


                                <div class="col-md-2">
                                    <label>First Name:</label>
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" id="txtFirstName" type="text" />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Last Name:</label>
                                </div>


                                <div class="col-md-3">
                                    <input class="form-control" id="txtLastName" type="text" />
                                </div>
                                <div class="ClientDetailEditTextPadding">

                                    <div class="col-md-2">
                                        <label>Comment</label>

                                    </div>
                                    <div class="col-md-3">
                                        <textarea id="txtComment" class="form-control"> </textarea>

                                    </div>
                                    <div class="col-md-1">
                                        <button id="btnComments" style="background: white; border: none;">
                                            <img src="Images/comment.jpg" style="width: 30px; height: 30px" /></button>
                                    </div>
                                </div>
                                <%--   <div class="col-md-1"></div>--%>
                                <div class="col-md-2">
                                    <label>Court Name:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtCOurtName" class="form-control" type="text" />

                                </div>
                            </div>

                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Phone:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtPhone" class="form-control" type="text" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Email:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtEmail" class="form-control" type="text" />

                                </div>
                            </div>

                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>File Date:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtFileDate" class="form-control datepicker-menus" type="text" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Court Date:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtCourtDate" class="form-control datepicker-menus" type="text" />

                                </div>
                            </div>
                            <div class="ClientDetailSaleBy" style="padding-top: 55px;">
                                <div class="col-md-2">
                                    <label>Sale by</label>
                                </div>
                                <div class="col-md-3">
                                    <select id="ddlUsers" class="form-control">
                                    </select>
                                    <asp:HiddenField ID="UserId" runat="server" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Source of communication:</label>
                                </div>
                                <div class="col-md-3">

                                    <input type="text" id="txtSourceOfCoumm" class="form-control" placeholder="Source Of Communication" />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Address1:</label>
                                </div>
                                <div class="col-md-9">
                                    <input id="txtAddress1" class="form-control" type="text" />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Address2:</label>
                                </div>
                                <div class="col-md-9">
                                    <input id="txtAddress2" class="form-control" type="text" />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>City</label>
                                </div>
                                <div class="col-md-2">
                                    <input id="txtCity" class="form-control" type="text" />
                                </div>
                                <div class="col-md-1">
                                    <label>State</label>
                                </div>
                                <div class="col-md-2">
                                    <input id="txtState" class="form-control" type="text" />

                                </div>
                                <div class="col-md-1">
                                    <label>Zip</label>
                                </div>
                                <div class="col-md-2">
                                    <input id="txtZip" class="form-control" type="text" />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Description:</label>
                                </div>
                                <div class="col-md-9">
                                    <textarea id="txtDescription" class="form-control" style="width: 55%"></textarea>

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding" style="margin-top: 2%;">
                                <div class="col-md-2">
                                    <label>DOB</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="TxtDOB" class="form-control datepicker-menus" type="text" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>MI</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtMI" class="form-control" type="text" />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Violation:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtViolation" class="form-control" type="text" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>DateIssued:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtDateissued" class="form-control datepicker-menus" type="text" />

                                </div>
                            </div>

                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Salutation:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtSalutation" class="form-control" type="text" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Summons:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtSummons" class="form-control" type="text" />

                                </div>
                            </div>


                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>NJ_CourtId:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtNjCourtId" class="form-control" type="text" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Muncipality:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtMuncipality" class="form-control" type="text" />

                                </div>
                            </div>


                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Complaint:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtComplaint" class="form-control" type="text" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Title:</label>

                                </div>
                                <div class="col-md-3">
                                    <input id="txtTitle" class="form-control" type="text" />

                                </div>
                            </div>


                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>PaymentAgreement:</label>

                                </div>
                                <div class="input-group col-md-3">
                                    <span class="input-group-addon">$</span>
                                    <input id="txtPaymentTotal" onblur='GetRemainingPayment()' class="form-control" type="text" />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>PaymentType:</label>
                                </div>
                                <div class="col-md-3">
                                    <select id="ddlPayment" class="user-field-txt form-control">
                                        <option value="0">Select</option>
                                        <option value="Cash">Cash</option>
                                        <option value="Visa">Visa</option>
                                        <option value="MC">MC</option>
                                        <option value="Amex">Amex</option>
                                    </select>

                                </div>
                            </div>

                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>PaymentPaid:</label>
                                </div>
                                <div class="input-group col-md-3">
                                    <span class="input-group-addon">$</span>
                                    <input class="form-control" id="txtPaymentPaid" onblur='GetRemainingPayment()' type="text" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>PaymentBalance:</label>
                                </div>
                                <div class="input-group col-md-3">
                                    <span class="input-group-addon">$</span>
                                    <input class="form-control" disabled="disabled" id="txtPaymentBalance" type="text" />

                                </div>
                            </div>


                            <div id="dvCardDetails" class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>CardNo:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtCardNo" class="form-control" type="text" />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>ExpDate:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type='number' max='12' min='1' onblur='validateExpireyDate()' id='txtExpirayDateMonth' maxlength='2' oninput='javascript: if (this.value.length > 2) this.value = this.value.slice(0, this.maxLength);' class='user-field-txtExp' placeholder='MM' />&nbsp;/&nbsp<input type='text' id='txtExpirayDateYear' class='user-field-txtExp ' maxlength='2' onblur='validateExpireyDate()' placeholder='YY' />

                                </div>
                            </div>


                            <div class="ClientDetailEditTextPadding">
                                <div id="dvCvv">
                                    <div class="col-md-2">
                                        <label>CVV:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <input id="txtCVV" maxlength='3' class="form-control" type="text" />

                                    </div>
                                    <div class="col-md-1"></div>
                                </div>


                                <div class="col-md-2">
                                    <label>List Type:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtListType" class="form-control" type="text" />

                                </div>
                            </div>
                            <div class="col-md-12" id="filesList">
                            </div>
                        </div>

                        <div class="ClientDetailEditTextPadding">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-8">
                                <input type='button' id="btnupdate" class='btn btn-primary btn-mark' value='Update' />
                                <input type='button' id="btnDelete" class='btn btn-primary btn-mark' value='Delete' />
                                <input type='button' id="btnCashReceipt" class='btn btn-primary btn-mark' value='Cash Receipt' />
                                <input type='button' id="btnCheckReceipt" class='btn btn-primary btn-mark' value='Check Receipt' />
                                <input type='button' id="btnCardAuthorization" class='btn btn-primary btn-mark' value='Card Authorization' />
                                <input type='button' id="btnLegalServices" class='btn btn-primary btn-mark' value='Retainer Agreement' />
                            </div>
                            <div class="col-md-2">
                            </div>
                            <%--  for PopUp--%>
                            <div id="popup1" class="overlay">
                                <div class="popup">
                                    <%--<img src="Images/user.png" style='width: 88px; margin-right: 50%;' />--%>
                                    <h2>Comments</h2>
                                    <a class="close" href="#">&times;</a>
                                    <div id="PopupData" class="content" style="max-height: 400px; overflow-y: scroll; max-width: 800px !important;">
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div id="printClientDetails" style="display: none; border: 0px solid black;">
                        </div>

                        <div id="printingClientDetails" style="display: none; border: 0px solid black;">
                        </div>

                        <div id="editor" style="display: none"></div>

                    </div>

                </div>
            </div>
        </div>
    </div>


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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jspdf/0.9.0rc1/jspdf.min.js"></script>


    <script>
        $(document).ready(function () {
            $('.loadercont').fadeOut();
            BindDDLgetAllUser();
            ClientDetails();
            var id = $('#<%=hdnId.ClientID%>').val();
            GenerateTable(id);
            GenerateTableForPrint(id);
            getFilesByClientID(id);
        });
        //Bind Sale by User DD
        function BindDDLgetAllUser() {
            Id = $('#<%= UserId.ClientID %>').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/UserDetail.aspx/GetAllEmployees",
                data: "",
                dataType: "Json",
                success: function (response) {
                    console.log(response);
                    for (var i = 0; i < response.d.length; i++) {
                        ddlUser = $('#ddlUsers');
                        ddlUser.append('<option value=' + response.d[i].tblUserId + '>' + response.d[i].First_Name + '</option>');
                        if (response.d[i].tblUserId == Id) {
                            $('#ddlUsers').val(response.d[i].tblUserId);
                        }
                    }
                },
                error: function (response) {
                }
            });

        }
        $('#btnComments').click(function () {
            var id = $('#<%= hdnId.ClientID %>').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/ClientDetail.aspx/GetComments_ByClient",
                data: JSON.stringify({ id: id }),
                dataType: "Json",
                success: function (response) {
                    console.log(response.d);
                    var tr;
                    $('#PopupData').empty();
                    if (response.d.length > 0) {
                        for (var i = 0; i < response.d.length; i++) {
                            tr = $('<tr/>');
                            tr.append("<td style='font-size:20px'>" + response.d[i].StComment_Date + "   <b>" + response.d[i].CommentByFirst_Name + "    " + response.d[i].CommentByLast_Name + "</b>  : " + response.d[i].Comment + "</td>");
                            $('#PopupData').append(tr);
                        }
                    }
                    else {
                        tr = $('<tr/>');
                        tr.append("<td>No comments</td>");
                        $('#PopupData').append(tr);
                    }
                    window.location.href = "#popup1";
                },
                error: function (response) {
                }
            });
        });

            function PrintingClientDetails() {
                var divToPrint = document.getElementById('printingClientDetails');
                var htmlToPrint = '' +
                    '<style type="text/css">' +
                    'table th, table td {' +
                    'border:1px solid #fff;' +
                    'padding:5px;' +
                    '}' +
                    '</style>';
                htmlToPrint += divToPrint.innerHTML;
                newWin = window.open("");
                newWin.document.write(htmlToPrint);
                newWin.print();
                newWin.close();
            }

            function GenerateTableForPrint(id) {

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/ClientDetail.aspx/ClientDetail",
                    data: JSON.stringify({ id: id }),
                    dataType: "Json",
                    success: function (response) {
                        console.log(response.d);
                        var mainDiv = $('#printingClientDetails');
                        var checkNull = '<div style="margin-top:30px;margin-left:7%;" id="InnerMainDiv" style="font-size: 22px;"><span style="margin-left: 20px;font-size:300%;font-weight:bold;margin-left: 27%;">Client Details<span style="border-top: 6px solid #ddd"><hr></span></span>'
                                                 + '</div>'
                                                    + '<div style="width:100%px;margin-top: 5%">';
                        checkNull += "<table style='width:800px;font-size:25px;'><tr><td>";
                        if (response.d.F_Name != null && response.d.F_Name != "") {
                            checkNull += "First Name : " + response.d.F_Name + "</td>";

                        }
                        else {
                            checkNull += "First Name : -</td>";
                        }

                        if (response.d.L_Name != null && response.d.L_Name != "") {
                            checkNull += "<td colspan=2> Last Name : " + response.d.L_Name + "</td></tr>";

                        }
                        else {
                            checkNull += "<td colspan=2> Last Name : -</td></tr>";
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Comment != null && response.d.Comment != "") {
                            checkNull += 'Comment : ' + response.d.Comment + '</td>';

                        }
                        else {
                            checkNull += 'Comment : -</td>';
                        }
                        if (response.d.Court_Name != null && response.d.Court_Name != "") {
                            checkNull += '<td colspan=2>Court Name : ' + response.d.Court_Name + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Court Name : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Phone != null && response.d.Phone != "") {
                            checkNull += 'Phone : ' + response.d.Phone + '</td>';

                        }
                        else {
                            checkNull += 'Phone : -</td>';
                        }
                        if (response.d.Email != null && response.d.Email != "") {
                            checkNull += '<td colspan=2>Email : ' + response.d.Email + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Email : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.File_Date != null && response.d.File_Date != "") {
                            checkNull += 'File Date : ' + response.d.File_Date + '</td>';

                        }
                        else {
                            checkNull += 'File Date : -</td>';
                        }
                        if (response.d.CourtDate != null && response.d.CourtDate != "") {
                            checkNull += '<td colspan=2>Court Date : ' + response.d.CourtDate + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Court Date : -</td></tr>';
                        }
                        checkNull += '<tr><td colspan=3>';

                        if (response.d.Address1 != null && response.d.Address1 != "") {
                            checkNull += 'Address1 : ' + response.d.Address1 + '</td></tr>';

                        }
                        else {
                            checkNull += 'Address1 : -</td></tr>';
                        }
                        checkNull += '<tr><td colspan=3>';
                        if (response.d.Address2 != null && response.d.Address2 != "") {
                            checkNull += 'Address2 : ' + response.d.Address2 + '</td></tr>';

                        }
                        else {
                            checkNull += 'Address2 : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.City != null && response.d.City != "") {
                            checkNull += 'City : ' + response.d.City + '</td>';

                        }
                        else {
                            checkNull += 'City : -</td>';
                        }
                        if (response.d.ST != null && response.d.ST != "") {
                            checkNull += '<td>State : ' + response.d.ST + '</td>';

                        }
                        else {
                            checkNull += '<td>State : -</td>';
                        }
                        if (response.d.ZIP != null && response.d.ZIP != "") {
                            checkNull += '<td>Zip : ' + response.d.ZIP + '</td></tr>';

                        }
                        else {
                            checkNull += '<td>Zip : -</td></tr>';
                        }
                        checkNull += '<tr><td colspan=3>';
                        if (response.d.Description != null && response.d.Description != "") {
                            checkNull += 'Description : ' + response.d.Description + '</td></tr>';

                        }
                        else {
                            checkNull += 'Description : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.DOB != null && response.d.DOB != "") {
                            checkNull += "DOB : " + response.d.DOB + "</td>";

                        }
                        else {
                            checkNull += "DOB : -</td>";
                        }

                        if (response.d.MI != null && response.d.MI != "") {
                            checkNull += "<td colspan=2> MI : " + response.d.MI + "</td></tr>";

                        }
                        else {
                            checkNull += "<td colspan=2> MI : -</td></tr>";
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Violation != null && response.d.Violation != "") {
                            checkNull += 'Violation : ' + response.d.Violation + '</td>';

                        }
                        else {
                            checkNull += 'Violation : -</td>';
                        }
                        if (response.d.DateIssued != null && response.d.DateIssued != "") {
                            checkNull += '<td colspan=2>DateIssued : ' + response.d.DateIssued + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>DateIssued : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Salutation != null && response.d.Salutation != "") {
                            checkNull += 'Salutation : ' + response.d.Salutation + '</td>';

                        }
                        else {
                            checkNull += 'Salutation : -</td>';
                        }
                        if (response.d.Summons != null && response.d.Summons != "") {
                            checkNull += '<td colspan=2>Summons : ' + response.d.Summons + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Summons : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.NJ_CourtID != null && response.d.NJ_CourtID != "") {
                            checkNull += 'NJ_CourtID : ' + response.d.NJ_CourtID + '</td>';

                        }
                        else {
                            checkNull += 'NJ_CourtID : -</td>';
                        }

                        if (response.d.Muncipality != null && response.d.Muncipality != "") {
                            checkNull += '<td colspan=2>Muncipality : ' + response.d.Muncipality + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Muncipality : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Complaint != null && response.d.Complaint != "") {
                            checkNull += 'Complaint : ' + response.d.Complaint + '</td>';

                        }
                        else {
                            checkNull += 'Complaint : -</td>';
                        }
                        if (response.d.Title != null && response.d.Title != "") {
                            checkNull += '<td colspan=2>Title : ' + response.d.Title + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Title : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Payment_Total != null && response.d.Payment_Total != "") {
                            checkNull += 'Payment Agreement : ' + response.d.Payment_Total + '</td>';

                        }
                        else {
                            checkNull += 'Payment Agreement : -</td>';
                        }
                        if (response.d.Payment_Type != null && response.d.Payment_Type != "") {
                            checkNull += '<td colspan=2>Payment Type : ' + response.d.Payment_Type + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Payment Type : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Payment_Paid != null && response.d.Payment_Paid != "") {
                            checkNull += 'Payment Paid : ' + response.d.Payment_Paid + '</td>';

                        }
                        else {
                            checkNull += 'Payment Paid : -</td>';
                        }
                        if (response.d.Payment_Balance != null && response.d.Payment_Balance != "") {
                            checkNull += '<td colspan=2>Payment Balance : ' + response.d.Payment_Balance + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Payment Balance : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Payment_Cardno != null && response.d.Payment_Cardno != "") {
                            checkNull += 'Card No. : ' + response.d.Payment_Cardno + '</td>';

                        }
                        else {
                            checkNull += 'Card No. : -</td>';
                        }
                        if (response.d.Payment_Card_ExpDate != null && response.d.Payment_Card_ExpDate != "") {
                            checkNull += '<td colspan=2>Expiry Date : ' + response.d.Payment_Card_ExpDate + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>Expiry Date : -</td></tr>';
                        }
                        checkNull += '<tr><td>';
                        if (response.d.Payment_CVV != null && response.d.Payment_CVV != "") {
                            checkNull += 'CVV : ' + response.d.Payment_CVV + '</td>';

                        }
                        else {
                            checkNull += 'CVV : -</td>';
                        }
                        if (response.d.List_Type != null && response.d.List_Type != "") {
                            checkNull += '<td colspan=2>List Type : ' + response.d.List_Type + '</td></tr>';

                        }
                        else {
                            checkNull += '<td colspan=2>List Type : -</td></tr>';
                        }


                        checkNull += '</table>';


                        checkNull += '</div>';

                        mainDiv.append(checkNull);
                        console.log(mainDiv.html());

                    },
                    error: function (response) {
                    }
                });
            }

            function PrintClientDetails() {

                var printContents = document.getElementById('printClientDetails').innerHTML;
                var originalContents = document.body.innerHTML;
                document.body.innerHTML = printContents;
                window.print();
                document.body.innerHTML = originalContents;
                ClientDetails();
            }
            function GenerateTable(id) {

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/ClientDetail.aspx/ClientDetail",
                    data: JSON.stringify({ id: id }),
                    dataType: "Json",
                    success: function (response) {
                        console.log(response.d);
                        var mainDiv = $('#printClientDetails');
                        var checkNull = '<div style="margin-top:30px;margin-left:7%;" id="InnerMainDiv" style="font-size: 22px;"><span style="margin-left: 20px;font-size:300%;font-weight:bold;margin-left: 27%;">Client Details<span style="border-top: 6px solid #ddd"><hr></span></span>'
                                                 + '<div>'
                                                    + '<div style="float:left;width:70%;font-size:250%;font-weight:bold;margin-top: -5%">';
                        if (response.d.F_Name != null && response.d.F_Name != "") {
                            checkNull += response.d.F_Name + '';

                        }
                        if (response.d.L_Name != null && response.d.L_Name != "") {
                            checkNull += response.d.L_Name + '</div>';

                        }
                        checkNull += '<div style="float:left;width:70%;font-size:150%;font-weight:bold;margin-top:3px">';
                        if (response.d.Address1 != null && response.d.Address1 != "") {
                            checkNull += response.d.Address1 + '<br/>';

                        }
                        if (response.d.City != null && response.d.City != "") {
                            checkNull += response.d.City + ',';

                        }
                        if (response.d.ST != null && response.d.ST != "") {
                            checkNull += response.d.ST + ',';

                        }
                        if (response.d.ZIP != null && response.d.ZIP != "") {
                            checkNull += response.d.ZIP + '<br/>';

                        }
                        if (response.d.Email != null && response.d.Email != "") {
                            checkNull += response.d.Email;

                        }
                        if (response.d.Phone != null && response.d.Phone != "") {
                            checkNull += '<span style="margin-left: 15px;">|</span><span style="margin-left: 20px;">' + response.d.Phone + '</span>';

                        }
                        checkNull += '</div><br/><br/>';
                        checkNull += '<div><div style="float:left;width:70%;font-size:150%;font-weight:bold;margin-top: 7%">';
                        if (response.d.Comment != null && response.d.Comment != "") {
                            checkNull += response.d.Comment + '<br/>';

                        }
                        if (response.d.Court_Name != null && response.d.Court_Name != "") {
                            checkNull += response.d.Court_Name + '<br/>';

                        }
                        if (response.d.File_Date != null && response.d.File_Date != "") {
                            checkNull += response.d.File_Date + '<br/>';

                        }
                        if (response.d.List_Type != null && response.d.List_Type != "") {
                            checkNull += response.d.List_Type + '<br/>';

                        }
                        if (response.d.NJ_CourtID != null && response.d.NJ_CourtID != "") {
                            checkNull += response.d.NJ_CourtID + '<br/>';

                        }
                        if (response.d.CourtDate != null && response.d.CourtDate != "") {
                            checkNull += response.d.CourtDate + '<br/>';

                        }
                        if (response.d.DateIssued != null && response.d.DateIssued != "") {
                            checkNull += ' DateIssued -  ' + response.d.DateIssued + '<br/>';

                        }
                        if (response.d.Description != null && response.d.Description != "") {
                            checkNull += response.d.Description + '<br/>';

                        }
                        if (response.d.Violation != null && response.d.Violation != "") {
                            checkNull += response.d.Violation + '<br/>';

                        }
                        if (response.d.Salutation != null && response.d.Salutation != "") {
                            checkNull += response.d.Salutation + '<br/>';

                        }
                        if (response.d.Summons != null && response.d.Summons != "") {
                            checkNull += response.d.Summons + '<br/>';

                        }
                        if (response.d.Muncipality != null && response.d.Muncipality != "") {
                            checkNull += response.d.Muncipality + '<br/>';

                        }
                        if (response.d.Complaint != null && response.d.Complaint != "") {
                            checkNull += response.d.Complaint;

                        }
                        checkNull += '</div><br/><br/>';
                        if (response.d.Payment_Cardno != null && response.d.Payment_Cardno != "") {
                            checkNull += '<div style="float:left;width:70%;font-size:150%;font-weight:bold;margin-top: 7%"><span style="font-size: 140%">Card Details</span><br/>';
                            checkNull += response.d.Payment_Cardno + '<br/>';
                            if (response.d.Payment_Card_ExpDate != null && response.d.Payment_Card_ExpDate != "") {
                                checkNull += response.d.Payment_Card_ExpDate + '<br/>';

                            }
                            if (response.d.Payment_CVV != null && response.d.Payment_CVV != "") {
                                checkNull += response.d.Payment_CVV;

                            }
                            checkNull += '</div>';
                        }

                        checkNull += '</div></div>';

                        mainDiv.append(checkNull);
                        console.log(mainDiv.html());

                    },
                    error: function (response) {
                    }
                });
            }

            function ClientDetails() {
                var id = $('#<%= hdnId.ClientID %>').val()
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/ClientDetail.aspx/ClientDetail",
                data: JSON.stringify({ id: id }),
                dataType: "Json",
                success: function (response) {
                    console.log(response.d);

                    $('#txtFirstName').val(response.d.F_Name);
                    $('#txtLastName').val(response.d.L_Name);
                    $('#txtListType').val(response.d.List_Type);
                    $('#txtCOurtName').val(response.d.Court_Name);
                    $('#txtFileDate').val(response.d.File_Date);
                    $('#txtCourtDate').val(response.d.CourtDate);
                    $('#txtAddress1').val(response.d.Address1);
                    $('#txtAddress2').val(response.d.Address2);
                    $('#txtCity').val(response.d.City);
                    $('#txtState').val(response.d.ST);
                    $('#txtZip').val(response.d.ZIP);
                    $('#txtDescription').val(response.d.Description);
                    $('#txtMI').val(response.d.MI);
                    $('#txtViolation').val(response.d.Violation);
                    $('#txtDateissued').val(response.d.DateIssued);
                    $('#txtSalutation').val(response.d.Salutation);
                    $('#txtSummons').val(response.d.Summons);
                    $('#txtNjCourtId').val(response.d.NJ_CourtID);
                    $('#txtMuncipality').val(response.d.Muncipality);
                    $('#txtComplaint').val(response.d.Complaint);
                    $('#txtTitle').val(response.d.Title);
                    $('#ddlPayment').val(response.d.Payment_Type);
                    $('#txtPaymentTotal').val(response.d.Payment_Total);
                    $('#txtPaymentPaid').val(response.d.Payment_Paid);
                    $('#txtPaymentBalance').val(response.d.Payment_Balance);
                    $('#txtCardNo').val(response.d.Payment_Cardno);
                    $('#txtExpDate').val(response.d.Payment_Card_ExpDate);
                    $('#txtCVV').val(response.d.Payment_CVV);
                    $('#txtEmail').val(response.d.Email);
                    $('#txtPhone').val(response.d.Phone);
                    $('#TxtDOB').val(response.d.DOB);
                    $('#txtSourceOfCoumm').val(response.d.SourceOfComm);
                    if (response.d.IsAddedBy > 0) {
                        $('#ddlUsers').val(response.d.IsAddedBy);
                    }
                    $("#ddlPayment").change();
                    // $('#txtComment').val(response.d.Comment);
                    if (response.d.Payment_Card_ExpDate != null) {
                        var expdate = response.d.Payment_Card_ExpDate.split('/');
                        if (response.d.expdate != "") {
                            $('#txtExpirayDateMonth').val(expdate[0]);
                            $('#txtExpirayDateYear').val(expdate[1]);
                        }
                    }
                    getFilesByClientID(id);
                },
                error: function (response) {
                    alert(response);
                }
            });
        }

        function getFilesByClientID(id) {
            var date = new Date();
            var todayDate = (date.getMonth() + 1) + "/" + date.getDate() + "/" + date.getFullYear();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/ClientDetail.aspx/filePathList",
                data: JSON.stringify({ id: id, currentDate: todayDate }),
                dataType: "Json",
                success: function (result) {
                    debugger;
                    console.log(result.d);
                    $('#filesList').empty();
                    $('#filesList').append("<br> <font size='3px'>Recently Generated Certificates : </font> <br>");
                    if (result.d.length != 0) {
                        for (var i = 0; i < result.d.length; i++) {
                            //var date = new Date(result.d[i].CreatedDate);
                            $('#filesList').append("<a href='" + result.d[i].FilePath + "'>" + result.d[i].FileName + " (" + result.d[i].CreatedDate.split(' ')[0] + ")</a><br>");
                            //$('#filesList').append("<a onclick='viewFile(" + result.d[i].FilePath + ");'>" + result.d[i].FileName + "</a><br>");
                        }

                    }
                    else {
                        $('#filesList').append("No files.");
                    }

                }
            });
        }

        //function viewFile(path) {
        //    alert(path);
        //    window.open(path, '_blank');
        //}


        $('#btnupdate').click(function () {
            var id = $('#<%= hdnId.ClientID %>').val();
            var F_Name = $('#txtFirstName').val();
            var LastName = $('#txtLastName').val();
            var ListType = $('#txtListType').val();
            var CourtName = $('#txtCOurtName').val();
            var FileDate = $('#txtFileDate').val();
            var CourtDate = $('#txtCourtDate').val();
            var Address1 = $('#txtAddress1').val();
            var Address2 = $('#txtAddress2').val();
            var City = $('#txtCity').val();
            var State = $('#txtState').val();
            var Zip = $('#txtZip').val();
            var Description = $('#txtDescription').val();
            var MI = $('#txtMI').val();
            var Violation = $('#txtViolation').val();
            var DateIssue = $('#txtDateissued').val();
            var Salutation = $('#txtSalutation').val();
            var Summons = $('#txtSummons').val();
            var CourtId = $('#txtNjCourtId').val();
            var Muncipality = $('#txtMuncipality').val();
            var Complaint = $('#txtComplaint').val();
            var Title = $('#txtTitle').val();
            var PaymentType = $('#ddlPayment').val();
            var PaymentTotal = $('#txtPaymentTotal').val();
            var PaymentPaid = $('#txtPaymentPaid').val();
            var PaymentBalance = $('#txtPaymentBalance').val();
            var CardNo = $('#txtCardNo').val();
            var SourceOfCoummunication = $('#txtSourceOfCoumm').val();

            var ClientComment = $('#txtComment').val();

            var DOB = $('#TxtDOB').val();
            var CVV = $('#txtCVV').val();
            var Email = $('#txtEmail').val();
            var Phone = $('#txtPhone').val();

            var Month = $('#txtExpirayDateMonth').val();
            var Year = $('#txtExpirayDateYear').val();

            if (Email != "") {
                if (!ValidateEmail(Email)) {
                    bootbox.alert('not a valid e-mail address');
                    return;
                }
            }

            if (Month != "" || Year != "") {
                if (!$.isNumeric(Month) || !$.isNumeric(Year)) {
                    bootbox.alert('Invalid Expirey Date')
                    $('.loadercont').fadeOut();
                    return;
                }
            }
            var ExpDate = ""
            if (Month != "" || Year != "") {
                ExpDate = Month + '/' + Year;
            }

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/ClientDetail.aspx/UpdateUser",
                data: JSON.stringify({
                    id: id, F_Name: F_Name, LastName: LastName, ListType: ListType, CourtName: CourtName, FileDate: FileDate, CourtDate: CourtDate, Address1: Address1
                    , Address2: Address2, City: City, State: State, Zip: Zip, Description: Description, MI: MI, Violation: Violation, DateIssue: DateIssue, Salutation: Salutation,
                    Summons: Summons, CourtId: CourtId, Muncipality: Muncipality, Complaint: Complaint, Title: Title, PaymentType: PaymentType, PaymentTotal: PaymentTotal,
                    PaymentPaid: PaymentPaid, PaymentBalance: PaymentBalance, CardNo: CardNo, ExpDate: ExpDate, CVV: CVV, Email: Email, Phone: Phone, DOB: DOB, Comment: $('#txtComment').val(), SourceOfCoummunication: SourceOfCoummunication
                }),
                dataType: "Json",
                success: function (response) {
                    bootbox.alert("Client Info Update Successfully");
                    $('#txtComment').val("");
                    getFilesByClientID(id);
                },
                error: function (response) {
                    bootbox.alert(response.d);
                },
            });
        });



            $('#btnCashReceipt').click(function () {
                id = $('#<%= hdnId.ClientID %>').val()


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/ClientDetail.aspx/CashReceipt",
                    data: JSON.stringify({ id: id }),
                    dataType: "Json",
                    success: function (response) {
                        //var Link = "File///" + response.d;
                        bootbox.alert("Cash Receipt Genrated Successfully");
                        window.location.href = response.d;
                        getFilesByClientID(id);
                    },
                    error: function (response) {
                        bootbox.alert(response.d);
                    },
                });
            });



            $('#btnCheckReceipt').click(function () {
                id = $('#<%= hdnId.ClientID %>').val()
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/ClientDetail.aspx/CheckReceipt",
                    data: JSON.stringify({ id: id }),
                    dataType: "Json",
                    success: function (response) {
                        bootbox.alert("Check Receipt Genrated Successfully");
                        window.location.href = response.d;
                        getFilesByClientID(id);
                    },
                    error: function (response) {
                        bootbox.alert(response.d);
                    },
                });
            });


            $('#btnCardAuthorization').click(function () {
                id = $('#<%= hdnId.ClientID %>').val()
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/ClientDetail.aspx/CardAuthorization",
                    data: JSON.stringify({ id: id }),
                    dataType: "Json",
                    success: function (response) {
                        bootbox.alert("Client Receipt Genrated Successfully");
                        window.location.href = response.d;
                        getFilesByClientID(id);
                    },
                    error: function (response) {
                        bootbox.alert(response.d);
                    },
                });
            });





            $('#btnDelete').click(function () {
                bootbox.confirm("Are you sure to delete this user?", function (result) {
                    if (result) {
                        id = $('#<%= hdnId.ClientID %>').val()
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "/ClientDetail.aspx/DeleteClient",
                                    data: JSON.stringify({ id: id }),
                                    dataType: "Json",
                                    success: function (response) {
                                        bootbox.alert("Client Deleted Successfully");
                                        window.location.href = "Clients.aspx";
                                    },
                                    error: function (response) {
                                        bootbox.alert(response.d);
                                    },
                                });

                            }
                    });
                });

                    $('#btnLegalServices').click(function () {
                        id = $('#<%= hdnId.ClientID %>').val()
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "/ClientDetail.aspx/LegalServices",
                            data: JSON.stringify({ id: id }),
                            dataType: "Json",
                            success: function (response) {
                                bootbox.alert("Retainer Agreement genrated Successfully");
                                window.location.href = response.d;
                                getFilesByClientID(id);
                            },
                            error: function (response) {
                                bootbox.alert(response.d);
                            },
                        });
                    });


                    $("#txtZip").keypress(function (e) {

                        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                            //display error message
                            return false;
                        }
                    });
                    $("#txtPhone").keypress(function (e) {
                        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                            //display error message
                            return false;
                        }
                    });

                    $("#txtPaymentTotal").keypress(function (e) {
                        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                            //display error message
                            return false;
                        }
                    });

                    $("#txtPaymentPaid").keypress(function (e) {
                        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                            //display error message
                            return false;
                        }
                    });

                    $("#txtCVV").keypress(function (e) {
                        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                            //display error message
                            return false;
                        }
                    });

                    function ValidateEmail(email) {
                        // Validate email format
                        var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
                        return expr.test(email);
                    };

                    function GetRemainingPayment() {
                        var Total = $("#txtPaymentTotal").val();
                        var Paid = $("#txtPaymentPaid").val();
                        var Balance = Total - Paid;
                        $("#txtPaymentBalance").val(Balance);
                    };


                    function validateExpireyDate() {
                        var Month = $('#txtExpirayDateMonth').val();
                        var Year = $('#txtExpirayDateYear').val();

                        if (Month != "") {
                            if (!$.isNumeric(Month)) {



                                bootbox.alert('Please Type only numeric Value in Month')
                                $('#txtExpirayDateMonth').val('');
                                $('.loadercont').fadeOut();
                                return;
                            }
                            if (Month > 12) {
                                bootbox.alert("value must be less then or equal to 12")
                                $('#txtExpirayDateMonth').val('');
                                return;
                            }
                        }
                        if (Year != "") {
                            if (!$.isNumeric(Year)) {
                                bootbox.alert('Please Type only numeric Value in Year')
                                $('#txtExpirayDateYear').val('');
                                $('.loadercont').fadeOut();
                                return;
                            }
                        }
                    }

                    $("#ddlPayment").change(function () {
                        var Value = $("#ddlPayment").val();
                        if (Value == "Cash") {
                            $("#dvCardDetails").hide();
                            $("#dvCvv").hide();
                            $("#btnCardAuthorization").hide();
                        }
                        else {
                            $("#dvCardDetails").show();
                            $("#dvCvv").show();
                            $("#btnCardAuthorization").show();
                        }
                    });




    </script>
</asp:Content>

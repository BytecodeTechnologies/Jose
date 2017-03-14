<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="AddNew.aspx.cs" Inherits="Excel.AddNew" %>

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
                <!-- Traffic sources -->
                <div class="panel panel-flat">
                    <div class="panel-heading">
                        <div class="col-md-12 homeheader">
                            User Detail
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
                                    <input type="text" class=" form-control require" id="txtFirstName" />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Last Name:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control require" id="txtLastName" />
                                </div>
                                <div class="ClientDetailEditTextPadding">
                                    <div class="col-md-2">
                                        <label>Comment</label>
                                    </div>
                                    <div class="col-md-3">
                                        <textarea id="txtComment" class="form-control "></textarea>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Court Name:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control " id="txtCOurtName" />


                                </div>
                            </div>


                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Phone:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtPhone" class="form-control require" type="text" />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Email:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtEmail" class="form-control require" type="text" />
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
                                    <label>File Date:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control datepicker-menus" id="txtFileDate" />


                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Court Date:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control datepicker-menus" id="txtCourtDate" />


                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Address1:</label>
                                </div>
                                <div class="col-md-9">

                                    <input type="text" class="form-control" id="txtAddress1" />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Address2:</label>
                                </div>
                                <div class="col-md-9">
                                    <input type="text" id="txtAddress2" class="form-control " />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>City</label>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" id="txtCity" class="form-control " />
                                </div>
                                <div class="col-md-1">
                                    <label>State</label>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" id="txtState" class="form-control " />

                                </div>
                                <div class="col-md-1">
                                    <label>Zip</label>
                                </div>
                                <div class="col-md-2">
                                    <input type="text" id="txtZip" class="form-control " />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Description:</label>
                                </div>
                                <div class="col-md-9">
                                    <input type="text" id="txtDescription" class="form-control " style="width: 55%" />

                                    <%--<input class="form-control" cols rows="10" type="text" />--%>
                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding" style="margin-top: 2%;">
                                <div class="col-md-2">
                                    <label>DOB</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="TxtDOB" class="form-control datepicker-menus" />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>MI</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtMI" class="form-control " />

                                </div>
                            </div>
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Violation:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtViolation" class="form-control " />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>DateIssued:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtDateissued" class="form-control datepicker-menus " />

                                </div>
                            </div>

                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Salutation:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtSalutation" class="form-control " />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Summons:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtSummons" class="form-control " />

                                </div>
                            </div>


                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>NJ_CourtId:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtNjCourtId" class="form-control " />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Muncipality:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtMuncipality" class="form-control " />

                                </div>
                            </div>


                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>Complaint:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtComplaint" class="form-control " />

                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>Title:</label>

                                </div>
                                <div class="col-md-3">
                                    <input type="text" id="txtTitle" class="form-control " />
                                </div>
                            </div>


                            <div class="ClientDetailEditTextPadding">


                                <div class="col-md-2">
                                    <label>PaymentAgreement:</label>

                                </div>
                                <div class="input-group col-md-3">
                                    <span class="input-group-addon">$</span>
                                    <input id="txtPaymentTotal" onblur='GetRemainingPayment()' class="form-control " type="text" />
                                </div>
                                <div class="col-md-1"></div>


                                <div class="col-md-2">
                                    <label>PaymentType:</label>
                                </div>
                                <div class="col-md-3">
                                    <select id="ddlPayment" class="user-field-txt  form-control ">
                                        <option value="0">Select</option>
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
                                    <input class="form-control " id="txtPaymentPaid" onblur='GetRemainingPayment()' type="text" />

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
                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>CardNo:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtCardNo" class="form-control " type="text" />
                                </div>
                                <div class="col-md-1"></div>
                                <div class="col-md-2">
                                    <label>ExpDate:</label>
                                </div>
                                <div class="col-md-3">
                                    <%--   <input id="txtExpDate" class="form-control hasDatepicker" type="text" />--%>
                                    <input type='number' max='12' min='1' onblur='validateExpireyDate()' id='txtExpirayDateMonth' maxlength='2' oninput='javascript: if (this.value.length > 2) this.value = this.value.slice(0, this.maxLength);' class='user-field-txtExp ' placeholder='MM' />&nbsp;/&nbsp<input type='text' id='txtExpirayDateYear' class='user-field-txtExp  ' maxlength='2' onblur='validateExpireyDate()' placeholder='YY' />

                                </div>
                            </div>

                            <div class="ClientDetailEditTextPadding">
                                <div class="col-md-2">
                                    <label>CVV:</label>
                                </div>
                                <div class="col-md-3">
                                    <input id="txtCVV" class="form-control " maxlength='3' type="text" /></div>
                                <div class="col-md-1"></div>

                                <div class="col-md-2">
                                    <label>List Type:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class="form-control " id="txtListType" /></div>
                            </div> <%--<div class="ClientDetailEditTextPadding"><div class="col-md-1"></div><div class="col-md-1"></div></div>--%>
                        </div>
                        <div class="ClientDetailEditTextPadding">
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                                <input type='button' id="btnMarkClient" class='btn btn-primary btn-mark' value='Mark as Client' />
                            </div>
                            <div class="col-md-2">
                                <input type='button' id="btnPotentialClient" class='btn btn-primary btn-mark' value='Mark as potential Client' />
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
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

    <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/interactions.min.js"></script>
    <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/widgets.min.js"></script>
    <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/effects.min.js"></script>
    <script type="text/javascript" src="/assets/js/plugins/extensions/mousewheel.min.js"></script>
    <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/globalize/globalize.js"></script>
    <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/globalize/cultures/globalize.culture.de-DE.js"></script>
    <script type="text/javascript" src="/assets/js/core/libraries/jquery_ui/globalize/cultures/globalize.culture.ja-JP.js"></script>
    <script type="text/javascript" src="/assets/js/pages/jqueryui_forms.js"></script>

    <script>
        $(document).ready(function () {
            $('.loadercont').fadeOut();
            BindDDLgetAllUser();
        });

        function BindDDLgetAllUser() {
            debugger;
            Id = $('#<%= UserId.ClientID %>').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/UserDetail.aspx/GetAllEmployees",
                data: "",
                dataType: "Json",
                success: function (response) {
                    debugger;
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

        $("#txtExpirayDateYear").keypress(function (e) {
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


        $('#btnMarkClient').click(function () {
            id = $('#<%= hdnId.ClientID %>').val()
            $('.loadercont').fadeIn();

            var ListType = $("#txtListType").val();
            var Filedate = $("#txtFileDate").val();
            var CourtName = $("#txtCOurtName").val();
            var CourtDate = $("#txtCourtDate").val();
            var LName = $("#txtLastName").val();
            var FName = $("#txtFirstName").val();
            var MI = $("#txtMI").val();
            var Address1 = $("#txtAddress1").val();
            var Address2 = $("#txtAddress2").val();
            var City = $("#txtCity").val();
            var St = $("#txtState").val();
            var Zip = $("#txtZip").val();
            var Dob = $("#TxtDOB").val();
            var Violation = $("#txtViolation").val();
            var Description = $("#txtDescription").val();
            var DateIssued = $("#txtDateissued").val();
            var Salution = $("#txtSalutation").val();
            var Summons = $("#txtSummons").val();
            var CourtId = $("#txtNjCourtId").val();
            var Muncipality = $("#txtMuncipality").val();
            var Complaint = $("#txtComplaint").val();
            var Title = $("#txtTitle").val();
            var Type = $("#ddlPayment").val();
            var Total = $("#txtPaymentTotal").val();
            var Paid = $("#txtPaymentPaid").val();
            var Balance = $("#txtPaymentBalance").val();
            var Cardno = $("#txtCardNo").val();
            var CVV = $("#txtCVV").val();
            var Phone = $("#txtPhone").val();
            var Email = $("#txtEmail").val();
            var Month = $('#txtExpirayDateMonth').val();
            var Year = $('#txtExpirayDateYear').val();
            var comment = $('#txtComment').val();
            var PotentialClient = false;
            var CardExpireyDate = "";
            var sourceOfComm = $('#txtSourceOfCoumm').val();
            var isAddedBy = $('#ddlUsers').val();
            //validate phone for int values

            if (FName == "" || LName == "" || Email == "" || Phone == "") {
                bootbox.alert("All Highlighted fields are required")
                $('.loadercont').fadeOut();
                return;
            }

            if (Phone != "") {
                if (!$.isNumeric(Phone)) {
                    bootbox.alert('Please Type numeric value in Phone')
                    $('.loadercont').fadeOut();
                    return;
                }
            }
            //validate cvv for int values
            if (CVV != "") {
                if (!$.isNumeric(CVV)) {
                    bootbox.alert('Please Type numeric value in CVV')
                    $('.loadercont').fadeOut();
                    return;
                }
            }
            //validate email
            if (Email != "") {
                if (!ValidateEmail(Email)) {
                    $('.loadercont').fadeOut();
                    bootbox.alert('Not a valid email');
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

            if (Month != "" || Year != "") {
                var CardExpireyDate = Month + '/' + Year;
            }

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/AddNew.aspx/MakeNewClient",
                data: JSON.stringify({
                    ListType: ListType, Filedate: Filedate, CourtName: CourtName, CourtDate: CourtDate, LName: LName, FName: FName, MI: MI, Address1: Address1, Address2: Address2, City: City, St: St, Zip: Zip, Dob: Dob,
                    Violation: Violation, Description: Description, DateIssued: DateIssued, Salution: Salution, Summons: Summons, CourtId: CourtId, Muncipality: Muncipality, Complaint: Complaint, Title: Title,
                    Type: Type, Total: Total, Paid: Paid, Balance: Balance, Cardno: Cardno, CardExpireyDate: CardExpireyDate, CVV: CVV, Phone: Phone, Email: Email, PotentialClient: PotentialClient, comment: comment, SourceComm: sourceOfComm, AddedBy: isAddedBy
                }),
                dataType: "Json",
                success: function (response) {
                    bootbox.alert('Client added Successfully');
                    window.location.href = "Clients.aspx"
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });
        });



            $('#btnPotentialClient').click(function () {

                id = $('#<%= hdnId.ClientID %>').val()
                $('.loadercont').fadeIn();

                var ListType = $("#txtListType").val();
                var Filedate = $("#txtFileDate").val();
                var CourtName = $("#txtCOurtName").val();
                var CourtDate = $("#txtCourtDate").val();
                var LName = $("#txtLastName").val();
                var FName = $("#txtFirstName").val();
                var MI = $("#txtMI").val();
                var Address1 = $("#txtAddress1").val();
                var Address2 = $("#txtAddress2").val();
                var City = $("#txtCity").val();
                var St = $("#txtState").val();
                var Zip = $("#txtZip").val();
                var Dob = $("#TxtDOB").val();
                var Violation = $("#txtViolation").val();
                var Description = $("#txtDescription").val();
                var DateIssued = $("#txtDateissued").val();
                var Salution = $("#txtSalutation").val();
                var Summons = $("#txtSummons").val();
                var CourtId = $("#txtNjCourtId").val();
                var Muncipality = $("#txtMuncipality").val();
                var Complaint = $("#txtComplaint").val();
                var Title = $("#txtTitle").val();
                var Type = $("#ddlPayment").val();
                var Total = $("#txtPaymentTotal").val();
                var Paid = $("#txtPaymentPaid").val();
                var Balance = $("#txtPaymentBalance").val();
                var Cardno = $("#txtCardNo").val();
                var CVV = $("#txtCVV").val();
                var Phone = $("#txtPhone").val();
                var Email = $("#txtEmail").val();
                var Month = $('#txtExpirayDateMonth').val();
                var Year = $('#txtExpirayDateYear').val();
                var comment = $('#txtComment').val();
                var PotentialClient = true;
                var CardExpireyDate = "";
                var sourceOfComm = $('#txtSourceOfCoumm').val();
                var isAddedBy = $('#ddlUsers').val();

                if (FName == "" || LName == "" || Email == "" || Phone == "") {
                    bootbox.alert("All Highlighted fields are required")
                    $('.loadercont').fadeOut();
                    return;
                }

                if (Phone != "") {
                    if (!$.isNumeric(Phone)) {
                        bootbox.alert('Please Type numeric value in Phone')
                        $('.loadercont').fadeOut();
                        return;
                    }
                }

                if (CVV != "") {
                    if (!$.isNumeric(CVV)) {
                        bootbox.alert('Please Type numeric value in CVV')
                        $('.loadercont').fadeOut();
                        return;
                    }
                }

                if (Email != "") {
                    if (!ValidateEmail(Email)) {
                        $('.loadercont').fadeOut();
                        bootbox.alert('Not a valid email');
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

                if (Month != "" || Year != "") {
                    var CardExpireyDate = Month + '/' + Year;
                }

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "/AddNew.aspx/MakeNewClient",
                    data: JSON.stringify({
                        ListType: ListType, Filedate: Filedate, CourtName: CourtName, CourtDate: CourtDate, LName: LName, FName: FName, MI: MI, Address1: Address1, Address2: Address2, City: City, St: St, Zip: Zip, Dob: Dob,
                        Violation: Violation, Description: Description, DateIssued: DateIssued, Salution: Salution, Summons: Summons, CourtId: CourtId, Muncipality: Muncipality, Complaint: Complaint, Title: Title,
                        Type: Type, Total: Total, Paid: Paid, Balance: Balance, Cardno: Cardno, CardExpireyDate: CardExpireyDate, CVV: CVV, Phone: Phone, Email: Email, PotentialClient: PotentialClient, comment: comment, SourceComm: sourceOfComm, AddedBy: isAddedBy
                    }),
                    dataType: "Json",
                    dataType: "Json",
                    success: function (response) {
                        bootbox.alert('Potential Client added Successfully');
                        window.location.href = "PotentialClient.aspx"
                        $('.loadercont').fadeOut();
                    },
                    error: function (response) {
                        $('.loadercont').fadeOut();
                    }
                });
            });





    </script>
</asp:Content>

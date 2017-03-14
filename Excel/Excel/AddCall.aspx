<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="AddCall.aspx.cs" Inherits="Excel.AddCall" %>

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
                            Add Call Log
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin" style="margin-left: 350px">
                        <div class="col-md-12">
                            <div class="form-group">

                                <div class="col-md-2">
                                    <label>First Name:</label>
                                </div>
                                <div class="col-md-3">
                                    <input type="text" class=" form-control" id="txtFirstName" placeholder="first name" />
                                </div>
                                <div class="col-md-6"></div>


                                <div class="ClientDetailEditTextPadding">
                                    <div class="col-md-2">
                                        <label>Last Name:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <input id="txtLastName" class="form-control" type="text" placeholder="Last Name" />
                                    </div>
                                    <div class="col-md-6"></div>
                                </div>



                                <div class="ClientDetailEditTextPadding">
                                    <div class="col-md-2">
                                        <label>Phone:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <input id="txtPhone" class="form-control" type="text" placeholder="Phone" name="txtInput" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);"/>
                                        <div class="col-md-6"></div>
                                    </div>


                                    <div class="ClientDetailEditTextPadding">
                                        <div class="col-md-2">
                                            <label>Notes:</label>
                                        </div>
                                        <div class="col-md-3">
                                            <textarea id="txtNotes" class="form-control"></textarea>
                                            <div class="col-md-6"></div>
                                        </div>

                                        <div class="ClientDetailEditTextPadding">

                                            <%--  <div class="ClientDetailEditTextPadding">--%>
                                            <div class="col-md-8">
                                                <input type='button' id="btnAddLog" class='btn btn-primary btn-mark' value='Save' />
                                            </div>
                                            <div class="col-md-1">
                                            </div>
                                            <div class="col-md-2">
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
        </div>
    </div>
    <%-- </div>--%>
    <asp:HiddenField ID="hdnCallId" runat="server" />
    <input type="hidden" id="htmlhdnCallId" />
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery-1.7.1.js"></script>

    <script>
       
        $(document).ready(function () {
            getCallDetails();
            $('.loadercont').fadeOut();

        });


        function AddCallLog()
        {
            var FirstName = $("#txtFirstName").val();
            var LastName = $("#txtLastName").val();
            var Phone = $("#txtPhone").val();
            var Notes = $("#txtNotes").val();
            var Id = $('#<%= hdnCallId.ClientID %>').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/AddCall.aspx/AddCallLog",
                data: JSON.stringify({
                    Id:Id,
                    FirstName: FirstName,
                    LastName: LastName,
                    Phone: Phone,
                    Notes: Notes
                }),
                dataType: "Json",
                dataType: "Json",
                success: function (response) {
                    bootbox.alert('Call Log Added Successfully');
                     window.location.href = "CallLogs.aspx"
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });

        }

        $("#btnAddLog").click(function ()
        {
            var validate = true;
            if ($("#txtFirstName").val().trim() == null || $("#txtFirstName").val().trim() == "" ||
                $("#txtLastName").val().trim() == null || $("#txtLastName").val().trim() == "" ||
                $("#txtPhone").val().trim() == null || $("#txtPhone").val().trim() == "" ||
                $("#txtNotes").val().trim() == null || $("#txtNotes").val().trim() == ""
                )
            {
                validateform();
                validate = false;

            }
            if (validate)
            {
                AddCallLog();
            }
             
        });

        function reset()
        {
            $("#txtFirstName").val("");
            $("#txtLastName").val("");
            $("#txtPhone").val("");
            $("#txtNotes").val("");
        }

        function validateform() {

            if (!$("#txtFirstName").val().trim()) {
                if ($("#txtFirstName").parent().next(".validation").length == 0) // only add if not added
                {
                    $("#txtFirstName").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter First Name</div>");
                }
                $("#txtFirstName").focus();
                focusSet = true;
            }
            else {
                $("#txtFirstName").parent().next(".validation").remove(); // remove it
            }
            if (!$("#txtLastName").val().trim()) {
                if ($("#txtLastName").parent().next(".validation").length == 0) // only add if not added
                {
                    $("#txtLastName").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Last Name</div>");
                }

            }
            else {
                $("#txtLastName").parent().next(".validation").remove(); // remove it
            }


            if (!$("#txtPhone").val().trim()) {
                if ($("#txtPhone").parent().next(".validation").length == 0) // only add if not added
                {
                    $("#txtPhone").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Phone</div>");
                }

            }
            else {
                $("#txtPhone").parent().next(".validation").remove(); // remove it
            }

            if (!$("#txtNotes").val().trim()) {
                if ($("#txtNotes").parent().next(".validation").length == 0) // only add if not added
                {
                    $("#txtNotes").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Notes</div>");
                }

            }
            else {
                $("#txtNotes").parent().next(".validation").remove(); // remove it
            }
        }

        function getCallDetails()
        {
            var Id = $('#<%= hdnCallId.ClientID %>').val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/AddCall.aspx/CallLogDetails",
                data: JSON.stringify({
                    id: Id
                    }),
                dataType: "Json",
                dataType: "Json",
                success: function (response) {
                    console.log(response);
                   
                    if (response.d.FirstName!=null)
                    {
                        $("#txtFirstName").val(response.d.FirstName);
                        $("#txtLastName").val(response.d.LastName);
                        $("#txtPhone").val(response.d.Phone);
                        $("#txtNotes").val(response.d.Notes);
                     
                    }
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });
        }

        //$("#txtPhone").keypress(function (e) {
        //    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //        //display error message
        //        return false;
        //    }
        //});

        var zChar = new Array(' ', '(', ')', '-', '.');
        var maxphonelength = 13;
        var phonevalue1;
        var phonevalue2;
        var cursorposition;

        function ParseForNumber1(object) {
            phonevalue1 = ParseChar(object.value, zChar);
        }
        function ParseForNumber2(object) {
            phonevalue2 = ParseChar(object.value, zChar);
        }

        function backspacerUP(object, e) {
            if (e) {
                e = e;
            } else {
                e = window.event;
            }
            if (e.which) {
                var keycode = e.which;
            } else {
                var keycode = e.keyCode;
            }

            ParseForNumber1(object);

            if (keycode >= 48) {
                ValidatePhone(object);
            }
        }

        function backspacerDOWN(object, e) {
            if (e) {
                e = e;
            } else {
                e = window.event;
            }
            if (e.which) {
                var keycode = e.which;
            } else {
                var keycode = e.keyCode;
            }
            ParseForNumber2(object);
        }

        function GetCursorPosition() {

            var t1 = phonevalue1;
            var t2 = phonevalue2;
            var bool = false;
            for (i = 0; i < t1.length; i++) {
                if (t1.substring(i, 1) != t2.substring(i, 1)) {
                    if (!bool) {
                        cursorposition = i;
                        bool = true;
                    }
                }
            }
        }

        function ValidatePhone(object) {

            var p = phonevalue1;

            p = p.replace(/[^\d]*/gi, "");

            if (p.length < 3) {
                object.value = p;
            } else if (p.length == 3) {
                pp = p;
                d4 = p.indexOf('(');
                d5 = p.indexOf(')');
                if (d4 == -1) {
                    pp = "(" + pp;
                }
                if (d5 == -1) {
                    pp = pp + ")";
                }
                object.value = pp;
            } else if (p.length > 3 && p.length < 7) {
                p = "(" + p;
                l30 = p.length;
                p30 = p.substring(0, 4);
                p30 = p30 + ")";

                p31 = p.substring(4, l30);
                pp = p30 + p31;

                object.value = pp;

            } else if (p.length >= 7) {
                p = "(" + p;
                l30 = p.length;
                p30 = p.substring(0, 4);
                p30 = p30 + ")";

                p31 = p.substring(4, l30);
                pp = p30 + p31;

                l40 = pp.length;
                p40 = pp.substring(0, 8);
                p40 = p40 + "-";

                p41 = pp.substring(8, l40);
                ppp = p40 + p41;

                object.value = ppp.substring(0, maxphonelength);
            }

            GetCursorPosition();

            if (cursorposition >= 0) {
                if (cursorposition == 0) {
                    cursorposition = 2;
                } else if (cursorposition <= 2) {
                    cursorposition = cursorposition + 1;
                } else if (cursorposition <= 5) {
                    cursorposition = cursorposition + 2;
                } else if (cursorposition == 6) {
                    cursorposition = cursorposition + 2;
                } else if (cursorposition == 7) {
                    cursorposition = cursorposition + 4;
                    e1 = object.value.indexOf(')');
                    e2 = object.value.indexOf('-');
                    if (e1 > -1 && e2 > -1) {
                        if (e2 - e1 == 4) {
                            cursorposition = cursorposition - 1;
                        }
                    }
                } else if (cursorposition < 11) {
                    cursorposition = cursorposition + 3;
                } else if (cursorposition == 11) {
                    cursorposition = cursorposition + 1;
                } else if (cursorposition >= 12) {
                    cursorposition = cursorposition;
                }

                //var txtRange = object.createTextRange();
                //txtRange.moveStart("character", cursorposition);
                //txtRange.moveEnd("character", cursorposition - object.value.length);
                //txtRange.select();
            }

        }

        function ParseChar(sStr, sChar) {
            if (sChar.length == null) {
                zChar = new Array(sChar);
            }
            else zChar = sChar;

            for (i = 0; i < zChar.length; i++) {
                sNewStr = "";

                var iStart = 0;
                var iEnd = sStr.indexOf(sChar[i]);

                while (iEnd != -1) {
                    sNewStr += sStr.substring(iStart, iEnd);
                    iStart = iEnd + 1;
                    iEnd = sStr.indexOf(sChar[i], iStart);
                }
                sNewStr += sStr.substring(sStr.lastIndexOf(sChar[i]) + 1, sStr.length);

                sStr = sNewStr;
            }

            return sNewStr;
        }

    </script>
</asp:Content>

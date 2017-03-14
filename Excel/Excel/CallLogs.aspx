<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="CallLogs.aspx.cs" Inherits="Excel.CallLogs" %>

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
                            Call Logs
                            
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin">
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-md-1">
                                    <input type="text" class=" form-control SaveKeyPress" id="txtFirstName" placeholder="first name" />
                                </div>
                                <div class="col-md-2">
                                    <input id="txtLastName" class="form-control SaveKeyPress" type="text" placeholder="Last Name" />
                                </div>
                                <div class="col-md-2">
                                    <input id="txtPhone" class="form-control SaveKeyPress" type="text" placeholder="Phone" name="txtInput" onkeydown="javascript:backspacerDOWN(this,event);" onkeyup="javascript:backspacerUP(this,event);" />
                                </div>
                                <div class="col-md-2">
                                    <textarea id="txtNotes" class="form-control SaveKeyPress" placeholder="Notes"></textarea>
                                </div>


                                <div class="col-md-2">
                                    <select id="ddlUsers" class="form-control" multiple="multiple">
                                        <%--<option value="-1">Select User</option>--%>
                                        <option value="mlaverysmith@stabilelawfirm.com">Megan</option>
                                        <option value="wpopovich@stabilelawfirm.com">Bill Jr.</option>
                                        <option value="popovichwilliam@gmail.com">Bill Sr.</option>
                                        <%-- <option value="William@stabilelawfirm.com">William</option>--%>
                                        <option value="moriundo@stabilelawfirm.com">Maria</option>
                                        <option value="joriundo@stabilelawfirm.com">Jose</option>
                                        <option value="kerry@stabilelawfirm.com">Kerry</option>
                                        <option value="adamato@stabilelawfirm.com">Adamato</option>
                                        <option value="reception@stabilelawfirm.com">Reception</option>
                                    </select>
                                </div>
                                <div class="col-md-1">
                                    <input type='button' id="btnAddLog" class='btn btn-primary' value='Save' />
                                </div>
                                <div class="col-md-2">
                                    <input type='button' id="btnSaveAndEmailLog" class='btn btn-primary form-control' value='Save and Email' />

                                </div>
                                <%--<label id="lblAddNewCallLog" class="control-label col-lg-2"><a href="AddCall.aspx" class="btn btn-primary">Add New Call Log</a></label>--%>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group" style="margin-bottom: 40px !important">
                                    <label class="control-label col-lg-2">Search</label>
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <select id="ddlSearchbyDate" class="form-control">
                                                    <option value="0">All</option>
                                                    <option value="1">Today</option>
                                                    <option value="2">Yesterday</option>
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
                                            <div class="col-md-2">
                                                <input type="text" id="txtSearch" placeholder="Search" class="form-control pressenter" />
                                            </div>
                                            <div class="col-md-1">
                                                <input type="button" id="btnSearch" value="Search" class="btn btn-primary  form-control" />

                                            </div>
                                            <div class="col-md-2">
                                                <input type='button' id="btnEmailTodayRecords" class='btn btn-primary form-control' value="Mail Today's Report" />
                                            </div>
                                            <div class="col-md-1">
                                                <input type="button" value="Print" id="btnPrintFullGrid" class="btn btn-primary form-control" onclick="PrintFullGrid()" />
                                            </div>
                                            <div class="col-md-3">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12" style="padding-top: 10px;">
                                        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="190%">
                                            <thead>
                                                <tr class="top123">
                                                    <th>First Name</th>
                                                    <th>Last Name</th>
                                                    <th>Phone</th>
                                                    <th>Notes</th>
                                                    <th>Added By</th>
                                                    <th>Added Date</th>
                                                    <th class="btndeletebyAdmin">Delete</th>
                                                </tr>
                                            </thead>
                                            <tbody id="tblbody">
                                            </tbody>
                                        </table>
                                        <div id="dvPaging"></div>
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
    <input type="hidden" id="hdnCallId" value="0" />
    <asp:HiddenField runat="server" ID="HdnUserRole" />
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/DataTable/jquery-1.12.3.js"></script>
    <script src="Scripts/DataTable/jquery.dataTables.min.js"></script>
    <script src="Scripts/DataTable/dataTables.bootstrap.min.js"></script>
    <script src="Scripts/bootstrap_multiselect.js"></script>

    <script>

        $(document).ready(function () {
            $('.loadercont').fadeOut();
            CallLogs();
            localStorage.setItem('lastTab1', "liTopCallLog");
            GenerateTableForAll();
            $('#ddlUsers').multiselect({
                includeSelectAllOption: true,
                nonSelectedText: 'Select User',
                buttonWidth: '100%'
            });
        });

        $("#btnSearch").click(function () {
            CallLogs();
            GenerateTableForAll();
        });

        $("#ddlSearchbyDate").change(function () {
            CallLogs();
            GenerateTableForAll();
            $('.loadercont').fadeOut();;
        });
        $('.pressenter').keypress(function (e) {
            if (e.which == 13) {
                $('#btnSearch').click();
                e.preventDefault();
            }
        });
        $('.SaveKeyPress').keypress(function (e) {
            if (e.which == 13) {
                $('#btnAddLog').click();
                e.preventDefault();
            }
        });

        function ChangePhoneFormat() {
            // Validate email format
            var phoneformat = $('#inputPhone').val();
            if (phoneformat.length == 8) {
                text = phoneformat.replace(/(\d\d\d)(\d\d\d)(\d\d\d\d)/, "($1) $2-$3");
                $('#inputPhone').val(text);
            }
        };


        function PrintFullGrid() {
            var divToPrint = document.getElementById('printClients');
            var htmlToPrint = '' +
                '<style type="text/css">' +
                'table th, table td {' +
                'padding:5px; font-size:20px;border:1px solid black;' +
                '}' +
                //'table th { background-color:#A9A9A9; }' +                
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
            var SearchByName = $("#txtSearch").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/CallLogs.aspx/PrintCallLog",
                data: JSON.stringify({ Search: Search, PageIndex: 0, SearchByName: SearchByName }),
                dataType: "json",
                success: function (response) {
                    $('#printClients').empty();
                    var tblDataPrint = "<table>" +
                        "<tr>" +
                        "<th>First Name</th>" +
                        "<th>Last Name</th>" +
                        "<th>Phone</th>" +
                        "<th>Notes</th>" +
                        "<th>Added By</th>" +
                        "<th>Added Date</th></tr>";
                    console.log(response)
                    if (response.d.length > 0) {

                        for (var i = 0; i < response.d.length; i++) {
                            tblDataPrint += "<tr><td>" + response.d[i].FirstName + "</td>";
                            tblDataPrint += "<td>" + response.d[i].LastName + "</td>";
                            if (response.d[i].Phone.length >= 8 && !response.d[i].Phone.match(/\(/)) {
                                var phoned = "";
                                var newStr = response.d[i].Phone.replace(/-/g, "");

                                var newStr1 = newStr.replace("-", "");

                                phoned = newStr1.replace(/(\d\d\d)(\d\d\d)(\d\d)/, "($1)$2-$3");
                                tblDataPrint += "<td>" + phoned + "</td>";
                            }
                            else {
                                tblDataPrint += "<td>" + response.d[i].Phone + "</td>";
                            }
                            tblDataPrint += "<td>" + response.d[i].Notes + "</td>";
                            tblDataPrint += "<td>" + response.d[i].AddedName + "</td>";
                            tblDataPrint += "<td>" + response.d[i].strDateAdded + "</td></tr>";
                        }
                        $('#printClients').append(tblDataPrint);
                    }
                    else {
                        tblDataPrint += "<tr><td colspan='6'> No Item to Display</td></tr>";
                        $('#printClients').append(tblDataPrint);
                    }
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                }

            });
        };

        $("#btnEmailTodayRecords").click(function () {
            $('.loadercont').fadeIn();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/CallLogs.aspx/EmailTodayCallLogs",
                data: JSON.stringify({ Search: "1" }),
                dataType: "json",
                success: function (response) {
                    bootbox.alert(response.d);
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                }
            });
        });


        function CallLogs() {
            $('.loadercont').fadeIn();
            var Search = $("#ddlSearchbyDate").val();
            var SearchByName = $("#txtSearch").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/CallLogs.aspx/CallLog",
                data: JSON.stringify({ Search: Search, PageIndex: 0, SearchByName: SearchByName }),
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
                            tr.append("<td> <a id=" + response.d[i].Id + " onclick='getCallDetails(this.id)' style='cursor: pointer;'>" + response.d[i].FirstName + "  </a> </td>");
                            tr.append("<td>" + response.d[i].LastName + "</td>");
                            if (response.d[i].Phone.length >= 8 && !response.d[i].Phone.match(/\(/)) {
                                var phoned = "";
                                var newStr = response.d[i].Phone.replace(/-/g, "");

                                var newStr1 = newStr.replace("-", "");

                                phoned = newStr1.replace(/(\d\d\d)(\d\d\d)(\d\d)/, "($1)$2-$3");
                                tr.append("<td>" + phoned + "</td>");
                            }
                            else {
                                tr.append("<td>" + response.d[i].Phone + "</td>");
                            }
                            tr.append("<td>" + response.d[i].Notes + "</td>");
                            tr.append("<td>" + response.d[i].AddedName + "</td>");
                            tr.append("<td>" + response.d[i].strDateAdded + "</td>");
                            tr.append("<td class='btndeletebyAdmin'> <input type='button' value='Delete' id=" + response.d[i].Id + " onclick='DeleteCallLog(this.id)' style='cursor: pointer;' class='btn btn-primary '/></td>");
                            $('#example').append(tr);
                        }

                        if ($("#HdnUserRole").val() == "1") {
                            $(".btndeletebyAdmin").show();
                        }
                        else {
                            $(".btndeletebyAdmin").hide();
                        }
                    }
                    else {
                        tr = $('<tr/>');
                        tr.append("<td colspan='7'> No Item to Display</td>");
                        $('#example').append(tr);
                    }
                    $('#example').show();
                    if ($("#HdnUserRole").val() == "1") {
                        $(".btndeletebyAdmin").show();
                    }
                    else {
                        $(".btndeletebyAdmin").hide();
                    }
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
            var SearchByName = $("#txtSearch").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/CallLogs.aspx/CallLog",
                data: JSON.stringify({ Search: Search, PageIndex: Pageno, SearchByName: SearchByName }),
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
                            tr.append("<td> <a id=" + response.d[i].Id + " onclick='getCallDetails(this.id)' style='cursor: pointer;'>" + response.d[i].FirstName + "  </a> </td>");
                            tr.append("<td>" + response.d[i].LastName + "</td>");
                            if (response.d[i].Phone.length >= 8 && !response.d[i].Phone.match(/\(/)) {
                                var phoned = "";
                                var newStr = response.d[i].Phone.replace(/-/g, "");

                                var newStr1 = newStr.replace("-", "");

                                phoned = newStr1.replace(/(\d\d\d)(\d\d\d)(\d\d)/, "($1)$2-$3");
                                tr.append("<td>" + phoned + "</td>");
                            }
                            else {
                                tr.append("<td>" + response.d[i].Phone + "</td>");
                            }
                            tr.append("<td>" + response.d[i].Notes + "</td>");
                            tr.append("<td>" + response.d[i].AddedName + "</td>");
                            tr.append("<td>" + response.d[i].strDateAdded + "</td>");
                            tr.append("<td> <input  type='button' value='Delete' id=" + response.d[i].Id + " onclick='DeleteCallLog(this.id)' style='cursor: pointer;' class='btn btn-primary btndeletebyAdmin'/></td>");
                            $('#example').append(tr);

                        }
                        if ($("#HdnUserRole").val() == "1") {
                            $(".btndeletebyAdmin").show();
                        }
                        else {
                            $(".btndeletebyAdmin").hide();
                        }


                    }
                    else {
                        tr = $('<tr/>');
                        tr.append("<td colspan='7'> No Item to Display</td>");
                        $('#example').append(tr);
                    }


                    $('#example').show();
                    if ($("#HdnUserRole").val() == "1") {
                        $(".btndeletebyAdmin").show();
                    }
                    else {
                        $(".btndeletebyAdmin").hide();
                    }
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

        function CallLogDetails(id) {
            window.location.href = "AddCall.aspx?CallId=" + id;
        }

        //-------------------------------------------------------------

        function AddCallLog() {
            debugger;
            var FirstName = $("#txtFirstName").val();
            var LastName = $("#txtLastName").val();
            var Phone = $("#txtPhone").val().trim();
            var Notes = $("#txtNotes").val();
            var Id = $("#hdnCallId").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/AddCall.aspx/AddCallLog",
                data: JSON.stringify({
                    Id: Id,
                    FirstName: FirstName,
                    LastName: LastName,
                    Phone: Phone,
                    Notes: Notes
                }),
                dataType: "Json",
                dataType: "Json",
                success: function (response) {
                    //if (response.d == 1) {
                    bootbox.alert('Call Log Added Successfully');
                    CallLogs();
                    GenerateTableForAll();
                    reset();
                    //}
                    //else {
                    //    bootbox.alert('Some problem occured. Try Again....');
                    //    setTimeout(function () { window.location.reload(); }, 3000);
                    //}
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });

        }
        function AddandEmailCallLog() {
            var FirstName = $("#txtFirstName").val();
            var LastName = $("#txtLastName").val();
            var Phone = $("#txtPhone").val().trim();
            var Notes = $("#txtNotes").val();
            var User = $("#ddlUsers").val().toString();
            //var brands = $('#ddlUsers option:selected');
            //var selected = [];
            //$(brands).each(function (index, brand) {
            //    selected.push([$(this).val()]);

            //});
            //var User = $('#usersList').val(selected);
            var Id = $("#hdnCallId").val();
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/AddCall.aspx/AddandEmailCallLog",
                data: JSON.stringify({
                    Id: Id,
                    FirstName: FirstName,
                    LastName: LastName,
                    Phone: Phone,
                    Notes: Notes,
                    EmailToUser: User
                }),
                dataType: "Json",
                dataType: "Json",
                success: function (response) {
                    bootbox.alert('Call Log Saved and Emailed  Successfully');
                    CallLogs();
                    GenerateTableForAll();
                    reset();
                    $('.loadercont').fadeOut();
                },
                error: function (response) {
                    console.log(response.responseText);
                    $('.loadercont').fadeOut();
                }
            });


        }
        $('#btnSaveAndEmailLog').click(function () {
            //alert($('#ddlUsers').val());
            var validate = true;
            if ($("#txtFirstName").val().trim() == null || $("#txtFirstName").val().trim() == "" ||
                $("#txtLastName").val().trim() == null || $("#txtLastName").val().trim() == "" ||
                $("#txtPhone").val().trim() == null || $("#txtPhone").val().trim() == "" ||
                $("#txtNotes").val().trim() == null || $("#txtNotes").val().trim() == "" ||
                $('#ddlUsers').val() == "" || $('#ddlUsers').val() == null
                ) {
                validate = false;
                bootbox.alert('All fields are required');
            }
            if (validate) {
                AddandEmailCallLog();
            }
        });

        $("#btnAddLog").click(function () {
            var validate = true;
            if ($("#txtFirstName").val().trim() == null || $("#txtFirstName").val().trim() == "" ||
                $("#txtLastName").val().trim() == null || $("#txtLastName").val().trim() == "" ||
                $("#txtPhone").val().trim() == null || $("#txtPhone").val().trim() == "" ||
                $("#txtNotes").val().trim() == null || $("#txtNotes").val().trim() == ""
                ) {
                validate = false;
                bootbox.alert('All fields are required');
            }
            if (validate) {
                AddCallLog();
            }

        });

        function reset() {
            $("#txtFirstName").val("");
            $("#txtLastName").val("");
            $("#txtPhone").val("");
            $("#txtNotes").val("");
        }
        function getCallDetails(CId) {
            var Id = CId;
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
                    if (response.d.FirstName != null) {
                        $("#txtFirstName").val(response.d.FirstName);
                        $("#txtLastName").val(response.d.LastName);
                        $("#txtPhone").val(response.d.Phone);
                        $("#txtNotes").val(response.d.Notes);
                        $("#hdnCallId").val(CId);
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




        function DeleteCallLog(id) {
            bootbox.confirm("Are you sure?<br/> you want to delete.", function (result) {
                if (result) {
                    var Id = id;
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/CallLogs.aspx/DeleteCallLog",
                        data: JSON.stringify({
                            Id: Id
                        }),
                        dataType: "Json",
                        dataType: "Json",
                        success: function (response) {
                            bootbox.alert('Call Log Deleted Successfully');
                            CallLogs();
                            $('.loadercont').fadeOut();
                        },
                        error: function (response) {
                            $('.loadercont').fadeOut();
                        }
                    });
                }
            });
        }



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

                var txtRange = object.createTextRange();
                txtRange.moveStart("character", cursorposition);
                txtRange.moveEnd("character", cursorposition - object.value.length);
                txtRange.select();
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

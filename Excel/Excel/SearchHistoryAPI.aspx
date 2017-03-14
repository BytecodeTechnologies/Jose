<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="SearchHistoryAPI.aspx.cs" Inherits="Excel.SearchHistoryAPI" %>
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
                           Search History
                            
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin">
                        <div class="col-md-12">                                                                           
                                <div class="row">
                                    <div class="col-md-12" style="padding-top: 10px;">
                                        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="190%">
                                            <thead>
                                                <tr class="top123">
                                                    <th>First Name</th>
                                                    <th>Last Name</th>
                                                    <th>DOB</th>
                                                    <th>Search By</th>
                                                    <th>Search Date</th>                                                                                                      
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
            </div>
        </div>
    </div>



    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script>
        $(document).ready(function () {
            $('.loadercont').fadeOut();
            localStorage.setItem('lastTab1', "liTopSearchHistoryAPI");
            SearchHistory();
        });

        function SearchHistory() {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/SearchHistoryAPI.aspx/GetHistory",
                data: JSON.stringify({ PageIndex: 0 }),
                dataType: "Json",
                success: function (response) {
                    console.log(response.d);
                    $('#tblbody').empty();
                    var tr;
                    var TotalRecords = "";
                    if (response.d.length > 0) {
                        for (var i = 0; i < response.d.length; i++) {
                            tr = $('<tr/>');
                            TotalRecords = response.d[i].TotalCount;
                            tr.append("<td>" + response.d[i].F_Name + "</td>");
                            tr.append("<td>" + response.d[i].L_Name + "</td>");
                            tr.append("<td>" + response.d[i].DOB + "</td>");
                            tr.append("<td>" + response.d[i].Search_By + "</td>");
                            tr.append("<td>" + response.d[i].Search_Date + "</td>");
                            $('#tblbody').append(tr);
                        }
                    }
                    else {                    
                        tr.append("<td colspan='5'>No History</td>");
                        $('#tblbody').append(tr);
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
                    $('.loadercont').fadeOut();
                }
            });
        }

        function Paging(Pageno) {          
            $('.loadercont').fadeIn();            
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/SearchHistoryAPI.aspx/GetHistory",
                data: JSON.stringify({ PageIndex: Pageno }),
                dataType: "Json",
                success: function (response) {
                    console.log(response.d);
                    $('#tblbody').empty();
                    var tr;
                    var TotalRecords = "";
                    if (response.d.length > 0) {
                        for (var i = 0; i < response.d.length; i++) {
                            tr = $('<tr/>');
                            TotalRecords = response.d[i].TotalCount;
                            tr.append("<td>" + response.d[i].F_Name + "</td>");
                            tr.append("<td>" + response.d[i].L_Name + "</td>");
                            tr.append("<td>" + response.d[i].DOB + "</td>");
                            tr.append("<td>" + response.d[i].Search_By + "</td>");
                            tr.append("<td>" + response.d[i].Search_Date + "</td>");
                            $('#tblbody').append(tr);
                        }
                    }
                    else {
                        tr.append("<td colspan='5'>No History</td>");
                        $('#tblbody').append(tr);
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

    </script>

</asp:Content>

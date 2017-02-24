<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="StableLawFirm.CategoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="blog-page-two blog-single-page">
        <div class="container">
            <div class="row">

               
                <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 pull-right blog-page-main-content111" style="margin-top: -13%;">
                    <div class="single-news-postTwo">
                         <div class="col-md-12 ResultFormat">

                            <h1 class="Quote_title1">Category List</h1>
                                  </div>
                        <div class="gridscroll">

                        <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                            <asp:Repeater ID="repeater2" runat="server" OnItemCommand="repeater2_ItemCommand">
                                <HeaderTemplate>
                                    <thead>
                                        <tr class="gridheadformat">
                                            <th>Category Name</th>
                                            <th>Edit</th>
                                            <th>Delete</th>


                                        </tr>
                                    </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr class="row-hightlight">
                                        <td><%# DataBinder.Eval(Container.DataItem, "CategoryName")%>
                                            <br />
                                        </td>
                                        <td>
                                             <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"categoryId") %>' onclientclick="return confirm('Do you want to Edit this record?');">Edit</asp:LinkButton></td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"categoryId") %>' onclientclick="return confirm('Do you want to Delete this record?');">Delete</asp:LinkButton></td>

                                        <%-- <td><button onclick="DeleteResult(<%# DataBinder.Eval(Container.DataItem, "tblResultId")%>)" id="Delete<%# DataBinder.Eval(Container.DataItem, "tblResultId")%>">Delete</button></td>--%>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                            </div>

                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 side-bar side-bar-style-two pull-left">
                        <div class="wrapper">
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

    <script>

        localStorage.setItem('lastTab1', "liCategoryList");

        $(document).ready(function () {
            $('#example').DataTable();
        });
    </script>
</asp:Content>

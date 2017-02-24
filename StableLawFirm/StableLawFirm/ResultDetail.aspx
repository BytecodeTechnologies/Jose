<%@ Page Title="" Language="C#" MasterPageFile="~/Stable.Master" AutoEventWireup="true" CodeBehind="ResultDetail.aspx.cs" Inherits="StableLawFirm.ResultDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="blog-page-two blog-single-page">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 pull-right blog-page-main-content" style="margin-top: -13%;">
                    <div class="single-news-postTwo">
                       <%-- <div class="img-container">
                            <img src="images/home/9.jpg" width="700" alt="image">
                        </div>--%>
                         <asp:Repeater ID="Repeater1" runat="server">
                             <ItemTemplate>
                        <div class="post">
                           
                            <div class="date p-color-bg"><b> <%# DataBinder.Eval(Container.DataItem, "day")%> </b><span> <%# DataBinder.Eval(Container.DataItem, "Month")%> </span></div>

                            
                            <a href="#">
                                <h3> <%# DataBinder.Eval(Container.DataItem, "Result_Heading")%> </h3>
                            </a>
                            <ul class="post-author">
                                <li><i class="fa fa-clock-o" aria-hidden="true"></i>Posting by <%# DataBinder.Eval(Container.DataItem, "Name")%> </li>
                               <%-- <li><i class="fa fa-tag" aria-hidden="true"></i>Attorney Law</li>--%>
                            </ul>
                            <p style="white-space: pre-wrap;">
                             <%# DataBinder.Eval(Container.DataItem, "Result_Text")%> 
                            </p>
                        </div>
                                 </ItemTemplate>
                             </asp:Repeater>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 side-bar side-bar-style-two pull-left">
                        <div class="wrapper">
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

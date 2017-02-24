<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="StableLawFirm.Blog" %>

<!DOCTYPE html>
<html lang="en">

<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <link rel="icon" type="image/png" sizes="32x32" href="images/fav-icon/icon.png">


    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="css/responsive.css">

    <title>Blog about Stabile Law Firm New Jersey</title>
    <meta name="description" content="Find the blogs about Stabile Law Firm New Jersey. Here we explain the traffic tickets related issues in details" />
</head>
<body>

    <div class="main-page-wrapper">

        <div class="style-two">
            <header>
                <div class="main-menu clear-fix container">
                    <a href="/" class="logo pull-left">
                        <img src="images/logo/logo.png" alt="stabile law firm logo"></a>
                    <form action="#" class="pull-right">
                        <input type="text" placeholder="Search">
                        <button class="p-color-bg tran3s" style="background: #16C3D1;"><i class="fa fa-search" aria-hidden="true"></i></button>
                    </form>
                    <nav class="navbar navbar-default pull-right">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse-1" aria-expanded="false">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                        </div>
                        <div class="collapse navbar-collapse" id="navbar-collapse-1">
                            <ul class="nav navbar-nav">
                                <li id="lihome"><a href="/">Home</a>
                                </li>
                                <li id="liaboutus"><a href="about-us.aspx">About Us</a></li>
                                <li id="liwhyus"><a href="why-us.aspx">WhyUs</a>
                                </li>
                                <li id="lilegalservices"><a href="legal-services.aspx">Legal Services</a>
                                </li>
                                <li id="liofficelocations"><a href="office-locations.aspx">Office Locations</a>
                                </li>
                                <li id="licontact"><a href="contact.aspx">Contact us</a></li>
                                  <li><a href="Blog.aspx" class="active-menu">Blog</a></li>
                            </ul>
                        </div>
                    </nav>
                </div>
            </header>

        </div>

        <div class="inner-banner">
            <div class="overlay">
            </div>
        </div>

        <form id="form2" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <div class="practice-area-single-page">
                            <div class="container">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 side-bar side-bar-style-two pull-left">

                                        <div class="wrapper">

                                            <div class="blog-categories">
                                                <h3>Blog Categories</h3>

                                                <ul>
                                                    <asp:Repeater ID="RepeaterCategories" runat="server" OnItemCommand="RepeaterCategories_ItemCommand">
                                                        <ItemTemplate>
                                                            <li>
                                                                <asp:LinkButton ID="LinkButton2" CssClass-="tran3s" runat="server" CommandName="GetCategoriesById" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"categoryId") %>'><i class="fa fa-long-arrow-right" aria-hidden="true"></i><%# DataBinder.Eval(Container.DataItem, "CategoryName")%></asp:LinkButton></li>
                                                            <%-- <li><a href="" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Crime Law</a></li>--%>
                                                            <%-- <li><a href="" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Professional Lawyers</a></li>
                                            <li><a href="" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Legal Consultation</a></li>
                                            <li><a href="" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Mederd Law</a></li>
                                            <li><a href="" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Accident Low</a></li>
                                            <li><a href="" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Personal Crime</a></li>
                                            <li><a href="" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Trusted Law Agency</a></li>--%>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>



                                            <div class="blog-categories">
                                                <h3>Special Links</h3>

                                                <ul class="side-barList">
                                                    <li id="liTrafficTicket"><a href="Traffic-Ticket.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Traffic Tickets</a></li>
                                                    <li id="liSpeedingTickets"><a href="Speeding-Tickets.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Speeding Tickets</a></li>
                                                    <li id="liNoCarInsurance"><a href="No-car-Insurance.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>No Car Insurance</a></li>
                                                    <li id="liRecklessdriving"><a href="Reckless-Driving.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Reckless Driving</a></li>
                                                    <li id="liCarelessDriving"><a href="Careless-Driving.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Careless Driving</a></li>
                                                    <li id="liSuspendedLicense"><a href="Suspended-License.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Suspended License</a></li>
                                                    <li id="liDUIDWI"><a href="Dui-Dwi-Defense-Lawyers.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>DUI & DWI</a></li>
                                                    <li id="liBeatTrafficTicket"><a href="lawyer-beat-your-traffic-ticket.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Can a lawyer beat your traffic ticket?</a></li>
                                                    <li id="liPointsSurcharges"><a href="Points-and-Surcharges.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Points and Surcharges</a></li>
                                                    <li id="liwhatToDoSuspended"><a href="what-to-do-when-your-license-suspended.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>What to do when your license is Suspended</a></li>
                                                    <li id="liRestoringLicense"><a href="Restoring-your-license.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Restoring your license</a></li>
                                                    <li id="liPenalitiesFines"><a href="Penalties-and-fines.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Penalties and fines</a></li>
                                                    <li id="liStoppedfortrafficViolation"><a href="What-to-do-when-stoped-by-police.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>What to Do When Stopped for a Traffic Violation</a></li>
                                                    <li id="liCourtimposed"><a href="court-imposed-penalties-for-Dui.aspx" class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i>Court Imposed Penalties for DUI</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="blog-page-two">
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 pull-right blog-page-main-content">
                                                    <asp:Repeater ID="BlogRepeater" runat="server">
                                                        <ItemTemplate>
                                                            <div class="single-news-postTwo">
                                                                <div class="img-container" style="margin-top: -14%">
                                                                    <img src="<%# DataBinder.Eval(Container.DataItem, "Image")%>" alt="image">
                                                                    <div class="overlay tran3s"><a onclick="Showblog(<%# DataBinder.Eval(Container.DataItem, "tblBlog_Id")%>)"><span><i class="fa fa-chain-broken" aria-hidden="true"></i></span></a></div>
                                                                </div>

                                                                <div class="post">
                                                                    <div class="date p-color-bg"><b><%# DataBinder.Eval(Container.DataItem, "Day")%></b><span><%# DataBinder.Eval(Container.DataItem, "Month")%></span></div>
                                                                    <a href="blog-single.html">
                                                                        <h3><%# DataBinder.Eval(Container.DataItem, "Title")%></h3>
                                                                    </a>
                                                                    <ul class="post-author">
                                                                        <li><i class="fa fa-clock-o" aria-hidden="true"></i>Posting by <%# DataBinder.Eval(Container.DataItem, "UserName")%></li>
                                                                        <li><i class="fa fa-tag" aria-hidden="true"></i><%# DataBinder.Eval(Container.DataItem, "CategoryName")%></li>
                                                                    </ul>
                                                                    <p><%# DataBinder.Eval(Container.DataItem, "Text")%></p>
                                                                    <a onclick="Showblog(<%# DataBinder.Eval(Container.DataItem, "tblBlog_Id")%>)" class="p-color-bg tran3s hvr-bounce-to-rightTwo continue-reading">Continue Reading <i class="fa fa-long-arrow-right" aria-hidden="true"></i></a>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                   <h1> <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="false"></asp:Label></h1>
                                                    <asp:Button ID="btnMessage" runat="server" Text="Button" Visible="false" />
                                                </div>
                                            </div>
                                        </div>
                                        <ul class="page-pagination">
                                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                                <ItemTemplate>
                                                    <li>
                                                        <asp:LinkButton ID="LinkButton1" CssClass='<%# Convert.ToBoolean(Eval("pageactive")) ? "active" : "" %>' CommandName="Paging" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageIndex")%>' runat="server"><%# DataBinder.Eval(Container.DataItem, "PageName")%></asp:LinkButton></li>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <asp:HiddenField ID="SearchPaging" runat="server" />
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>

        <div class="bottom-banner p-color-bg mFix">
            <div class="container">
                <div class="row">
                    <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12">
                        <p>Need emergency help for Ticket? We are waiting for your Request </p>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"><a href="contact.aspx" class="theme-button">QUICK REQUEST</a></div>
                </div>
            </div>
        </div>

        <footer>
            <div class="top-footer">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 footer-contact">
                            <h4>CONTACT US</h4>

                            <ul>
                                <li><i class="fa fa-map-marker" aria-hidden="true"></i>Main Office:<br />
                                    900 Route 9 North,<br />
                                    suite 214,
                                    <br />
                                    Woodbridge, NJ 07095</li>

                                <li><i class="fa fa-envelope-o" aria-hidden="true"></i>request@stabilelawfirm.com </li>
                                <li><i class="fa fa-phone" aria-hidden="true"></i>1-732-602-7795</li>
                                <li><i class="fa fa-clock-o" aria-hidden="true"></i>Mon - Sat 9.00 AM - 07.00 PM</li>
                            </ul>
                        </div>
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 footer-easy-link">
                            <h4>EASY LINKS</h4>
                            <ul class="pull-left">
                                <li><a href="/">Home</a></li>
                                <li><a href="about-us.aspx">About Us</a></li>
                                <li><a href="why-us.aspx">Why Us</a></li>
                                <li><a href="legal-services.aspx">Legal Services</a></li>
                                <li><a href="office-locations.aspx">Office Locations</a></li>
                                <li><a href="contact.aspx">Contact Us</a></li>
                            </ul>


                        </div>


                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 footer-latest-news">
                            <h4>LATEST Results</h4>

                            <ul>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a href="#" onclick="ResultCall(<%# DataBinder.Eval(Container.DataItem, "tblResultId")%>)" class="tran3s"><%# DataBinder.Eval(Container.DataItem, "Result_Heading")%>
                                                <span><i class="fa fa-clock-o" aria-hidden="true"></i><%# DataBinder.Eval(Container.DataItem, "Day")%> <%# DataBinder.Eval(Container.DataItem, "Month")%>,<%# DataBinder.Eval(Container.DataItem, "Year")%>   By  <%# DataBinder.Eval(Container.DataItem, "Name")%></span>
                                            </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>

                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 footer-mail">
                            <h4>SEND MAIL</h4>


                            <input class="txtsendmail required" id="txtfullname" type="text" placeholder="Full Name" />

                            <input class="txtsendmail " id="txtphone" type="text" placeholder="Phone" />
                            <input class="txtsendmail required" id="txtEmail" type="email" placeholder="Email" />
                            <textarea class="txtsendmail" id="txtcomment" placeholder="Comment"></textarea>
                            <div class="g-recaptcha" style="margin-top: 10px"
                                data-sitekey="[6LdIqSkTAAAAAExQ_ie-6jqs125QCax6DpsrxKiv]">
                            </div>
                            <a href="#btnSendEmail" id="btnSendEmail" class="theme-button1 hvr-bounce-to-right">Send</a>

                            <ul style="margin-top: 20px;">
                                <li><a href="https://twitter.com/traffic_ticket_" class="hvr-rectangle-out tran3s"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                                <li><a href="https://www.facebook.com/stabilelawfirm/" class="hvr-rectangle-out tran3s"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                                <li><a href="https://plus.google.com/105631430374039779814/about?gmbpt=true&_ga=1.115186183.1858724218.1472044234" class="hvr-rectangle-out tran3s"><i class="fa fa-google-plus" aria-hidden="true"></i></a></li>
                                <li><a href="#" class="hvr-rectangle-out tran3s"><i class="fa fa-linkedin" aria-hidden="true"></i></a></li>
                                <li><a href="#" class="hvr-rectangle-out tran3s"><i class="fa fa-skype" aria-hidden="true"></i></a></li>
 <li><iframe src="https://www.facebook.com/plugins/like.php?href=https%3A%2F%2Fwww.facebook.com%2Fstabilelawfirm%2F&width=300&layout=button&action=like&size=small&show_faces=true&share=false&height=80&appId" width="50" height="20" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowtransparency="true"></iframe></li>
                            </ul>

                        </div>
                    </div>
                </div>
            </div>

            <%--<div class="bottom-footer"><p>Copyright 2016 &copy; <a href="http://themeforest.net/user/themazine/portfolio" class="p-color tran3s" target="_blank">TheMazine</a> | Designed with love by <a href="http://themeforest.net/user/template_mr/portfolio" class="p-color tran3s" target="_blank">template_mr</a></p></div>--%>
        </footer>


        <!-- Scroll Top -->
        <button class="scroll-top tran3s p-color-bg">
            <i class="fa fa-angle-up" aria-hidden="true"></i>
        </button>

        <!-- pre loader  -->
        <div id="loader-wrapper">
            <div id="loader"></div>
        </div>







        <!-- Js File_________________________________ -->

        <!-- j Query -->
        <script type="text/javascript" src="assest/jquery-2.1.4.js"></script>

        <!-- Bootstrap JS -->
        <script type="text/javascript" src="assest/bootstrap/bootstrap.min.js"></script>

        <!-- Vendor js _________ -->

        <!-- Google map js -->
        <%--<script src="http://maps.google.com/maps/api/js"></script>--%>
        <!-- Gmap Helper -->
        <script src="assest/gmap.js"></script>
        <!-- Vegas Slider -->
        <script type="text/javascript" src="assest/vegas/vegas.min.js"></script>
        <!-- owl.carousel -->
        <script type="text/javascript" src="assest/owl-carousel/owl.carousel.min.js"></script>

        <script type="text/javascript" src='https://www.google.com/recaptcha/api.js'></script>

        <script type="text/javascript" src="js/theme.js"></script>
        <!-- Theme js -->



    </div>
    <!-- /.main-page-wrapper -->
</body>

<!-- Mirrored from themazine.com/html/legal/LEGAL-STATION/about-us.html by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 30 Aug 2016 07:59:27 GMT -->
</html>


<script>
    $(function () {

        //------------------------- for active tab ------------------
        //var selector = '.nav li';
        //$(selector).removeClass('active-menu');
        //var idd = localStorage.getItem('lastTab');
        //$("#" + idd).addClass('active-menu');
        //localStorage.setItem('lastTab', "");

        //------------------------ for active side bar ------------------- side-barList

        var selector = '.side-barList li';
        $(selector).removeClass('active-menu1');
        var idd = localStorage.getItem('lastTab1');
        $("#" + idd).addClass('active-menu1');
        localStorage.setItem('lastTab1', "");
    });



    $("#btnSendEmail").click(function (evt) {
        debugger;
        var fullname = $("#txtfullname").val();
        var Phone = $("#txtphone").val();
        var Email = $("#txtEmail").val();
        var Comment = $("#txtcomment").val();
        var Recapcha = captcharesponse = grecaptcha.getResponse();

        if (fullname == "" || Email == "") {
            alert("All highlighted Fields are required")
            return;
        }

        if (Recapcha == "") {
            alert("Please Verify Capcha")
            return;
        }

        if (!ValidateEmail(Email)) {
            alert('Not a valid email');
            return;
        }


        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/index.aspx/SendEmail",
            data: JSON.stringify({ Name: fullname, Phone: Phone, Email: Email, Comment: Comment, Recapcha: Recapcha }),
            dataType: "Json",
            success: function (response) {
                alert(response);
            },
            error: function (response) {
                alert(response);
            }
        });



    });

    function ValidateEmail(email) {
        // Validate email format
        var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        return expr.test(email);
    };

    $("#txtphone").keypress(function (e) {

        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            return false;
        }
    });

    function ResultCall(id) {

        window.location.href = "ResultDetail.aspx?id=" + id;
    };

    function Showblog(id) {
        window.location.href = "ShowBlog.aspx?id=" + id;


    };





</script>


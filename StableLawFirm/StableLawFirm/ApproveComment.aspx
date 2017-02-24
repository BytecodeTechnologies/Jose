<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApproveComment.aspx.cs" Inherits="StableLawFirm.ApproveComment" %>

<head id="Head1" runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <link rel="icon" type="image/png" sizes="32x32" href="images/fav-icon/icon.png">


    <link rel="stylesheet" type="text/css" href="css/style.css">
    <link rel="stylesheet" type="text/css" href="css/responsive.css">
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
        <form id="Form1" runat="server">
            <asp:HiddenField ID="hdnBlogId" runat="server" />
        </form>
        <!-- Blog Page v2 ______________________ -->
        <div class="blog-page-two blog-single-page">
            <div class="container">
                <div class="row">
                    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 pull-left blog-page-main-content">
                        <div class="single-news-postTwo">
                            <div class="img-container">
                                <asp:Repeater runat="server" ID="ShowBlogs">
                                    <ItemTemplate>
                                        <img src="<%# DataBinder.Eval(Container.DataItem, "Image")%>" alt="image">
                                        </div>

								<div class="post">

                                    <div class="date p-color-bg"><b><%# DataBinder.Eval(Container.DataItem, "Day")%></b><span><%# DataBinder.Eval(Container.DataItem, "Month")%></span></div>
                                    <a href="#">
                                        <h3><%# DataBinder.Eval(Container.DataItem, "Title")%></h3>
                                    </a>
                                    <ul class="post-author">
                                        <li><i class="fa fa-clock-o" aria-hidden="true"></i>Posting by <%# DataBinder.Eval(Container.DataItem, "UserName")%></li>
                                        <li><i class="fa fa-tag" aria-hidden="true"></i><%# DataBinder.Eval(Container.DataItem, "CategoryName")%></li>
                                    </ul>
                                    <p style=""><%# DataBinder.Eval(Container.DataItem, "Text")%></p>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <div class="share-option clear-fix">
                                </div>

                                <div class="comment-area">
                                    <h6>Comment </h6>


                                    <asp:Repeater runat="server" ID="comments">
                                        <ItemTemplate>
                                            <div class="single-comment clear-fix">
                                                <div class="img-container pull-left">

                                                    <p><%# DataBinder.Eval(Container.DataItem, "CommentAddedBy")%> <i class="fa fa-long-arrow-right" aria-hidden="true"></i></p>
                                                </div>
                                                <div class="text pull-left">
                                                    <span><b>Post Date:</b><%# DataBinder.Eval(Container.DataItem, "Post_Date_st")%></span>&nbsp&nbsp
                                                <span><b>Email:</b><%# DataBinder.Eval(Container.DataItem, "CommentBy_Email")%></span>
                                                    <p style="white-space: pre-wrap;"><%# DataBinder.Eval(Container.DataItem, "commentText")%></p>

                                                </div>
                                                <a onclick="ApproveComment(<%# DataBinder.Eval(Container.DataItem, "comment_id")%>);" id="btnApprove" class="theme-button p-color-bg hvr-bounce-to-rightTwo">Approve</a>
                                                <a onclick="DeclineComment(<%# DataBinder.Eval(Container.DataItem, "comment_id")%>);" id="btnDecline" class="theme-button p-color-bg hvr-bounce-to-rightTwo">Decline</a>
                                            </div>
                                            <!-- /.single-comment -->
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- /.comment-area -->

                            </div>
                            <!-- /.post -->
                        </div>
                        <!-- /.single-news-postTwo -->
                    </div>
                    <!-- /.blog-page-main-content -->
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 side-bar side-bar-style-two pull-right">
                        <div class="wrapper-fix">

                            <form action="#" class="sidebar-search">
                                <input type="text" placeholder="Serach">
                                <button><i class="fa fa-search-minus" aria-hidden="true"></i></button>
                            </form>

                            <div class="blog-categories">
                                <h3>Blog Categories</h3>

                                <ul>
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <li><a class="tran3s"><i class="fa fa-long-arrow-right" aria-hidden="true"></i><%# DataBinder.Eval(Container.DataItem, "CategoryName")%></a></li>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <!-- /.blog-categories -->

                        </div>
                        <!-- /.wrapper -->
                    </div>
                    <!-- /.side-bar -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.blog-page -->









        <!-- Bottom Banner ________________ -->
        <div class="bottom-banner p-color-bg">
            <div class="container">
                <div class="row">
                    <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12">
                        <p>Need emergency help for Ticket? We are waiting for your Request </p>
                    </div>
                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"><a href="contact.aspx" class="theme-button">QUICK REQUEST</a></div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container -->
        </div>
        <!-- /.bottom-banner -->



        <!-- Footer _______________________ -->
        <footer>
            <div class="top-footer">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 footer-contact">
                            <h4>CONTACT US</h4>
                            <%--<p>It is a long established fact that a reader will be distracted by the readable content of a page when looking.</p>--%>

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
                        <!-- /.footer-contact -->

                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 footer-easy-link">
                            <h4>EASY LINKS</h4>
                            <ul class="pull-left">
                                <li><a href="/">Home</a></li>
                                <li><a href="about-us.aspx">About Us</a></li>
                                <li><a href="why-us.aspx">Why Us</a></li>
                                <li><a href="legal-services.aspx">Legal Services</a></li>
                                <li><a href="office-locations.aspx">Office Locations</a></li>
                                <li><a href="contact.aspx">Contact Us</a></li>
                                <%--  <li><a href="#">Results</a></li>--%>
                            </ul>


                        </div>


                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 footer-latest-news">
                            <h4>LATEST Results</h4>

                            <ul>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <a onclick="ResultCall(<%# DataBinder.Eval(Container.DataItem, "tblResultId")%>)" class="tran3s"><%# DataBinder.Eval(Container.DataItem, "Result_Heading")%>
                                                <span><i class="fa fa-clock-o" aria-hidden="true"></i><%# DataBinder.Eval(Container.DataItem, "Day")%> <%# DataBinder.Eval(Container.DataItem, "Month")%>,<%# DataBinder.Eval(Container.DataItem, "Year")%>   By  <%# DataBinder.Eval(Container.DataItem, "Name")%></span>
                                            </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <!-- /.footer-latest-news -->

                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12 footer-mail">
                            <h4>SEND MAIL</h4>
                            <%--	<p>Send us Email for latest update new offer and free Consulation, We are available</p>--%>


                            <input class="txtsendmail required" id="txtfullname" type="text" placeholder="Full Name" />

                            <input class="txtsendmail" id="txtphone" type="text" placeholder="Phone" />
                            <input class="txtsendmail required" id="txtEmail" type="email" placeholder="Email" />
                            <textarea class="txtsendmail" id="txtcomment" placeholder="Comment"></textarea>
                            <div class="g-recaptcha" style="margin-top: 10px"
                                data-sitekey="[6LdIqSkTAAAAAExQ_ie-6jqs125QCax6DpsrxKiv]">
                            </div>
                            <%--<input type="button" class="theme-button btnsendemail" value="send"/>--%>
                            <a href="#btnSendEmail" id="btnSendEmail" class="theme-button1 hvr-bounce-to-right">Send</a>
                            <%-- <button id="btnSendEmail" class="tran3s p-color-bg hvr-bounce-to-rightTwo">SEND EMAIL</button>--%>



                            <%--<button class="p-color-bg tran3s">Send<i class="fa fa-location-arrow" aria-hidden="true"></i></button>--%>


                            <ul style="margin-top: 20px;">
                                <li><a href="#" class="hvr-rectangle-out tran3s"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                                <li><a href="#" class="hvr-rectangle-out tran3s"><i class="fa fa-facebook" aria-hidden="true"></i></a></li>
                                <li><a href="#" class="hvr-rectangle-out tran3s"><i class="fa fa-google-plus" aria-hidden="true"></i></a></li>
                                <li><a href="#" class="hvr-rectangle-out tran3s"><i class="fa fa-linkedin" aria-hidden="true"></i></a></li>
                                <li><a href="#" class="hvr-rectangle-out tran3s"><i class="fa fa-skype" aria-hidden="true"></i></a></li>
                            </ul>

                        </div>
                        <!-- /.footer-mail -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.container -->
            </div>
            <!-- /.top-footer -->

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
        <%--   <script src="http://maps.google.com/maps/api/js"></script>--%>
        <!-- Gmap Helper -->
        <script src="assest/gmap.js"></script>
        <!-- Vegas Slider -->
        <script type="text/javascript" src="assest/vegas/vegas.min.js"></script>
        <!-- owl.carousel -->
        <script type="text/javascript" src="assest/owl-carousel/owl.carousel.min.js"></script>

        <!-- Theme js -->
        <script type="text/javascript" src="js/theme.js"></script>


        <script type="text/javascript" src='https://www.google.com/recaptcha/api.js'></script>


    </div>
    <!-- /.main-page-wrapper -->
</body>

<!-- Mirrored from themazine.com/html/legal/LEGAL-STATION/ by HTTrack Website Copier/3.x [XR&CO'2014], Tue, 30 Aug 2016 07:58:58 GMT -->
</html>

<script>
    $(function () {
      $("#btnApprove").parent().next(".validation").remove();
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


    function myCallBack() {
        var recaptcha1;
        var recaptcha2;
        recaptcha1 = grecaptcha.render('recaptcha1', {
            'sitekey': '6LdIqSkTAAAAAExQ_ie-6jqs125QCax6DpsrxKiv', //Replace this with your Site key
            'theme': 'light'
        });

        recaptcha2 = grecaptcha.render('recaptcha2', {
            'sitekey': '6LdIqSkTAAAAAExQ_ie-6jqs125QCax6DpsrxKiv', //Replace this with your Site key
            'theme': 'light'
        });
    };

    function ResultCall(id) {

        window.location.href = "ResultDetail.aspx?id=" + id;
    };

    function ApproveComment(id) {
        alert(id);
        debugger;
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Approvecomment.aspx/ApproveComments",
            data: JSON.stringify({ id: id }),
            dataType: "Json",
            success: function (response) {
                $("#btnApprove").parent().after("<div id='showmessage' class='validation' style='color:red;margin-bottom: 20px;'>" + response.d + "</div>");
            },
            error: function (response) {
                alert(response);
            }
        });
    };

    function DeclineComment(id) {
        alert(id);
        debugger;
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Approvecomment.aspx/DeclineComment",
            data: JSON.stringify({ id: id }),
            dataType: "Json",
            success: function (response) {
                $("#btnApprove").parent().after("<div id='showmessage' class='validation' style='color:red;margin-bottom: 20px;'>" + response.d + "</div>");
            },
            error: function (response) {
                alert(response);
            }
        });
    };

</script>

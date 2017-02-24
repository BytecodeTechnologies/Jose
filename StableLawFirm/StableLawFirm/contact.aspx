<%@ Page Title="" Language="C#" MasterPageFile="~/Contact.master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="StableLawFirm.contact" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <title>Contact us at Stabile Law Firm New Jersey</title>
    <meta name="description" content="Contact us at Stabile Law Firm New Jersey for any kind of legal services related to traffic tickets. We are always ready to help you with our best services" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact-us-area">
        <div class="container">
            <div class="row">
                <div class="col-lg-7 col-md-8 col-sm-12 col-xs-12 contact-us-form contactform" style="margin-top: 15px">
                    <h1 style="display: none">CONTACT-US</h1>
                    <h6>SEND A MESSAGE</h6>
                    <div class="col-md-8 col-lg-7 col-sm-12 col-xs-12">
                        <div class="row">
                            <div class="col-lg-6 col-md-4 col-sm-6 col-xs-12">
                                <input type="text" id="txtfullname" placeholder="Name" name="name" class="required">
                            </div>
                            <div class="col-lg-6 col-md-4 col-sm-6 col-xs-12">
                                <input type="email" id="txtEmail" placeholder="Email" name="email" class="required">
                            </div>
                            <div class="col-lg-12 col-md-4 col-sm-12 col-xs-12">
                                <input type="text" id="txtphone" placeholder="Phone" name="phone">
                            </div>
                            <div class="col-lg-12 col-md-4 col-sm-12 col-xs-12">
                                <textarea placeholder="Message" id="txtcomment" name="message"></textarea>


                                <div class="col-lg-12 col-md-4 col-sm-12 col-xs-12">
                                    <div class="g-recaptcha" style="margin-top: 10px"
                                        data-sitekey="[6LdIqSkTAAAAAExQ_ie-6jqs125QCax6DpsrxKiv]">
                                    </div>
                                    <div id="recaptcha1"></div>

                                </div>
                            </div>
                        </div>

                        <%-- <button id="btnSendEmail" class="tran3s p-color-bg hvr-bounce-to-rightTwo">SEND EMAIL</button>--%>
                        <a id="btnSendEmails" class="theme-button1 hvr-bounce-to-right tran3s p-color-bg hvr-bounce-to-rightTwo">Send Email</a>
                    </div>

                    <div class="col-md-3">

                        <div class="alert_wrapper" id="alert_success">
                            <div id="success">
                                <button class="closeAlert"><i class="fa fa-times" aria-hidden="true"></i></button>
                                <div class="wrapper">
                                    <p>Your message was sent successfully!</p>
                                </div>
                            </div>
                        </div>
                        <!-- End of .alert_wrapper -->
                        <div class="alert_wrapper" id="alert_error">
                            <div id="error">
                                <button class="closeAlert"><i class="fa fa-times" aria-hidden="true"></i></button>
                                <div class="wrapper">
                                    <p>Something went wrong, try refreshing and submitting the form again.</p>
                                </div>
                            </div>
                        </div>
                        <!-- End of .alert_wrapper -->
                    </div>
                    <!-- /.contact-us-form -->

                    <div class="contact-address col-lg-5 col-md-5 col-sm-12 col-xs-12">
                        <div class="wrapper">
                            <h6>CONTACT INFO</h6>

                            <ul class="address" style="margin-top: 10px">
                                <li><i class="fa fa-map-marker" aria-hidden="true"></i>Main Office:<br />
                                    suite 214,<br />
                                    Woodbridge, NJ 07095 </li>
                                <li><i class="fa fa-envelope-o" aria-hidden="true"></i>request@stabilelawfirm.com</li>
                                <li><i class="fa fa-phone" aria-hidden="true"></i>1-732-602-7795</li>
                                <li><i class="fa fa-clock-o" aria-hidden="true"></i>Mon - Sat 9.00 AM - 07.00 PM</li>
                            </ul>

                        </div>
                        <!-- /.wrapper -->
                    </div>
                    <!-- /.contact-address -->
                </div>
            </div>
        </div>
        <!-- /.contact-us-area -->
    </div>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="https://www.google.com/recaptcha/api.js?onload=myCallBack&render=explicit" async defer></script>

    <script>

        $(function () {

            //myCallBack();

        });


        localStorage.setItem('lastTab', "licontact");


        $("#btnSendEmails").click(function (evt) {

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

            $("#txtEmail").val('');
            $("#txtfullname").val('');
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/index.aspx/SendEmail",
                data: JSON.stringify({ Name: fullname, Phone: Phone, Email: Email, Comment: Comment, Recapcha: Recapcha }),
                dataType: "Json",
                success: function (response) {
                    $("#txtEmail").val('');
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
            //var recaptcha2;
            recaptcha1 = grecaptcha.render('recaptcha1', {
                'sitekey': '6LdIqSkTAAAAAExQ_ie-6jqs125QCax6DpsrxKiv', //Replace this with your Site key
                'theme': 'light'
            });

            recaptcha2 = grecaptcha.render('recaptcha2', {
                'sitekey': '6LdIqSkTAAAAAExQ_ie-6jqs125QCax6DpsrxKiv', //Replace this with your Site key
                'theme': 'light'
            });
        };
    </script>









</asp:Content>

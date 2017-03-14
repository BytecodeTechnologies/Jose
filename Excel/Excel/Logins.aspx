<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logins.aspx.cs" Inherits="Excel.Logins" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <link href="/assets/css/icons/icomoon/styles.css" rel="stylesheet" type="text/css">
    <link href="/assets/css/bootstrap.css" rel="stylesheet" type="text/css">
    <link href="/assets/css/core.css" rel="stylesheet" type="text/css">
    <link href="/assets/css/components.css" rel="stylesheet" type="text/css">
    <link href="/assets/css/colors.css" rel="stylesheet" type="text/css">
    <!-- /global stylesheets -->
    <!-- Core JS files -->
    <script type="text/javascript" src="/assets/js/plugins/loaders/pace.min.js"></script>
    <script type="text/javascript" src="/assets/js/core/libraries/jquery.min.js"></script>
    <script type="text/javascript" src="/assets/js/core/libraries/bootstrap.min.js"></script>
    <script type="text/javascript" src="/assets/js/plugins/loaders/blockui.min.js"></script>
    <!-- /core JS files -->
    <!-- Theme JS files -->
    <script type="text/javascript" src="/assets/js/plugins/forms/styling/uniform.min.js"></script>
    <script type="text/javascript" src="/assets/js/core/app.js"></script>

</head>
<body class="login-container bg-slate-800">
    <form id="Form1" runat="server">
        <asp:HiddenField ID="hdnUserNameField" runat="server" />
        <asp:HiddenField ID="hdnPasswordField" runat="server" />
    </form>
    <div class="page-container">
        <div class="page-content">
            <div class="content-wrapper">
                <div class="content">
                    <div class="panel panel-body login-form">
                        <div class="text-center">
                            <div class="icon-object border-warning-400 text-warning-400"><i class="icon-people"></i></div>
                            <h5 class="content-group-lg">Login to your account <small class="display-block">Enter your credentials</small></h5>
                        </div>
                        <div class="form-group has-feedback has-feedback-left">
                            <input type="text" class="form-control" placeholder="Email" id="txtUserName">
                            <div class="form-control-feedback">
                                <i class="icon-user text-muted"></i>
                            </div>
                        </div>
                        <div class="form-group has-feedback has-feedback-left">
                            <input type="password" class="form-control" placeholder="Password" id="txtPassword">
                            <div class="form-control-feedback">
                                <i class="icon-lock2 text-muted"></i>
                            </div>
                        </div>
                        <div class="form-group login-options">
                            <div class="row">
                                <div class="col-sm-6">
                                    <label class="checkbox-inline">
                                        <input type="checkbox" id="chkRemember" class="styled" checked="checked">
                                        Remember
                                    </label>
                                </div>
                                <%--<div class="col-sm-6 text-right">
                                    <a href="#">Forgot password?</a>
                                </div>--%>
                            </div>
                        </div>
                        <div class="form-group">
                            <button type="submit" class="btn bg-blue btn-block" id="btnLogin">Login <i class="icon-circle-right2 position-right"></i></button>
                        </div>

                        <span class="help-block text-center no-margin">By continuing, you're confirming that you've read our <a href="#">Terms &amp; Conditions</a> and <a href="#">Cookie Policy</a></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</html>

<script src="Scripts/jquery-1.7.1.min.js"></script>
<script src="Scripts/jquery-1.7.1.js"></script>

<script>
    var RUserName = $('#<%= hdnUserNameField.ClientID %>').val().trim();
    var RPassword = $('#<%= hdnPasswordField.ClientID %>').val().trim();
    $(document).ready(function () {
        if (RUserName != null && RPassword != null) {
            $("#txtUserName").val(RUserName);
            $("#txtPassword").val(RPassword);
        }
    });

    $('#btnLogin').click(function () {
        $("#btnLogin").parent().next(".validation").remove();
        if (!$("#txtUserName").val().trim()) {
            if ($("#txtUserName").parent().next(".validation").length == 0) // only add if not added
            {
                $("#txtUserName").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Enter UserName</div>");
            }
            $("#txtUserName").focus();
            focusSet = true;
        }
        else {
            $("#txtUserName").parent().next(".validation").remove(); // remove it
        }
        if (!$("#txtPassword").val().trim()) {
            if ($("#txtPassword").parent().next(".validation").length == 0) // only add if not added
            {
                $("#txtPassword").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Password</div>");
            }

        }
        else {
            $("#txtPassword").parent().next(".validation").remove(); // remove it
        }
        var UserName = $("#txtUserName").val();
        var Password = $("#txtPassword").val();

        if (UserName == "" || Password == "") {
            return
        }
        var RememberMe = $("#chkRemember").is(":checked") ? "true" : "false";
        $.ajax({

            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "/Logins.aspx/LoginUser",
            data: JSON.stringify({ UserName: UserName, Password: Password, RememberMe: RememberMe }),
            dataType: "Json",
            success: function (response) {

                if (response.d == "1") {
                    window.location.href = "Clients.aspx";
                }
                else if (response.d == "2") {
                    window.location.href = "Clients.aspx";
                }
                else {
                    $("#btnLogin").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please check username or password</div>");
                }
            },
            error: function (response) {
            }
        });
    });
    $(".form-control").keypress(function (e) {
        if (e.which == 13) {
            $("#btnLogin").click();
            e.preventDefault();
        }
    });
</script>


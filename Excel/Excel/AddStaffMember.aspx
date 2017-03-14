<%@ Page Title="" Language="C#" MasterPageFile="~/NJ_ClientAdmin.Master" AutoEventWireup="true" CodeBehind="AddStaffMember.aspx.cs" Inherits="Excel.AddStaffMember" %>

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
                            Add Staff
                        </div>
                    </div>
                    <div class="panel-body gridtopMargin" style="margin-left: 350px">
                        <div class="col-md-12">
                            <asp:HiddenField ID="Userid" runat="server"></asp:HiddenField>
                             <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                            
                            <div class="form-group">

                                <div class="col-md-2">
                                    <input type="hidden" id="hdnId"/>
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
                                        <label>Email:</label>
                                    </div>
                                    <div class="col-md-3">
                                        <input id="txtEmail" class="form-control" type="text" placeholder="Email" />
                                        <div class="col-md-6"></div>
                                    </div>


                                    <div class="ClientDetailEditTextPadding">
                                        <div class="col-md-2">
                                            <label>Password:</label>
                                        </div>
                                        <div class="col-md-3">
                                            <input id="txtPassword" class="form-control" type="password" placeholder="Password" />
                                            <div class="col-md-6"></div>
                                        </div>

                                        <div class="ClientDetailEditTextPadding">
                                            <div class="col-md-2">
                                                <label>Confirm Password::</label>
                                            </div>
                                            <div class="col-md-3">
                                                <input id="txtConfirmPassword" class="form-control" type="password" placeholder="Confirm Password" />
                                                <div class="col-md-6"></div>
                                            </div>

                                            <div class="ClientDetailEditTextPadding">
                                                <div class="col-md-2">
                                                    <label>Role:</label>
                                                </div>
                                                <div class="col-md-3">
                                                    <select id="ddlRole" class="user-field-txt form-control">
                                                        <option value="0">Select</option>
                                                        <option value="1">Admin</option>
                                                        <option value="2">Staff</option>
                                                    </select>
                                                    <div class="col-md-6"></div>
                                                </div>
                                            </div>
                                            <div class="ClientDetailEditTextPadding">
                                                <div class="col-md-3">
                                                </div>
                                                <div class="col-md-2">
                                                    <input type='button' id="btnAddStaff" class='btn btn-primary btn-mark' value='Save' />
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
    </div>

    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery-1.7.1.js"></script>

    <script>

        $(document).ready(function () {

            var Id = $('#<%=Userid.ClientID %>').val();
            if (Id != null && Id != "") {
                EditEmployee(Id);
            }

            $('.loadercont').fadeOut();
        });

        function EditEmployee(id) {
          
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/AddStaffMember.aspx/EditEmployee",
                data: JSON.stringify({ id: id }),
                dataType: "Json",
                success: function (response) {
                    //$('#hdnId').val(response.d.tblUserId);
                    $('#<%=HiddenField1.ClientID %>').val(response.d.tblUserId);
                    $('#txtFirstName').val(response.d.First_Name);
                    $('#txtLastName').val(response.d.Last_Name);
                    $('#txtEmail').val(response.d.Email);
                    $('#txtPassword').val(response.d.Password);
                    $('#txtConfirmPassword').val(response.d.Password);
                    $('#ddlRole').val(response.d.tbl_RoleId);

                    $('.loadercont').fadeOut();

                },
                error: function (response) {
                   
                    $('.loadercont').fadeOut();

                }
            });

        }

        $('#btnAddStaff').click(function () {
            debugger;
            var tblUserId = "";
            //var tblUserId1 = "";
            if ($('#<%=HiddenField1.ClientID %>').val() != null && $('#<%=HiddenField1.ClientID %>').val() != "") {
                tblUserId = $('#<%=HiddenField1.ClientID %>').val();
            }
            
            var FirstName = $('#txtFirstName').val();
            var LastName = $('#txtLastName').val();
            var Email = $('#txtEmail').val();
            var Password = $('#txtPassword').val();
            var ConfirmPassword = $('#txtConfirmPassword').val();
            var Role = $('#ddlRole').val();
            validateform();
            if (FirstName == "" || LastName == "" || Email == "" || Password == "" || ConfirmPassword == "" || Role == 0) {
                return;
            }
            if (!ValidateEmail(Email)) {
                $('.loadercont').fadeOut();
                $("#txtEmail").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Type Correct Email</div>");
                return;
            }
            else {
                $("#txtEmail").parent().next(".validation").remove(); // remove it
            }

            if (Password != ConfirmPassword) {
                $("#txtConfirmPassword").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Password and Confirm Password should be same</div>");
                return;
            }
            else {
                $("#txtConfirmPassword").parent().next(".validation").remove(); // remove it
            }

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "/AddStaffMember.aspx/AddnewStaff",
                data: JSON.stringify({
                    FirstName: FirstName, LastName: LastName, Email: Email, Password: Password, Role: Role, Id: tblUserId
                }),
                dataType: "Json",
                success: function (response) {
                    if (response.d == "1") {
                        bootbox.alert({
                            message: "Staff member Added Successfully",
                            callback: function () {
                                window.location.href = "Employee.aspx"
                                $('.loadercont').fadeOut();
                            }
                        });
                    }
                    else {
                        bootbox.alert("Email Already Exist");
                    }
                },
                error: function (response) {
                    $('.loadercont').fadeOut();
                }
            });


        });

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


            if (!$("#txtEmail").val().trim()) {
                if ($("#txtEmail").parent().next(".validation").length == 0) // only add if not added
                {
                    $("#txtEmail").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter Email</div>");
                }

            }
            else {
                $("#txtEmail").parent().next(".validation").remove(); // remove it
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

            if (!$("#txtConfirmPassword").val().trim()) {
                if ($("#txtConfirmPassword").parent().next(".validation").length == 0) // only add if not added
                {
                    $("#txtConfirmPassword").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please enter confirm Password</div>");
                }

            }
            else {
                $("#txtConfirmPassword").parent().next(".validation").remove(); // remove it
            }
            if ($("#ddlRole").val() == 0) {
                if ($("#ddlRole").parent().next(".validation").length == 0) // only add if not added
                {
                    $("#ddlRole").parent().after("<div class='validation' style='color:red;margin-bottom: 20px;'>Please Select Role</div>");
                }

            }
            else {
                $("#ddlRole").parent().next(".validation").remove(); // remove it
            }
        }


        function ValidateEmail(email) {
            // Validate email format
            var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            return expr.test(email);
        };


    </script>



</asp:Content>

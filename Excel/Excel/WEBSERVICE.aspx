<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WEBSERVICE.aspx.cs" Inherits="Excel.WEBSERVICE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form1" runat="server">
    <div>
    
    </div>
    </form>--%>
</body>
</html>

<script src="Scripts/jquery-1.7.1.min.js"></script>
<%--<script src="http://code.jquery.com/jquery-2.1.1.js"></script>--%>

<script>
    $(document).ready(function () {
        debugger;
        callservice();
    });


    function callservice() {
        //var data = { LicenseKey: "99211A79-8523-430B-9F0B-4821C8359C22", QueryType: "Q", FirstName: "v", LastName: "l", BirthYear: "1992", BirthMonth: "12", BirthDay: "2", PolicyState: "m" };
        var data = { LicenseKey: "99211A79-8523-430B-9F0B-4821C8359C22", SearchID: "", Reference: "", QueryType: "Q", FirstName: "v", MiddleName: "", LastName: "l", NameSuffix: "", Gender: "", DLNumber: "", DLState: "", DLCountryCode: "", BirthYear: "1992", BirthMonth: "12", BirthDay: "2", Address1: "", Address2: "", City: "", StateCode: "", Zip: "", PolicyState: "m", LookbackStartDate: "", LookbackEndDate: "", DHIExpansionXML: "" };
        alert();
        $.ajax({
            type: "POST",
            //url: "https://customertest.drivershistory.com/currentVersion6/wsSubjectPrescreenPlus.asmx/SubjectSearchBasic?LicenseKey=99211A79-8523-430B-9F0B-4821C8359C22&SearchID=1&Reference=ds&QueryType=Q&FirstName=John&MiddleName=&LastName=Bridges&NameSuffix=&Gender=&DLNumber=&DLState=&DLCountryCode=&BirthYear=1972&BirthMonth=04&BirthDay=07&Address1=&Address2=&City=&StateCode=&Zip=&PolicyState=NJ&LookbackStartDate=&LookbackEndDate=&DHIExpansionXML=&Suffix=&DLCountry=",
            url: "https://www.customertest.drivershistory.com/currentVersion6/wsSubjectPrescreenPlus.asmx/SubjectSearchBasic?LicenseKey=99211A79-8523-430B-9F0B-4821C8359C22&SearchID=''&Reference=''&QueryType=Q&FirstName=John&MiddleName=''&LastName=Bridges&NameSuffix=''&Gender=''&DLNumber=''&DLState=''&DLCountryCode=''&BirthYear=1992&BirthMonth=04&BirthDay=07&Address1=''&Address2=''&City=''&StateCode=''&Zip=''&PolicyState=NJ&LookbackStartDate=''&LookbackEndDate=''&DHIExpansionXML=''",
            contenttype: "application/json;charset=utf-8",
            datatype: "json",
            async: true,
            crossDomain: true,
            success: function (response) {
                console.log(response);
                alert(response)
            },
            error: function (response) {
                alert(response)
                console.log(response);
            }
        });
    }
</script>

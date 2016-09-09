<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExternalLogin.aspx.cs" Inherits="TicketReservation.ExternalLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Google Login</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <script>
        try {
            // First, parse the query string
            var params = {}, queryString = location.hash.substring(1),
regex = /([^&=]+)=([^&]*)/g, m;
            while (m = regex.exec(queryString)) {
                params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
            }
            var ss = queryString.split("&")
            if (location.hash.includes("#state")) {
                window.location = "ExternalLogin.aspx?" + ss[1];
            }

        } catch (exp) {
            alert(exp.message + " here 1");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="form-group">
                        <h2>Register</h2>
                        <h3>Associate your Google account.</h3>
                        <table>

                            <tr>
                                <td>Email</td>
                                <td><%=Email_address%></td>
                            </tr>
                            <tr>
                                <td>First name</td>
                                <td><%=firstName%></td>
                            </tr>
                            <tr>
                                <td>Last name</td>
                                <td><%=LastName%></td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <div class="form-group">
                        <p class="text-info">
                            You've successfully authenticated with Google.
        Please enter a user name for this site below and click the Register button to finish
        logging in.
                        </p>

                        <div class="col-lg-6">
                            <label style="color: #006699">Username</label>
                            <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>


                            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-default" OnClick="btnRegister_Click" />
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>

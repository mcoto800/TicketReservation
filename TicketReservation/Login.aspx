<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TicketReservation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log-in</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script>


        function OpenGoogleLoginPopup() {


            var url = "https://accounts.google.com/o/oauth2/auth?";
            url += "scope=https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email&";
            url += "state=%2Fprofile&"
            url += "redirect_uri=<%=Return_url %>&"
            url += "response_type=token&"
            url += "client_id=<%=Client_ID %>";

            window.location = url;
        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1 align="center" style="color: #006699">Login</h1>
                <div class="col-lg-6" >
                    <label style="color: #006699">Username</label>
                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                    <label style="color: #006699">Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>


                    <asp:Label ID="lblInvalid" Visible="false" runat="server" Text="Invalid username or password!" ForeColor="#993300"></asp:Label>
                    <br />
                    <br />
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Signup.aspx">SignUp</asp:HyperLink>
                    <asp:Button ID="btnLogin" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    <br />
                    <a href="#" class="btn btn-lg btn-danger btn-block" id="googleLogin" onclick="OpenGoogleLoginPopup();" name="butrequest"><span>Google Login</span></a>

                </div>

            </div>
        </div>
    </form>
    <!-- 
    <form action="/Account/ExternalLogin?ReturnUrl=%2F" method="post">
        <input name="__RequestVerificationToken" type="hidden" value="42OIKN7PVBFm0C4QLZoRJJ3Igxo3cih2dk3oFEK4iwqNOXfO1mXFDm803YkBwPGtBnYrGTVx4NEIHVyGWpR2u3LoOFYpZCvfhO7t-VG3ZzI1" />
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                     <button type="submit" class="btn btn-lg btn-danger btn-block" id="Google" name="provider" value="Google" title="Log in using your Google account">Google+</button>
                </div>
            </div>
        </div>
    </form>
        -->
</body>
</html>

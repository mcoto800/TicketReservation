<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="TicketReservation.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1 align="center" style="color: #006699">Sign Up</h1>
                <div class="col-lg-6">
                    <asp:Label ID="lblAirline" Font-Bold="true" CssClass="color: #006699" Visible="false" runat="server" Text="Airline" ForeColor="#006699"></asp:Label>
                    <asp:DropDownList ID="ddlAirlines" runat="server" CssClass="form-control" AutoPostBack="true" Visible="false"></asp:DropDownList>

                    <label style="color: #006699">First Name</label>
                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>

                    <label style="color: #006699">Last Name</label>
                    <asp:TextBox ID="txtlastName" CssClass="form-control" runat="server"></asp:TextBox>

                    <label style="color: #006699">Username</label>
                    <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server"></asp:TextBox>
                    <label style="color: #006699">Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

                    <label style="color: #006699">VerifyPassword</label>
                    <asp:TextBox ID="txtPassword1" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>

                    <label style="color: #006699">Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                    <br />
                    

                    <asp:Label ID="lblError" Visible="false" runat="server" Text="Invalid username or password!" ForeColor="#993300"></asp:Label>
                    <br />
                    <asp:Button ID="btnSignup" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Sign up" OnClick="btnLogin_Click" />

                </div>

            </div>
        </div>
    </form>
</body>
</html>

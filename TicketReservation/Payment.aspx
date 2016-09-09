<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="TicketReservation.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />


            <div class="container">
                <div class="row">
                    <asp:Panel ID="pnlPayment" runat="server">
                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/Images/visa-american-express-mastercard.jpg" Width="40%" />
                        <h1 align="center" style="color: #006699">Card Details</h1>
                        <div class="col-lg-6">
                            <label style="color: #006699">Card Number</label>
                            <asp:TextBox ID="txtCardNumber" CssClass="form-control" runat="server"></asp:TextBox>

                            <label style="color: #006699">Security Code</label>
                            <asp:TextBox ID="txtSecurity" CssClass="form-control" runat="server"></asp:TextBox>

                            <label style="color: #006699">Expiration Month</label>
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" AutoPostBack="true">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>

                            <label style="color: #006699">Expiration Year</label>
                            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" AutoPostBack="true">
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>

                            </asp:DropDownList>


                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                        <h3>Trip total: $<asp:Label ID="tripTotal" Font-Bold="true" runat="server" Text="$0.00"></asp:Label></h3>
                                    </td>

                                </tr>
                            </table>
                            <asp:Label ID="lblError" Visible="false" runat="server" Text="Invalid username or password!" ForeColor="#993300"></asp:Label>
                            <br />
                            <asp:Button ID="btnSignup" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />

                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlTnks" runat="server" Visible="false" Width="100%" BackImageUrl="~/Images/plane_sunset.jpg" Height="1020px">
                        <br />
                        <br />
                        <br />
                        <h1 align="center" style="color: #FFFFFF">Reservation
                            <asp:Label ID="txtReservation" runat="server" Text="Label"></asp:Label>
                            confirmed!!</h1>
                        <br />
                        <br />
                        <h2 align="center" style="color: #ffffff">We have sent an email with the <a href='/ManageTrip.aspx?rsvn=<%=reservationNumber%>' target='_blank'>trip details</a>!</h2>
                    </asp:Panel>
                </div>
            </div>

        </div>
    </form>
</body>
</html>

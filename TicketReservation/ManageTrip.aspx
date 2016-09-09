<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageTrip.aspx.cs" Inherits="TicketReservation.CheckIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reservation Details</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <h1 class="form-signin-heading">Reservation
                    <asp:Label ID="txtReservation" runat="server" Text="Label"></asp:Label></h1>
                <br />
                <br />
                <h2 class="form-signin-heading">Trip Details</h2>
                <br />
                <br />

                <asp:GridView ID="gvResults" Width="100%" runat="server" AutoGenerateSelectButton="True" AllowPaging="True" AllowSorting="True" EnablePersistedSelection="True" OnSelectedIndexChanged="gvResults_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="gvResults_RowDataBound">
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                    <RowStyle ForeColor="#000066" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <br />

                <asp:Label ID="lblSeats" Visible="false" runat="server" Text="Choose/Change Seat:" ForeColor="#006699"></asp:Label>
                <asp:DropDownList ID="ddlSeat" runat="server" CssClass="form-control" AutoPostBack="true" Visible="false">
                    <asp:ListItem>A1</asp:ListItem>
                    <asp:ListItem>A2</asp:ListItem>
                    <asp:ListItem>A3</asp:ListItem>
                    <asp:ListItem>A4</asp:ListItem>
                    <asp:ListItem>B1</asp:ListItem>
                    <asp:ListItem>B2</asp:ListItem>
                    <asp:ListItem>B3</asp:ListItem>
                    <asp:ListItem>B4</asp:ListItem>
                </asp:DropDownList>


            </div>
            <br />
            <div class="row">
                <asp:Button ID="btnChangeSeat" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Change Seat" OnClick="btnChangeSeat_Click" Visible="false" /><br />
                <asp:Button ID="btnSelec" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Check-In" OnClick="btnCheckIn_Click" Visible="false" /><br />


                <asp:Button ID="btnCancel" CssClass="btn btn-lg btn-danger btn-block" runat="server" Text="Cancel Flight" OnClick="btnCancel_Click" />
                <asp:Label ID="canContinue" runat="server" Text="false" Visible="false"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>

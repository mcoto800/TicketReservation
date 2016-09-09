<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffManageFlights.aspx.cs" Inherits="TicketReservation.StaffManageFlights" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Flights</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
            <div class="row">
                <h1 align="center" >Flight manager</h1>
                

                    <br />
                <br />
                    <asp:Button ID="btnBackToFlight" CssClass="btn btn-default" runat="server" Text="Back to Flights" OnClick="btnBack_Click" Visible ="false"/><br /><br />
                <asp:Label ID="departureNoFlights" runat="server" Text="No flights found!" Visible="false"></asp:Label>
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
                    <div class="col-lg-6">
                    <br /><br />
                    <asp:Button ID="btnViewTickets" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="View Tickets" OnClick="btnViewTicketDetail_Click" Visible ="false"/><br />
                      <asp:Button ID="btnCancelFlight" CssClass="btn btn-lg btn-danger btn-block" runat="server" Text="Cancel Flight" OnClick="btnCancelFlight_Click" Visible ="false"/>
                      <asp:Button ID="btnCancelTicket" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Cancel Ticket" OnClick="btnCancelTicket_Click" Visible ="false"/>
                    <br />
        </div>
        </div>
        </div>

        <asp:Label ID="lblSource" runat="server" Text="F" Visible="false"></asp:Label>
        <asp:Label ID="lblSelectedFlight" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblSelectedTicket" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="lblAirlineiD" runat="server" Text="" Visible="false"></asp:Label>
    </form>
    
</body>
</html>

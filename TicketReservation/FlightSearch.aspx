<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightSearch.aspx.cs" Inherits="TicketReservation.FlightSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flight Selection</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">

                <h2 class="form-signin-heading">Departure flight</h2>
                <br />
                <br />
                <asp:Label ID="departureNoFlights" runat="server" Text="No flights found! try another search!" Visible="false"></asp:Label>
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
            </div>
            <div class="row">
                <asp:Panel ID="pnlReturn" runat="server" Visible="false">


                    <h2 class="form-signin-heading">Return flight</h2>
                    <br />
                    <br />
                    <asp:Label ID="returnNoFlights" runat="server" Text="No flights found! try another search!" Visible="false"></asp:Label>
                    <asp:GridView ID="gvReturnResults" Width="100%" runat="server" AutoGenerateSelectButton="True" AllowPaging="True" AllowSorting="True" EnablePersistedSelection="True" OnSelectedIndexChanged="gvReturnResults_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="gvResults_RowDataBound">
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
                </asp:Panel>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <h3>Trip total:
                                <asp:Label ID="tripTotal" Font-Bold="true" runat="server" Text="$0.00"></asp:Label></h3>
                        </td>

                    </tr>
                </table>
                <br />
                <asp:Button ID="btnSelec" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Continue" OnClick="btnSelect_Click" />
                <asp:Label ID="canContinue" runat="server" Text="false" Visible="false"></asp:Label>
            </div>

        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TicketReservation.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flight Reservation</title>

    <style type="text/css">
        body {
            background-image: url('Images/travel_HD.jpg');
            background-repeat: no-repeat;
            background-size: cover;
            background-position: center;
        }
    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.0/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#dateFrom").datepicker();
            $("#dateTo").datepicker();
        });
    </script>
</head>


<body>
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <div align="right">
                
            <asp:HyperLink ID="linkLogin"  Font-Bold="true" ForeColor="#ffffff"  NavigateUrl="~/Login.aspx" runat="server">Log In</asp:HyperLink><asp:Label ID="lblUsername" runat="server" ForeColor="#ffffff" Font-Bold="true" Text=""></asp:Label><asp:LinkButton ID="LinkButton1" Font-Bold="true" ForeColor="White" runat="server" OnClick="LinkButton1_Click"> |  Log Out</asp:LinkButton>
            </div>
                <div class="row">
                <h1 align="center" style="color: #FFFFFF">BOOK A FLIGHT WITH US!</h1>
                <div class="col-lg-9">
                    <label for="from" style="color: #FFFFFF">FROM:</label>
                    <asp:DropDownList ID="from" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                    <label for="destination" style="color: #FFFFFF">WHERE WOULD YOU LIKE TO GO?</label>
                    <asp:DropDownList ID="destination" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>


                    <label for="destination" style="color: #FFFFFF">WHEN?</label>
                    <asp:TextBox ID="dateFrom" CssClass="form-control" runat="server"></asp:TextBox>

                    <div class="checkbox">
                        <label style="color: #FFFFFF">
                            <asp:CheckBox ID="roundTrip" runat="server" AutoPostBack="true" OnCheckedChanged="roundTrip_CheckedChanged" />
                            ROUND TRIP?   
                        </label>
                    </div>
                    <asp:Label ID="lblTo" runat="server" Text="RETURNING:" Visible="false" ForeColor="#ffffff"></asp:Label>

                    <asp:TextBox ID="dateTo" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>

                    <br />
                    <asp:Button ID="btnSearch" CssClass="btn btn-lg btn-primary btn-block" runat="server" Text="Search" OnClick="btnSearch_Click" />

                </div>

            </div>
        </div>
    </form>

</body>
</html>

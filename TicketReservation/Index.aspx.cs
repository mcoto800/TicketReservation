using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketReservation
{
    public partial class Index : System.Web.UI.Page
    {
        wsTickets.TicketReservation_WSSoapClient wsTickets = new TicketReservation.wsTickets.TicketReservation_WSSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (SessionManager.getSessionUser() != null)
                {
                    linkLogin.Visible = false;
                    lblUsername.Text = "Welcome "+ SessionManager.getSessionUser().getLogin();
                }
                DataSet airports = wsTickets.getAllAirports();
                from.DataSource = airports;
                from.DataTextField = "CITY";
                from.DataValueField = "AIRPORT_CODE";
                from.DataBind();

                destination.DataSource = airports;
                destination.DataTextField = "CITY";
                destination.DataValueField = "AIRPORT_CODE";
                destination.DataBind();
            }
            
            bool logged = (SessionManager.getSessionUser() != null);
            LinkButton1.Visible = logged;
            lblUsername.Visible = logged;
            linkLogin.Visible = !logged;

        }

        protected void roundTrip_CheckedChanged(object sender, EventArgs e)
        {

            lblTo.Visible = roundTrip.Checked;
            dateTo.Visible = roundTrip.Checked;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string fromAirportCode = from.SelectedItem.Value.ToString();
            string destinationAirportCode = destination.SelectedItem.Value.ToString();
            DateTime departureDate = DateTime.Parse(dateFrom.Text);
            DateTime returnDate;
            if (roundTrip.Checked)
            {
                returnDate = DateTime.Parse(dateTo.Text);
                Response.Redirect("/FlightSearch.aspx?from=" + fromAirportCode + "&to=" + destinationAirportCode + "&dptDate=" + departureDate.ToString("yyyyMMddHHmmss") + "&retDate=" + returnDate.ToString("yyyyMMddHHmmss") + "&roundtrip=" + roundTrip.Checked.ToString());
            }
            else
            {
                Response.Redirect("/FlightSearch.aspx?from=" + fromAirportCode + "&to=" + destinationAirportCode + "&dptDate=" + departureDate.ToString("yyyyMMddHHmmss") + "&retDate=" + "&roundtrip=" + roundTrip.Checked.ToString());
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}
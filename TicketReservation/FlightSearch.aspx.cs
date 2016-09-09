using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketReservation
{
    public partial class FlightSearch : System.Web.UI.Page
    {
        wsTickets.TicketReservation_WSSoapClient wsTickets = new TicketReservation.wsTickets.TicketReservation_WSSoapClient();
        float tripTotalv;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string fromAirportCode = Request.QueryString["from"];
                    string destinationAirportCode = Request.QueryString["to"];
                    bool roundTrip = bool.Parse(Request.QueryString["roundtrip"]);
                    DateTime departureDate = DateTime.ParseExact(Request.QueryString["dptDate"], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);



                    DataSet results;
                    if (roundTrip)
                    {
                        DateTime returnDate = DateTime.ParseExact(Request.QueryString["retDate"], "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                        results = wsTickets.searchRoundTripFlight(departureDate, returnDate, fromAirportCode, destinationAirportCode);
                        if (results.Tables[1].Rows.Count > 0)
                        {
                            gvReturnResults.DataSource = results.Tables[1];
                            gvReturnResults.DataKeyNames = "FLIGHT_ID".Split(';');
                            gvReturnResults.DataBind();
                        }
                        else
                        {
                            returnNoFlights.Visible = true;
                        }
                    }
                    else
                    {
                        results = wsTickets.searchOneWayFlight(departureDate, fromAirportCode, destinationAirportCode);
                    }
                    if (results.Tables[0].Rows.Count > 0)
                    {
                        gvResults.DataSource = results.Tables[0];
                        gvResults.DataKeyNames = "FLIGHT_ID".Split(';');
                        gvResults.DataBind();
                    }
                    else
                    {
                        departureNoFlights.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/Index.aspx");
                }
            }
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (canContinue.Text == "true")
            {
                if (bool.Parse(Request.QueryString["roundtrip"]))
                {
                    Trip.createSessionTrip(new Trip(int.Parse(gvResults.SelectedRow.Cells[9].Text), int.Parse(gvReturnResults.SelectedRow.Cells[9].Text), getPrice()));
                }
                else
                {
                    Trip.createSessionTrip(new Trip(int.Parse(gvResults.SelectedRow.Cells[9].Text), getPrice()));
                }
                if (Session["userID"] == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    Response.Redirect("/Payment.aspx");
                }
            }
        }

        protected void gvResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bool.Parse(Request.QueryString["roundtrip"]))
            {
                pnlReturn.Visible = true;
            }
            else
            {
                canContinue.Text = "true";
            }

            tripTotalv = float.Parse(gvResults.SelectedRow.Cells[1].Text);
            if (gvReturnResults.SelectedRow != null)
            {
                tripTotalv += float.Parse(gvReturnResults.SelectedRow.Cells[1].Text);
            }
            tripTotal.Text = "$ " + tripTotalv;


        }

        protected void gvReturnResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            canContinue.Text = "true";
            tripTotalv = float.Parse(gvResults.SelectedRow.Cells[1].Text);
            tripTotalv += float.Parse(gvReturnResults.SelectedRow.Cells[1].Text);
            tripTotal.Text = "$ " + tripTotalv;
        }

        protected void gvResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                e.Row.Cells[11].Visible = false;
                e.Row.Cells[12].Visible = false;

                e.Row.Cells[13].Visible = false;
            }
        }

        private float getPrice()
        {
            if (bool.Parse(Request.QueryString["roundtrip"]))
            {

                tripTotalv = float.Parse(gvResults.SelectedRow.Cells[1].Text);
                if (gvReturnResults.SelectedRow != null)
                {
                    tripTotalv += float.Parse(gvReturnResults.SelectedRow.Cells[1].Text);
                }
            }
            else
            {
                tripTotalv = float.Parse(gvResults.SelectedRow.Cells[1].Text);
            }
            return tripTotalv;
        }
    }
}
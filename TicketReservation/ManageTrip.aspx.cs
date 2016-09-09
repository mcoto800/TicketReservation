using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketReservation
{
    public partial class CheckIn : System.Web.UI.Page
    {
        wsTickets.TicketReservation_WSSoapClient wsTickets = new TicketReservation.wsTickets.TicketReservation_WSSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["rsvn"] != null)
                {
                    txtReservation.Text = Request.QueryString["rsvn"];
                    DataSet results = wsTickets.getTripDetails(Request.QueryString["rsvn"]);
                    if (results.Tables[0].Rows.Count > 0)
                    {
                        gvResults.DataSource = results.Tables[0];
                        gvResults.DataKeyNames = "TICKET_ID".Split(';');
                        gvResults.DataBind();
                    }

                }
            }
        }

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {
            //validar 
            DateTime departure = Convert.ToDateTime( gvResults.SelectedRow.Cells[3].Text);
            DateTime now = DateTime.Now;

            TimeSpan diff = departure - now;
            double hours = diff.TotalHours;

            if (hours <= 48 && hours >= 4)
            {
                wsTickets.makeCheckIn(int.Parse(gvResults.SelectedRow.Cells[14].Text));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Check-in succesfull.')", true);
                btnSelec.Visible = false;
            }else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Check-in only from 48 hours up to 4 hours before each scheduled flight')", true);
            }

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
                e.Row.Cells[14].Visible = false;
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[16].Visible = false;
                e.Row.Cells[17].Visible = false;
            }
        }

        protected void gvResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSeats.Visible = true;
            ddlSeat.Visible = true;
            btnChangeSeat.Visible = true;
            btnSelec.Visible = true;

        }

        protected void btnChangeSeat_Click(object sender, EventArgs e)
        {
            wsTickets.changeSeat(int.Parse(gvResults.SelectedRow.Cells[14].Text), ddlSeat.SelectedItem.Value);
            DataSet results = wsTickets.getTripDetails(Request.QueryString["rsvn"]);
            if (results.Tables[0].Rows.Count > 0)
            {
                gvResults.DataSource = results.Tables[0];
                gvResults.DataKeyNames = "TICKET_ID".Split(';');
                gvResults.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            wsTickets.cancelReservation(Request.QueryString["rsvn"]);
            Response.Redirect("~/Index.aspx");
        }
    }
}
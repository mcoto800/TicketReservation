using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketReservation
{
    public partial class StaffManageFlights : System.Web.UI.Page
    {
        wsTickets.TicketReservation_WSSoapClient wsTickets = new TicketReservation.wsTickets.TicketReservation_WSSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet results;

                if (Request.QueryString["airline"] != null)
                {
                    lblAirlineiD.Text = Request.QueryString["airline"];
                    results = wsTickets.getAirlineFlights(int.Parse(lblAirlineiD.Text));

                    if (results.Tables[0].Rows.Count > 0)
                    {
                        lblSource.Text = "F";
                        gvResults.DataSource = results.Tables[0];
                        gvResults.DataKeyNames = "FLIGHT_ID".Split(';');
                        gvResults.DataBind();

                    }
                    else
                    {
                        departureNoFlights.Visible = true;
                        departureNoFlights.Text = "No flights found!";
                    }
                }

            }
        }

        protected void gvResults_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lblSource.Text == "F")
            {
                lblSelectedFlight.Text = gvResults.SelectedValue.ToString();
                btnCancelFlight.Visible = true;
                btnViewTickets.Visible = true;

            }
            else
            {
                lblSelectedTicket.Text = gvResults.SelectedValue.ToString();
                btnCancelTicket.Visible = true;
                btnBackToFlight.Visible = true;
            }


        }

        protected void gvResults_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (lblSource.Text == "F")
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
            else
            {
                if (e.Row.Cells.Count > 1)

                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[12].Visible = false;
                    e.Row.Cells[14].Visible = false;
                    e.Row.Cells[15].Visible = false;
                    e.Row.Cells[16].Visible = false;

                }
            }
        }

        protected void btnCancelTicket_Click(object sender, EventArgs e)
        {
            if (wsTickets.cancelReservation(gvResults.SelectedRow.Cells[13].Text))
            {
                //refoundClient();
                sendTicketCancelationMail(gvResults.SelectedRow.Cells[15].Text, gvResults.SelectedRow.Cells[13].Text);
                DataSet results = wsTickets.getTicketsOfFlight(int.Parse(lblSelectedFlight.Text));
                if (results.Tables[0].Rows.Count > 0)
                {
                    departureNoFlights.Visible = false;
                    lblSource.Text = "T";
                    gvResults.DataSource = results.Tables[0];
                    gvResults.DataKeyNames = "TICKET_ID".Split(';');
                    gvResults.DataBind();
                }
                else
                {
                    gvResults.DataSource = results.Tables[0];
                    gvResults.DataKeyNames = "TICKET_ID".Split(';');
                    gvResults.DataBind();
                    departureNoFlights.Visible = true;
                    departureNoFlights.Text = "No tickets found!";
                }
            }
        }
        public bool sendTicketCancelationMail(string mail, string reservation)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mailMessage.From = new MailAddress(Properties.Settings.Default.smtpUser);
                mailMessage.To.Add(mail);


                mailMessage.Subject = "Your flight reservation " + reservation + " has been cancelled!";
                mailMessage.Body = emailCancelationTemplateHTML("ticket");
                mailMessage.IsBodyHtml = true;


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.smtpUser, Properties.Settings.Default.smtpPwd);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private string emailCancelationTemplateHTML(string fot)
        {



            string html = @"<div style='width:900px;padding:20px 0;margin-top:10px'>
<table cellspacing='0' cellpadding='0' style='border:1px solid #007;border-bottom:0;border-top:0;padding:10px;padding-right:9px;font-family:Verdana,Arial;font-size:10px;color:#000000;width:744px' summary='Layout table for text content'>
<tbody><tr><td>
  
  <table border='0' cellspacing='0' cellpadding='0' style='width:100%;border:1px solid #0000b6'>
    <tbody><tr>
      <td style='padding:10px;font-size:10px;font-family:Verdana,Arial'> <p> Your " + fot + @" has been canceled by the staff! You will be re-founded completly.  </p>
        
        <p>We are sorry for any inconvenience we could cause you with this cancellation.</p>
        </td></tr>
    </tbody></table><br>
  
  </div>";


            return html;

        }

        protected void btnCancelFlight_Click(object sender, EventArgs e)
        {
            DataSet results = wsTickets.getTicketsOfFlight(int.Parse(lblSelectedFlight.Text));

            if (wsTickets.cancelFlight(int.Parse(lblSelectedFlight.Text)))
            {
                foreach (DataRow ticket in results.Tables[0].Rows)
                {
                    sendTicketCancelationMail(ticket["EMAIL"].ToString(), ticket["RESERVATION_NUMER"].ToString());
                }

                results = wsTickets.getAirlineFlights(int.Parse(lblAirlineiD.Text));

                if (results.Tables[0].Rows.Count > 0)
                {
                    departureNoFlights.Visible = false;
                    gvResults.DataSource = results.Tables[0];
                    gvResults.DataKeyNames = "FLIGHT_ID".Split(';');
                    gvResults.DataBind();

                }
                else
                {
                    gvResults.DataSource = results.Tables[0];
                    gvResults.DataKeyNames = "FLIGHT_ID".Split(';');
                    gvResults.DataBind();

                    departureNoFlights.Visible = true;
                    departureNoFlights.Text = "No flights found!";
                }
            }

        }

        protected void btnViewTicketDetail_Click(object sender, EventArgs e)
        {
            DataSet results = wsTickets.getTicketsOfFlight(int.Parse(lblSelectedFlight.Text));

            if (results.Tables[0].Rows.Count > 0)
            {
                lblSource.Text = "T";
                gvResults.DataSource = results.Tables[0];
                gvResults.DataKeyNames = "TICKET_ID".Split(';');
                gvResults.DataBind();
                departureNoFlights.Visible = false;

                btnCancelFlight.Visible = false;
                btnViewTickets.Visible = false;
                btnBackToFlight.Visible = true;

            }
            else
            {
                departureNoFlights.Visible = true;
                departureNoFlights.Text = "No tickets found!";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            DataSet results;

            results = wsTickets.getAirlineFlights(int.Parse(lblAirlineiD.Text));

            if (results.Tables[0].Rows.Count > 0)
            {
                lblSource.Text = "F";
                gvResults.DataSource = results.Tables[0];
                gvResults.DataKeyNames = "FLIGHT_ID".Split(';');
                gvResults.DataBind();

                departureNoFlights.Visible = false;
                btnCancelTicket.Visible = false;
                btnBackToFlight.Visible = false;
                btnCancelFlight.Visible = false;
                btnViewTickets.Visible = false;

            }
            else
            {
                departureNoFlights.Visible = true;
                departureNoFlights.Text = "No flights found!";
            }

        }
    }
}
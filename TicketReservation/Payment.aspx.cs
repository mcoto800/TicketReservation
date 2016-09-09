using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;
using System.IO;
using System.Net.Mail;

namespace TicketReservation
{
    public partial class Payment : System.Web.UI.Page
    {
        wsTickets.TicketReservation_WSSoapClient wsTickets = new TicketReservation.wsTickets.TicketReservation_WSSoapClient();
        Trip trip;
        public string reservationNumber;
        int userID;
        DataRow departureFlight, returnFlight;
        protected void Page_Load(object sender, EventArgs e)
        {

            trip = Trip.getSessionTrip();
            tripTotal.Text = trip.Price.ToString();
            userID = SessionManager.getSessionUser().getUserID();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

            if (trip.ReturnID > -1)
            {
                
                reservationNumber = wsTickets.makeARoundTripReservation(trip.DepartureID, trip.ReturnID, userID, "", "");
                returnFlight = wsTickets.getFlightById(trip.ReturnID).Tables[0].Rows[0];
            }
            else
            {
                reservationNumber = wsTickets.makeAOneWayReservation(trip.DepartureID, userID, "");
            }

            if (reservationNumber != "")
            {
                departureFlight = wsTickets.getFlightById(trip.DepartureID).Tables[0].Rows[0];
                if (sendMail(SessionManager.getSessionUser().getEmail()))
                {
                    pnlPayment.Visible = false;
                    txtReservation.Text = reservationNumber;
                    pnlTnks.Visible = true;
                };
            }
            else
            {
                lblError.Text = "Error during process! Try again later!";
                lblError.Visible = true;
            }
        }

        private bool sendMail(string emailAddress)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(Properties.Settings.Default.smtpUser);
                mail.To.Add(emailAddress);
                mail.Subject = "Flight reservation (" + reservationNumber + ") confirmation";
                mail.Body = emailTemplateHTML();
                mail.IsBodyHtml = true;

                /* NOT WORKING ON AZURE
                Attachment att = new Attachment(createPDFFile());
                mail.Attachments.Add(att);
                */
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.smtpUser, Properties.Settings.Default.smtpPwd);
                SmtpServer.EnableSsl = true;
                
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "SendMail: "+ex.Message);
                return false;
            }
        }

        private string emailTemplateHTML()
        {



            string html = @"<div style='width:900px;padding:20px 0;margin-top:10px'>
<table cellspacing='0' cellpadding='0' style='border:1px solid #007;border-bottom:0;border-top:0;padding:10px;padding-right:9px;font-family:Verdana,Arial;font-size:10px;color:#000000;width:744px' summary='Layout table for text content'>
<tbody><tr><td>
  <table border='0' cellspacing='0' cellpadding='0' style='width:100%'><tbody><tr>
    <td style='width:16px'><img src='https://ci6.googleusercontent.com/proxy/qn1nISMOZ8Y1i_nlH5Np_nYB7_ypAVm2faoIHeGaBdYzGZ6X5jmHfXxvcDLBrVU4dPxNJ61QtO8X6HGFzLQCqhhznI0-auIs=s0-d-e1-ft#http://www.ryanair.com/emails/images/BYF/top1l.gif' alt='leftcorner' width='16' height='24' class='CToWUd'></td>
    <td style='font-family:Verdana,Arial;background-color:#0000b6;color:#ffffff;font-size:14px;font-weight:bold'>
      YOUR <span class='il'>RESERVATION</span> <span class='il'>NUMBER</span> IS: 
      " + reservationNumber + @"</td>
    <td style='width:16px'><img src='https://ci4.googleusercontent.com/proxy/BXlRzPNsq2tSAjGxiJsGFzU-_D4u02TSZNt5MP1zc9Llm5XCtZbmh7KlvXQdlSME8NFR1_f0XJ1zLzQDNXMDmydMSWHvLMUp=s0-d-e1-ft#http://www.ryanair.com/emails/images/BYF/top1r.gif' alt='rightcorner' width='16' height='24' class='CToWUd'></td>
    </tr></tbody></table><br>
  
  <table border='0' cellspacing='0' cellpadding='0' style='width:100%;border:1px solid #0000b6'>
    <tbody><tr>
      <td style='padding:10px;font-size:10px;font-family:Verdana,Arial'> <p> YOU MUST <a href='" + Properties.Settings.Default.appLocation + "/ManageTrip.aspx?rsvn=" + reservationNumber + @"' target='_blank' >CHECK-IN ONLINE</a> AND PRINT YOUR BOARDING PASS ON AN INDIVIDUAL A4 PAGE FOR PRESENTATION AT BOTH AIRPORT SECURITY AND AT THE BOARDING GATE. </p>
        <p>You can check-in online        <strong>from 48 hours</strong> up to 4 hours before each scheduled flight departure time. Also you can manage you trip <a href='" + Properties.Settings.Default.appLocation + "/ManageTrip.aspx?rsvn=" + reservationNumber + @"' target='_blank' >HERE</a>.</p>
        <p>The option to reserve a seat is available on all our flights</p>
        </td></tr>
    </tbody></table><br>
  
  </div>";


            return html;

        }

        private string createPDFFile()
        {
            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.MaxPageLoadTime = 200;
            // create a new pdf document
            PdfDocument doc = new PdfDocument();

            // add a new page to the document
            PdfPage page = doc.AddPage();


            // create html element 
            PdfHtmlElement html = new PdfHtmlElement(createTempHTMLFile());

            // add the html element to the document
            page.Add(html);

            // save pdf document
            string myTempFile = Server.MapPath("~/App_Data/") + "Reservation " + reservationNumber + ".pdf";
            //Stream stream=new MemoryStream();
            doc.Save(myTempFile);

            // close pdf document
            doc.Close();
            return myTempFile;

        }

        private string createTempHTMLFile()
        {
            
            string myTempFile = Server.MapPath("~/App_Data/")+reservationNumber + ".html";
            using (StreamWriter sw = new StreamWriter(myTempFile))
            {
                sw.WriteLine(getTicketHTML());
            }
            return myTempFile;
        }

        private string getTicketHTML()
        {

            string htmlReturn = "";

            if (returnFlight != null)
            {
                htmlReturn = @"<p><b>COMING BACK</b><br>
            From " + returnFlight["From"] + @" to " + returnFlight["to"] + @"<br>
        " + returnFlight["Departure"] + @" Flight " + returnFlight["Flight Number"] + @" 
        Operator " + returnFlight["Airline"] + "</p>";
            }

            string html = @"<!DOCTYPE html>
<html>
<head>
    <title></title>
  </head >
  <body>
  <table border='0' cellspacing='0' cellpadding='0' style='width:100%'><tbody><tr>
    <td style='width:16px'><img src='https://ci6.googleusercontent.com/proxy/qn1nISMOZ8Y1i_nlH5Np_nYB7_ypAVm2faoIHeGaBdYzGZ6X5jmHfXxvcDLBrVU4dPxNJ61QtO8X6HGFzLQCqhhznI0-auIs=s0-d-e1-ft#http://www.ryanair.com/emails/images/BYF/top1l.gif' alt='leftcorner' width='16' height='24' class='CToWUd'></td>
    <td style='font-family:Verdana,Arial;background-color:#0000b6;color:#ffffff;font-size:14px;font-weight:bold'>
      YOUR <span class='il'>RESERVATION</span> <span class='il'>NUMBER</span> IS: 
      " + reservationNumber + @"</td>
    <td style='width:16px'><img src='https://ci4.googleusercontent.com/proxy/BXlRzPNsq2tSAjGxiJsGFzU-_D4u02TSZNt5MP1zc9Llm5XCtZbmh7KlvXQdlSME8NFR1_f0XJ1zLzQDNXMDmydMSWHvLMUp=s0-d-e1-ft#http://www.ryanair.com/emails/images/BYF/top1r.gif' alt='rightcorner' width='16' height='24' class='CToWUd'></td>
    </tr></tbody></table><br>
  <table border='0' cellspacing='0' cellpadding='0'>
    <tbody><tr><td>Itinerary/Receipt - All Times Are Local</td></tr>
    <tr><td style='border:1px solid #0000b6;width:100%;background-color:#bfd6f7;padding:10px;font-size:10px;font-family:Verdana,Arial'><div><strong>
      PASSENGERS</strong></div>
      <p>1. " + SessionManager.getSessionUser().getFullName() + @" 
</p></td></tr></tbody></table><br>
  
  <table border='0' cellspacing='0' cellpadding='0' style='border:1px solid #0000b6;width:100%;background-color:#bfd6f7'>
    <tbody><tr><td style='padding:10px;font-size:10px;font-family:Verdana,Arial'>
      <div><strong>GOING OUT</strong><br>
        
        From " + departureFlight["From"] + @" to " + departureFlight["to"] + @"<br>
        " + departureFlight["Departure"] + @" Flight " + departureFlight["Flight Number"] + @" 
        Operator " + departureFlight["Airline"] + @"</div> " + htmlReturn + @"
      
      
      
      </td></tr></tbody></table>
  <br>
</body>
</html>
  ";

            return html;
        }

    }
}
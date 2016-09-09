using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketReservation
{
    public partial class ExternalLogin : System.Web.UI.Page
    {
        wsTickets.TicketReservation_WSSoapClient wsTickets = new TicketReservation.wsTickets.TicketReservation_WSSoapClient();
        public string Email_address = "";
        public string Google_ID = "";
        public string firstName = "";
        public string LastName = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["access_token"] != null)
            {



                String URI = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + Request.QueryString["access_token"];

                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(URI);
                string b;

                /*I have not used any JSON parser because I do not want to use any extra dll/3rd party dll*/
                using (StreamReader br = new StreamReader(stream))
                {
                    b = br.ReadToEnd();
                }

                b = b.Replace("id", "").Replace("email", "");
                b = b.Replace("given_name", "");
                b = b.Replace("family_name", "").Replace("link", "").Replace("picture", "");
                b = b.Replace("gender", "").Replace("locale", "").Replace(":", "");
                b = b.Replace("\"", "").Replace("name", "").Replace("{", "").Replace("}", "");


                Array ar = b.Split(",".ToCharArray());
                for (int p = 0; p < ar.Length; p++)
                {
                    ar.SetValue(ar.GetValue(p).ToString().Trim(), p);

                }
                Email_address = ar.GetValue(1).ToString();
                Google_ID = ar.GetValue(0).ToString();
                firstName = ar.GetValue(4).ToString();
                LastName = ar.GetValue(5).ToString();

                DataSet client = wsTickets.getClientByMail(Email_address);

                if (client.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = client.Tables[0].Rows[0];
                    SessionManager.createSession(new SessionManager(int.Parse(dr["CLIENT_ID"].ToString()), dr["USERNAME"].ToString(), dr["FIRST_NAME"].ToString(), dr["LAST_NAME"].ToString(), dr["EMAIL"].ToString()));

                    if (Trip.getSessionTrip() == null)
                    {
                        Response.Redirect("/Index.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Payment.aspx");
                    }
                }

            }
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            int userID = wsTickets.newClient(txtUserName.Text, "", Email_address, firstName, LastName);

            SessionManager.createSession(new SessionManager(userID, txtUserName.Text, firstName, LastName, Email_address));
            if (Trip.getSessionTrip() == null)
            {
                Response.Redirect("/Index.aspx");
            }
            else
            {
                Response.Redirect("/Payment.aspx");
            }
        }
    }
}
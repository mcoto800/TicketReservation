using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketReservation
{
    public partial class Login : System.Web.UI.Page
    {
        wsTickets.TicketReservation_WSSoapClient wsTickets = new TicketReservation.wsTickets.TicketReservation_WSSoapClient();
        public string Return_url = "";

        public string Client_ID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                Client_ID = Properties.Settings.Default.clientID;
                Return_url = Properties.Settings.Default.appLocation + "/ExternalLogin.aspx";

                

            }

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "") { }
            else
            {
                int userID = wsTickets.validateLogin(txtUserName.Text, GetSHA1(txtPassword.Text));
                if (userID > -1)
                {
                    DataSet client = wsTickets.getClient(userID);

                    if (client.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = client.Tables[0].Rows[0];
                        SessionManager.createSession(new SessionManager(userID, dr["USERNAME"].ToString(), dr["FIRST_NAME"].ToString(), dr["LAST_NAME"].ToString(), dr["EMAIL"].ToString()));
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
                else
                {
                    userID = wsTickets.validateStaffLogin(txtUserName.Text, GetSHA1(txtPassword.Text));
                    if (userID > -1)
                    {
                        DataSet staff = wsTickets.getStaff(userID);

                        if (staff.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = staff.Tables[0].Rows[0];
                            SessionManager.createSession(new SessionManager(userID, dr["USERNAME"].ToString(), dr["FIRST_NAME"].ToString(), dr["LAST_NAME"].ToString(), dr["EMAIL"].ToString(), int.Parse(dr["AIRLINE_ID"].ToString())));
                            Response.Redirect("/StaffManageFlights.aspx?airline=" + dr["AIRLINE_ID"].ToString());
                        }

                    }
                    lblInvalid.Visible = true;
                }
            }
        }

        protected void btnLoginGoogle_Click(object sender, EventArgs e)
        {

        }


        private string GetSHA1(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
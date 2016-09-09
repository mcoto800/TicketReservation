using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicketReservation
{
    public partial class Signup : System.Web.UI.Page
    {
        wsTickets.TicketReservation_WSSoapClient wsTickets = new TicketReservation.wsTickets.TicketReservation_WSSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["staff"] != null)
                {
                    lblAirline.Visible = true;

                    DataSet airlines = wsTickets.getAllAirlines();
                    ddlAirlines.DataSource = airlines;
                    ddlAirlines.DataTextField = "AIRLINE_NAME";
                    ddlAirlines.DataValueField = "AIRLINE_ID";
                    ddlAirlines.DataBind();
                    ddlAirlines.Visible = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (!wsTickets.validNewUser(txtEmail.Text, txtUserName.Text))
            {
                lblError.Text = "This e-mail or username has been registred previously!";
                lblError.Visible = true;
            }
            else
            {
                if (txtPassword.Text != txtPassword1.Text)
                {
                    lblError.Text = "Passwords do not match!";
                    lblError.Visible = true;
                }
                else
                {
                    if (EvaluateIsValid(txtEmail.Text))
                    {
                        if (Request.QueryString["staff"] == null)
                        {
                            int userID = wsTickets.newClient(txtUserName.Text, GetSHA1(txtPassword.Text), txtEmail.Text, txtFirstName.Text, txtlastName.Text);

                            SessionManager.createSession(new SessionManager(userID, txtUserName.Text, txtFirstName.Text, txtlastName.Text, txtEmail.Text));
                            if (Trip.getSessionTrip() == null)
                            {
                                Response.Redirect("/Index.aspx");
                            }
                            else
                            {
                                Response.Redirect("/Payment.aspx");
                            }
                        }
                        else
                        {
                            int userID = wsTickets.newStaff(txtUserName.Text, GetSHA1(txtPassword.Text), txtEmail.Text, txtFirstName.Text, txtlastName.Text, int.Parse(ddlAirlines.SelectedItem.Value.ToString()));

                            SessionManager.createSession(new SessionManager(userID, txtUserName.Text, txtFirstName.Text, txtlastName.Text, txtEmail.Text));
                            Response.Redirect("/StaffManageFlights.aspx?airline="+ ddlAirlines.SelectedItem.Value.ToString());
                        }
                    }
                }

            }
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
        private bool EvaluateIsValid(string email)
        {
            string val = email;
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Match match = Regex.Match(val.Trim(), pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketReservation
{

    public class SessionManager
    {

        private int userID,airlineID;
        private string login, firstName, lastName, email;
        

        public SessionManager(int UserID, string Login, string FirstName, string LastName, string Email)
        {
            userID = UserID;
            login = Login;
            firstName = FirstName;
            lastName = LastName;
            email = Email;
        }
        public SessionManager(int UserID, string Login, string FirstName, string LastName, string Email,int AirlineID)
        {
            userID = UserID;
            login = Login;
            firstName = FirstName;
            lastName = LastName;
            email = Email;
            airlineID = AirlineID;
        }

        public string getLogin()
        {
            return login;
        }

        public int getUserID()
        {
            return userID;
        }
        public string getEmail()
        {
            return email;
        }


        public string getFullName()
        {
            return firstName + " " + lastName;
        }

        public int getAirlineID()
        {
            return airlineID;
        }

        public static SessionManager getSessionUser() { return HttpContext.Current.Session["userID"] as SessionManager; }


        public static void createSession(SessionManager user) { HttpContext.Current.Session["userID"] = user; }
    }
}
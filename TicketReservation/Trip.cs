using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketReservation
{
    public class Trip
    {
        private int departureID;
        private int returnID;
        private float price;

        public Trip(int DepartureID, int ReturnID, float Price)
        {
            departureID = DepartureID;
            returnID = ReturnID;
            price = Price;
        }
        public Trip(int DepartureID, float Price)
        {
            departureID = DepartureID;
            returnID = -1;
            price = Price;
        }

        public int DepartureID
        {
            get
            {
                return departureID;
            }

            set
            {
                departureID = value;
            }
        }

        public int ReturnID
        {
            get
            {
                return returnID;
            }

            set
            {
                returnID = value;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public static Trip getSessionTrip() { return HttpContext.Current.Session["trip"] as Trip; }


        public static void createSessionTrip(Trip trip) { HttpContext.Current.Session["trip"] = trip; }
    }
}
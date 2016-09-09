﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicketReservation.wsTickets {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wsTickets.TicketReservation_WSSoap")]
    public interface TicketReservation_WSSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAllAirports", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getAllAirports();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAllAirports", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getAllAirportsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/validateLogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int validateLogin(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/validateLogin", ReplyAction="*")]
        System.Threading.Tasks.Task<int> validateLoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/newClient", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int newClient(string userName, string password, string email, string firstName, string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/newClient", ReplyAction="*")]
        System.Threading.Tasks.Task<int> newClientAsync(string userName, string password, string email, string firstName, string lastName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getClient", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getClient(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getClient", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getClientAsync(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getClientByMail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getClientByMail(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getClientByMail", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getClientByMailAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/validNewUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool validNewUser(string email, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/validNewUser", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> validNewUserAsync(string email, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertFlight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool InsertFlight(int airlineID, string flightNumber, System.DateTime departureDate, System.DateTime arrivingDate, string departureAirportCode, string destinationAirportCode, int airplaneID, float price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertFlight", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> InsertFlightAsync(int airlineID, string flightNumber, System.DateTime departureDate, System.DateTime arrivingDate, string departureAirportCode, string destinationAirportCode, int airplaneID, float price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAirlineFlights", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getAirlineFlights(int airlineID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAirlineFlights", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getAirlineFlightsAsync(int airlineID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/searchRoundTripFlight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet searchRoundTripFlight(System.DateTime departureDate, System.DateTime returnDate, string fromAirportCode, string toAirportCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/searchRoundTripFlight", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> searchRoundTripFlightAsync(System.DateTime departureDate, System.DateTime returnDate, string fromAirportCode, string toAirportCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/searchOneWayFlight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet searchOneWayFlight(System.DateTime departureDate, string fromAirportCode, string toAirportCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/searchOneWayFlight", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> searchOneWayFlightAsync(System.DateTime departureDate, string fromAirportCode, string toAirportCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getTripDetails", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getTripDetails(string reservationNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getTripDetails", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getTripDetailsAsync(string reservationNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/makeCheckIn", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool makeCheckIn(int ticketID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/makeCheckIn", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> makeCheckInAsync(int ticketID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/changeSeat", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool changeSeat(int ticketID, string seat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/changeSeat", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> changeSeatAsync(int ticketID, string seat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/cancelReservation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool cancelReservation(string reservation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/cancelReservation", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> cancelReservationAsync(string reservation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/cancelFlight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool cancelFlight(int flightID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/cancelFlight", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> cancelFlightAsync(int flightID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/makeAOneWayReservation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string makeAOneWayReservation(int departureFlightID, int clientID, string seatNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/makeAOneWayReservation", ReplyAction="*")]
        System.Threading.Tasks.Task<string> makeAOneWayReservationAsync(int departureFlightID, int clientID, string seatNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/makeARoundTripReservation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string makeARoundTripReservation(int departureFlightID, int returnFlightID, int clientID, string departureSeatNumber, string returnSeatNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/makeARoundTripReservation", ReplyAction="*")]
        System.Threading.Tasks.Task<string> makeARoundTripReservationAsync(int departureFlightID, int returnFlightID, int clientID, string departureSeatNumber, string returnSeatNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getFlightById", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getFlightById(int flightID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getFlightById", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getFlightByIdAsync(int flightID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getFlightsDepartingHours", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getFlightsDepartingHours(int hours);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getFlightsDepartingHours", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getFlightsDepartingHoursAsync(int hours);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getTicketsOfFlight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getTicketsOfFlight(int flightID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getTicketsOfFlight", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getTicketsOfFlightAsync(int flightID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/newStaff", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int newStaff(string userName, string password, string email, string firstName, string lastName, int airlineID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/newStaff", ReplyAction="*")]
        System.Threading.Tasks.Task<int> newStaffAsync(string userName, string password, string email, string firstName, string lastName, int airlineID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getStaff", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getStaff(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getStaff", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getStaffAsync(int userID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getStaffofAirline", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getStaffofAirline(int airlineID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getStaffofAirline", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getStaffofAirlineAsync(int airlineID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAllAirlines", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getAllAirlines();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/getAllAirlines", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> getAllAirlinesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/validateStaffLogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int validateStaffLogin(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/validateStaffLogin", ReplyAction="*")]
        System.Threading.Tasks.Task<int> validateStaffLoginAsync(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TicketReservation_WSSoapChannel : TicketReservation.wsTickets.TicketReservation_WSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TicketReservation_WSSoapClient : System.ServiceModel.ClientBase<TicketReservation.wsTickets.TicketReservation_WSSoap>, TicketReservation.wsTickets.TicketReservation_WSSoap {
        
        public TicketReservation_WSSoapClient() {
        }
        
        public TicketReservation_WSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TicketReservation_WSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketReservation_WSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TicketReservation_WSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet getAllAirports() {
            return base.Channel.getAllAirports();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getAllAirportsAsync() {
            return base.Channel.getAllAirportsAsync();
        }
        
        public int validateLogin(string username, string password) {
            return base.Channel.validateLogin(username, password);
        }
        
        public System.Threading.Tasks.Task<int> validateLoginAsync(string username, string password) {
            return base.Channel.validateLoginAsync(username, password);
        }
        
        public int newClient(string userName, string password, string email, string firstName, string lastName) {
            return base.Channel.newClient(userName, password, email, firstName, lastName);
        }
        
        public System.Threading.Tasks.Task<int> newClientAsync(string userName, string password, string email, string firstName, string lastName) {
            return base.Channel.newClientAsync(userName, password, email, firstName, lastName);
        }
        
        public System.Data.DataSet getClient(int userID) {
            return base.Channel.getClient(userID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getClientAsync(int userID) {
            return base.Channel.getClientAsync(userID);
        }
        
        public System.Data.DataSet getClientByMail(string email) {
            return base.Channel.getClientByMail(email);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getClientByMailAsync(string email) {
            return base.Channel.getClientByMailAsync(email);
        }
        
        public bool validNewUser(string email, string username) {
            return base.Channel.validNewUser(email, username);
        }
        
        public System.Threading.Tasks.Task<bool> validNewUserAsync(string email, string username) {
            return base.Channel.validNewUserAsync(email, username);
        }
        
        public bool InsertFlight(int airlineID, string flightNumber, System.DateTime departureDate, System.DateTime arrivingDate, string departureAirportCode, string destinationAirportCode, int airplaneID, float price) {
            return base.Channel.InsertFlight(airlineID, flightNumber, departureDate, arrivingDate, departureAirportCode, destinationAirportCode, airplaneID, price);
        }
        
        public System.Threading.Tasks.Task<bool> InsertFlightAsync(int airlineID, string flightNumber, System.DateTime departureDate, System.DateTime arrivingDate, string departureAirportCode, string destinationAirportCode, int airplaneID, float price) {
            return base.Channel.InsertFlightAsync(airlineID, flightNumber, departureDate, arrivingDate, departureAirportCode, destinationAirportCode, airplaneID, price);
        }
        
        public System.Data.DataSet getAirlineFlights(int airlineID) {
            return base.Channel.getAirlineFlights(airlineID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getAirlineFlightsAsync(int airlineID) {
            return base.Channel.getAirlineFlightsAsync(airlineID);
        }
        
        public System.Data.DataSet searchRoundTripFlight(System.DateTime departureDate, System.DateTime returnDate, string fromAirportCode, string toAirportCode) {
            return base.Channel.searchRoundTripFlight(departureDate, returnDate, fromAirportCode, toAirportCode);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> searchRoundTripFlightAsync(System.DateTime departureDate, System.DateTime returnDate, string fromAirportCode, string toAirportCode) {
            return base.Channel.searchRoundTripFlightAsync(departureDate, returnDate, fromAirportCode, toAirportCode);
        }
        
        public System.Data.DataSet searchOneWayFlight(System.DateTime departureDate, string fromAirportCode, string toAirportCode) {
            return base.Channel.searchOneWayFlight(departureDate, fromAirportCode, toAirportCode);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> searchOneWayFlightAsync(System.DateTime departureDate, string fromAirportCode, string toAirportCode) {
            return base.Channel.searchOneWayFlightAsync(departureDate, fromAirportCode, toAirportCode);
        }
        
        public System.Data.DataSet getTripDetails(string reservationNumber) {
            return base.Channel.getTripDetails(reservationNumber);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getTripDetailsAsync(string reservationNumber) {
            return base.Channel.getTripDetailsAsync(reservationNumber);
        }
        
        public bool makeCheckIn(int ticketID) {
            return base.Channel.makeCheckIn(ticketID);
        }
        
        public System.Threading.Tasks.Task<bool> makeCheckInAsync(int ticketID) {
            return base.Channel.makeCheckInAsync(ticketID);
        }
        
        public bool changeSeat(int ticketID, string seat) {
            return base.Channel.changeSeat(ticketID, seat);
        }
        
        public System.Threading.Tasks.Task<bool> changeSeatAsync(int ticketID, string seat) {
            return base.Channel.changeSeatAsync(ticketID, seat);
        }
        
        public bool cancelReservation(string reservation) {
            return base.Channel.cancelReservation(reservation);
        }
        
        public System.Threading.Tasks.Task<bool> cancelReservationAsync(string reservation) {
            return base.Channel.cancelReservationAsync(reservation);
        }
        
        public bool cancelFlight(int flightID) {
            return base.Channel.cancelFlight(flightID);
        }
        
        public System.Threading.Tasks.Task<bool> cancelFlightAsync(int flightID) {
            return base.Channel.cancelFlightAsync(flightID);
        }
        
        public string makeAOneWayReservation(int departureFlightID, int clientID, string seatNumber) {
            return base.Channel.makeAOneWayReservation(departureFlightID, clientID, seatNumber);
        }
        
        public System.Threading.Tasks.Task<string> makeAOneWayReservationAsync(int departureFlightID, int clientID, string seatNumber) {
            return base.Channel.makeAOneWayReservationAsync(departureFlightID, clientID, seatNumber);
        }
        
        public string makeARoundTripReservation(int departureFlightID, int returnFlightID, int clientID, string departureSeatNumber, string returnSeatNumber) {
            return base.Channel.makeARoundTripReservation(departureFlightID, returnFlightID, clientID, departureSeatNumber, returnSeatNumber);
        }
        
        public System.Threading.Tasks.Task<string> makeARoundTripReservationAsync(int departureFlightID, int returnFlightID, int clientID, string departureSeatNumber, string returnSeatNumber) {
            return base.Channel.makeARoundTripReservationAsync(departureFlightID, returnFlightID, clientID, departureSeatNumber, returnSeatNumber);
        }
        
        public System.Data.DataSet getFlightById(int flightID) {
            return base.Channel.getFlightById(flightID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getFlightByIdAsync(int flightID) {
            return base.Channel.getFlightByIdAsync(flightID);
        }
        
        public System.Data.DataSet getFlightsDepartingHours(int hours) {
            return base.Channel.getFlightsDepartingHours(hours);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getFlightsDepartingHoursAsync(int hours) {
            return base.Channel.getFlightsDepartingHoursAsync(hours);
        }
        
        public System.Data.DataSet getTicketsOfFlight(int flightID) {
            return base.Channel.getTicketsOfFlight(flightID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getTicketsOfFlightAsync(int flightID) {
            return base.Channel.getTicketsOfFlightAsync(flightID);
        }
        
        public int newStaff(string userName, string password, string email, string firstName, string lastName, int airlineID) {
            return base.Channel.newStaff(userName, password, email, firstName, lastName, airlineID);
        }
        
        public System.Threading.Tasks.Task<int> newStaffAsync(string userName, string password, string email, string firstName, string lastName, int airlineID) {
            return base.Channel.newStaffAsync(userName, password, email, firstName, lastName, airlineID);
        }
        
        public System.Data.DataSet getStaff(int userID) {
            return base.Channel.getStaff(userID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getStaffAsync(int userID) {
            return base.Channel.getStaffAsync(userID);
        }
        
        public System.Data.DataSet getStaffofAirline(int airlineID) {
            return base.Channel.getStaffofAirline(airlineID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getStaffofAirlineAsync(int airlineID) {
            return base.Channel.getStaffofAirlineAsync(airlineID);
        }
        
        public System.Data.DataSet getAllAirlines() {
            return base.Channel.getAllAirlines();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getAllAirlinesAsync() {
            return base.Channel.getAllAirlinesAsync();
        }
        
        public int validateStaffLogin(string username, string password) {
            return base.Channel.validateStaffLogin(username, password);
        }
        
        public System.Threading.Tasks.Task<int> validateStaffLoginAsync(string username, string password) {
            return base.Channel.validateStaffLoginAsync(username, password);
        }
    }
}

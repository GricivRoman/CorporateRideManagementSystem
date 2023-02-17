namespace СorporateRideManagementSystem.Data.Entities
{
    public class RideReport
    {
        public int ID { get; set; }
        public int ReportMonth { get; set; }
        public int ReportYear { get; set; }

        public string PassengerFullName { get; set; }
        public string PassengerEmail { get; set; }


        public ICollection<Ride> Ride { get; set; }

        public string ReportStatus { get; set; }


    }
}

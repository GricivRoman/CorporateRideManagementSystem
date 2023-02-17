using FoodDiary.Data.Entities;

namespace СorporateRideManagementSystem.Data.Entities
{
    public class Ride
    {
        public int ID { get; set; }
        public int ReportMonth { get; set; }
        public int ReportYear{ get; set; }

        public string PassengerFullName { get; set;}
        public string PassengerEmail { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public DateTime RideTimeStart { get; set; }
        public string RideStartPlace { get; set; }

        public DateTime RideTimeFinish { get; set; }
        public string RideFinishPlace { get; set; }

        
        private double RideAmountField;

        public double RideAmount
        {
            get { return RideAmountField; }
            set { RideAmountField = Math.Round(value, 2); }
        }

        private double RideAmountVATField;

        public double RideAmountVAT
        {
            get { return RideAmountVATField; }
            set { RideAmountVATField = Math.Round(value,2); }
        }
        
        public bool PersonalDriveStatus { get; set; }
    }
}

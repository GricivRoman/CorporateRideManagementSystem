using FoodDiary.Data.Entities;

namespace СorporateRideManagementSystem.Data.Entities
{
    public class SystemSettingForEmployee
    {
        public int ID { get; set; }
        public double TimeToLockPersonalDriveStatus { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}

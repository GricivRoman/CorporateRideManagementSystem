using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using СorporateRideManagementSystem.Data.Entities;

namespace FoodDiary.Data.Entities
{
    public class Employee : IdentityUser
    {
        public string FuulName { get; set; }
        public SystemSettingForEmployee SystemSettingForEmployee { get; set; }
        
        [ForeignKey(nameof(SystemSettingForEmployee))]
        public int SystemSettingForEmployeeId { get; set; }
    }
}

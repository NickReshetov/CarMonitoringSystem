using System;
using System.ComponentModel.DataAnnotations;

namespace DataStorage.DataAccess.EntityFramework.Entities
{
    public class Car : BaseEntity
    {
        [Required] 
        public Guid CompanyId { get; set; }

        [Required]
        public string VinCode { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public DateTime LastConnectionTime { get; set; }

        
    }
}

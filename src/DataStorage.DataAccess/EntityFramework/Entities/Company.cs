using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataStorage.DataAccess.EntityFramework.Entities
{
    public class Company : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Car> Cars { get; set; }
    }

}

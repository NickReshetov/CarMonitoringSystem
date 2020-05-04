using System.Collections;
using System.Collections.Generic;

namespace DataStorage.Dtos
{
    public class CompanyDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<CarDto> Cars { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class GenerateApartment
    {
        
        public int QuantityByFloor { get; set; }
        public int Floor { get; set; }
        public int TowerId { get; set; }
        public int CondominiumId { get; set; }
    }
}

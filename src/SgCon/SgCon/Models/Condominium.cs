using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Condominium : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Cnpj { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DDDComercialPhone { get; set; }
        [Required]
        public string ComercialPhone { get; set; }
        public string DDDCellPhone { get; set; }
        public string CellPhone { get; set; }
        [Required]
        public int TowerNumber { get; set; }

        public ICollection<Tower> Tower { get; set; }

        public ICollection<CommonArea> CommonArea { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}

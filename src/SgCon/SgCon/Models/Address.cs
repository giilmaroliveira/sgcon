﻿using Newtonsoft.Json;
using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Address : BaseModel
    {
        [NotMapped]
        [JsonIgnore]
        public AddressType AddressType { get; set; }

        public int AddressTypeId { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        [Required]
        public string Neighborhood { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string UF { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Condominium> Condominium { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Company> Company { get; set; }

        [NotMapped]
        [JsonIgnore]
        public ICollection<Employee> Employee { get; set; }
    }
}

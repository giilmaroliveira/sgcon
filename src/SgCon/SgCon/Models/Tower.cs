﻿using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Tower : BaseModel
    {
        [Required]
        public string Block { get; set; }
        public int CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
        public int ApartmentNumber { get; set; }
        public ICollection<Apartment> Apartment { get; set; }
    }
}

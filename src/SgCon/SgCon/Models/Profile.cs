using Newtonsoft.Json;
using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Profile : BaseModel
    {
        public Profile()
        {
            this.ProfilePolicies = new List<ProfilePolicy>();
        }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int RoleId { get; set; }

        [JsonIgnore]
        [Required]
        public Role Role { get; set; }

        public virtual ICollection<ProfilePolicy> ProfilePolicies { get; set; }

        [NotMapped]
        public ICollection<Policy> Policies { get; set; }
    }
}

using SgConAPI.Models.Base;
using SgConAPI.Repository.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Policy : BaseModel
    {
        public Policy()
        {
            this.ProfilePolicies = new List<ProfilePolicy>();
        }

        public int? IdParent { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Alias { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public PolicyTypeEnum Type { get; set; }

        public virtual ICollection<ProfilePolicy> ProfilePolicies { get; set; }
    }
}

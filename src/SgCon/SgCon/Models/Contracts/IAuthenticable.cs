using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models.Contracts
{
    public interface IAuthenticable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }

        [Required]
        string Name { get; set; }

        [JsonIgnore]
        Profile Profile { get; set; }

        int ProfileId { get; set; }

        [Required]
        string UserName { get; set; }

        [Required]
        string PassWord { get; set; }

        [JsonIgnore]
        DateTime? ExpiredAt { get; set; }

        string ClassType { get; }
    }
}

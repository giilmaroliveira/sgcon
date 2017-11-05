using SgConAPI.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class ApplicationUser : IAuthenticable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public string ClassType { get; set; }
    }
}

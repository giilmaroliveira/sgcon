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
        public string Nome { get; set; }
        public Perfil Perfil { get; set; }
        public int PerfilId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public string ClassType { get; set; }
    }
}

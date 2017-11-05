using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models.Base
{
    public abstract class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime CriadoEm { get; set; }

        public DateTime? AtualizadoEm { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [JsonIgnore]
        public DateTime? ExcluidoEm { get; set; }

        [Required]
        public string CriadoPor { get; set; }

        public string AtualizadoPor { get; set; }
    }
}

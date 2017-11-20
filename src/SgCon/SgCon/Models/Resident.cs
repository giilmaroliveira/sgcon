using Newtonsoft.Json;
using SgConAPI.Models.Base;
using SgConAPI.Utils;
using SgConAPI.Utils.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Resident : BaseModel
    {
        [Required]
        public string Name { get; set; }

        private string _cpf;
        [Required]
        [CpfAttributeValidation]
        [RegularExpression(@"\d+", ErrorMessage = "Somente números")]
        public string CPF
        {
            get { return this._cpf; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._cpf = value.FormatStringDocument();
                }
            }
        }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PassWord { get; set; }

        [NotMapped]
        public string ClassType { get => "Funcionario"; }

        [JsonIgnore]
        public Profile Profile { get; set; }

        public int ProfileId { get; set; }
    }
}

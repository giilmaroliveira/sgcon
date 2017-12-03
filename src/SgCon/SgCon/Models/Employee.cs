using Newtonsoft.Json;
using SgConAPI.Models.Base;
using SgConAPI.Models.Contracts;
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
    public class Employee : BaseModel, IAuthenticable
    {
        [JsonIgnore]
        public Profile Profile { get; set; }

        public int ProfileId { get; set; }

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

        [Required]
        public string JobRole { get; set; }

        public DateTime? ExpiredAt { get; set; }

        [NotMapped]
        public string ClassType { get => "Funcionario"; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
        [Required]
        public string DDDComercialPhone { get; set; }
        [Required]
        public string ComercialPhone { get; set; }
        public string DDDCellPhone { get; set; }
        public string CellPhone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Utils.Validations
{
    public class CpfAttributeValidation : ValidationAttribute
    {
        public CpfAttributeValidation()
        {
            this.ErrorMessage = "{0} não é um CPF válido";
        }

        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            if (value != null)
            {
                this.ErrorMessage = "{0} não é um CPF válido";
                var valueValidLength = 11;
                var maskChars = new[] { ".", "-" };
                var multipliersForFirstDigit = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                var multipliersForSecondDigit = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                var docIdHelper = new DocIdHelper();
                var isValid = docIdHelper.IsValid(value.ToString(), valueValidLength, maskChars, multipliersForFirstDigit, multipliersForSecondDigit);

                if (!isValid)
                {
                    return new ValidationResult(this.FormatErrorMessage(value.ToString()));
                }
            }

            return null;
        }
    }
}

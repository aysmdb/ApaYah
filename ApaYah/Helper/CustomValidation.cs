using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApaYah.Helper
{
    public class MustHaveWordAttribute : ValidationAttribute
    {
        public MustHaveWordAttribute(string word)
        {
            Word = word;
        }

        public string Word { get; }

        public string GetErrorMessage() => $"Ga ada kata {Word}nya.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var title = value.ToString();

            if (!title.Contains(Word))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}

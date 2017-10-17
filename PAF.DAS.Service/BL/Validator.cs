using PAF_Document_Archieving_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PAF_Document_Archieving_System.BL
{
    public class PaperValidator<T> where T:Paper
    {
        public virtual bool ValidateInput(T obj)
        {
            bool validationResult = false;
            ValidationContext context = new ValidationContext(obj, null, null);
            var errors = new List<ValidationResult>();
            var result = Validator.TryValidateObject(obj, context, errors, true);

            if (!result)
            {
                Console.Write("\nErrors: \n");
                foreach (var error in errors)
                {
                    Console.Write(error.ErrorMessage+"\n");
                }
                validationResult = false;
            }
            else
            {                
                validationResult = true;
            }
            return validationResult;
        }
    }
}

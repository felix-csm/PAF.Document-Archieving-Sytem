using PAF.DAS.Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PAF.DAS.Service.BL
{
    public class PaperValidator<T>
    {
        public virtual bool ValidateInput(T obj)
        {
            //bool validationResult = false;
            ValidationContext context = new ValidationContext(obj);
            var errors = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, context, errors, true);

            //if (!result)
            //{
            //    //Console.Write("\nErrors: \n");
            //   // foreach (var error in errors)
            //  //  {
            //   //     Console.Write(error.ErrorMessage+"\n");
            //   // }
            //    validationResult = false;
            //}
            //else
            //{                
            //    validationResult = true;
            //}
            //return validationResult;
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); // ben Product türünde nesneye validate işlemi yapacağım
            var result = validator.Validate(context); // validation yapıldı

            if (!result.IsValid) // gelen nesne validation işlemini geçemedi.
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

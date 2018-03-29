using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> TryValidate (object value )
        {
            var context = new ValidationContext(value);
            var errors = new Collection<ValidationResult>();

            Validator.TryValidateObject(value, context, errors, true);
            return errors;
        }

        public static void Validate ( this IValidatableObject source )
        {
            var context = new ValidationContext(source);
            Validator.ValidateObject(source, context, true);
        }
    }
}

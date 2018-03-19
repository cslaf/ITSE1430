using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeSchlaefli.ToDo
{
    /// <summary> Provides support for data validation </summary>
    public static class ObjectValidator
    {
        //takes an object with IvalidatableObject Implemented and validates it
        public static IEnumerable<ValidationResult> Validate (object value )
        {
            var context = new ValidationContext(value);
            var errors = new Collection<ValidationResult>();
            Validator.TryValidateObject(value, context, errors, true);

            return errors;
        }
    }
}

﻿/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 3/11/2018
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeSchlaefli.MovieLib
{
    /// <summary> Provides support for data validation </summary>
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate ( this IValidatableObject source )
        {
            var context = new ValidationContext(source);
            var errors = new Collection<ValidationResult>();
            Validator.TryValidateObject(source, context, errors, true);

            return errors;
        }
    }
}

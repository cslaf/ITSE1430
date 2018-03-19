/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 3/11/2018
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeSchlaefli.MovieLib
{
    /// <summary>Provides info about a Movie. </summary>
    public class Movie : IValidatableObject
    {
        public int Id { get; set; }
        /// <summary>Title of the Movie. </summary>
        public string Title { get; set; } = "";
        /// <summary>Description of the Movie. </summary>
        public string Description { get; set; }
        /// <summary>Length of the Movie in Minutes. </summary>
        public int Length { get; set; }
        /// <summary>If the Movie is owned. </summary>
        public bool IsOwned { get; set; }

        /// <summary>Checks input to see if valid</summary>
        /// <returns>Error message or ""</returns>
        public string Validate()
        {
            if (String.IsNullOrEmpty(Title))
                return "Title cannot be empty";
            if (Length < 0)
                return "Length must be empty or >= 0";
            return "";
        }
        /// <summary>Validate the Movie.</summary>
        /// <param name="validationContext">The validation context</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Title))
                errors.Add(new ValidationResult("Title cannot be empty", new[] { nameof(Title) }));

            if (Length < 0)
                errors.Add(new ValidationResult("Length must be <= 0", new[] { nameof(Length) }));

            return errors;
        }

    }
}

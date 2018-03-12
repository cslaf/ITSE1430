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

namespace CadeSchlaefli.ToDo
{
    [Serializable]
    /// <summary>Provides info about a movie. </summary>
    public class ToDoItem : IValidatableObject
    {
        public int Id { get; set; }
        /// <summary>Title of the ToDoItem. </summary>
        public string Title { get; set; } = "";
        /// <summary> Priority of ToDoItem, can be negative, defaults to 0 </summary>
        public int Priority { get; set; } = 0;
        /// <summary>Description of the ToDoItem. </summary>
        public string Description { get; set; }
        /// <summary>DueDate of the ToDoItem in Minutes. </summary>
        public DateTime DueDate { get; set; } = DateTime.Now;
        /// <summary>If the item is completed. </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Validate the Product.
        /// </summary>
        /// <param name="validationContext">The validation context</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            var errors = new List<ValidationResult>();

            if (String.IsNullOrEmpty(Title))
                errors.Add(new ValidationResult("Title cannot be empty", new[] { nameof(Title) }));

            if (DueDate < DateTime.Now)
                errors.Add(new ValidationResult("DueDate must be in the future", new[] { nameof(DueDate) }));

            return errors;
        }

    }
}

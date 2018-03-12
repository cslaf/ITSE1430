/*
 * Author: Cade Schlaefli
 * Course: ITSE-1430-21722
 * Date: 3/11/2018
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeSchlaefli.ToDo.Data
{
    /// <summary> Interface for adding, updating, getting and removing movies from database </summary>
    interface ITodoDatabase
    {
        /// <summary>Add a new ToDoItem. </summary>
        /// <param name="movie"> The ToDoItem to add.</param>
        /// <param name="message"> Error Message.</param>
        /// <returns>The added movie</returns>
        /// <remarks>Returns an error if ToDoItem is null, invalid or if already exists in database. </remarks>
        ToDoItem Add( ToDoItem movie, out string message );
        /// <summary>Update an exisiting ToDoItem.</summary>
        /// <param name="movie">The ToDoItem to update.</param>
        /// <param name="message">Error Message. </param>
        /// <returns>The updated product.</returns>
        /// <remarks> Returns an error if ToDoItem is null, invalid, or cannot be found. </remarks>
        ToDoItem Update( ToDoItem movie, out string message );
        /// <summary> Gets all ToDoItem.</summary>
        /// <returns>The list of Movies as enumerable</returns>
        IEnumerable<ToDoItem> GetAll();
        /// <summary> Removes a ToDoItem by ID.</summary>
        /// <param name="id">The ToDoItem ID.</param>
        void Remove( int id );

    }
}

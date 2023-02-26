using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    /*
     * This code defines a data transfer object (DTO) called "CategoryDTO".
     * A DTO is a simple class that is used to transfer data between different 
     * parts of an application, such as between the data access layer and the presentation layer.
     * DTOs typically contain only data and no behavior or business logic.
     * 
     */
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter name..")]
        public string Name { get; set; }
    }
}

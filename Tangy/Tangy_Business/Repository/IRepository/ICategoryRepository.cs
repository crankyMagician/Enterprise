using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    /*
     * This code defines an interface called "ICategoryRepository" 
     * which represents a contract for interacting with a data store 
     * that contains CategoryDTO objects. This interface follows the Repository 
     * design pattern.The Repository pattern is a design pattern that mediates 
     * between the data access layer and the business logic layer of an application. 
     * It provides an abstraction of the data access layer and allows the application
     * to interact with the data store using a set of predefined methods.
     * 
     * This code defines an interface called "ICategoryRepository" which specifies the
     * contract for working with category data in the application.

        This interface declares five methods:

            Create: Takes a CategoryDTO object as input and returns a Task of CategoryDTO as output. 
            This method creates a new category in the database.

            Update: Takes a CategoryDTO object as input and returns a Task of CategoryDTO as output.
            This method updates an existing category in the database.

            Delete: Takes an integer ID as input and returns a Task of integer as output. 
            This method deletes a category from the database.

            Get: Takes an integer ID as input and returns a Task of CategoryDTO as output. 
            This method retrieves a category from the database by ID.

            GetAll: Takes no input and returns a Task of IEnumerable of CategoryDTO as output. 
            This method retrieves all categories from the database.
     */
    public interface ICategoryRepository
    {

        public Task<CategoryDTO> Create(CategoryDTO objDTO);
        public Task<CategoryDTO> Update(CategoryDTO objDTO);
        public Task<int> Delete(int id);
        public Task<CategoryDTO> Get(int id);
        public Task<IEnumerable<CategoryDTO>> GetAll();
    }
}

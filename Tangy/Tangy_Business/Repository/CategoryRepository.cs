using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDBContext _db;

        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /*
         * This code defines a method called "Create" which takes a CategoryDTO 
         * object as input and returns a CategoryDTO object as output. The purpose 
         * of this method is to create a new category in the database and return a 
         * CategoryDTO object representing the created category.
         */
       public async Task<CategoryDTO> Create(CategoryDTO objDTO)
       {
            // Map the input CategoryDTO to a Category entity
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
            obj.CreatedDate = DateTime.Now;
            // Add the newly created Category entity to the database context
            var addedObj = _db.Categories.Add(obj);
            // Save changes to the database
            await _db.SaveChangesAsync();
            // Map the created Category entity back to a CategoryDTO and return it
            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        /*
         * This code defines a method called "Delete" which takes an integer
         * ID as input and returns an integer value as output. The purpose of this
         * method is to delete a category from the database.
         * 
         */
        public async Task<int> Delete(int id)
        {
            // Find the category entity with the given id
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);

            // If the category exists, remove it from the database
            if (obj != null)
            {
                _db.Categories.Remove(obj);

                // Save changes to the database and return the number of rows affected
                return await _db.SaveChangesAsync();
            }

            // If the category does not exist, return 0
            return 0;
        }

        /*
         * This code defines a method called "Get" which takes an 
         * integer ID as input and returns a CategoryDTO object as output. 
         * The purpose of this method is to retrieve a category from the database
         * and return it as a CategoryDTO object.
         * 
         */
        public async Task<CategoryDTO> Get(int id)
        {
            // Find the category entity with the given id
            var obj = await _db.Categories.FirstOrDefaultAsync(u => u.Id == id);

            // If the category exists, map it to a CategoryDTO and return it
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }

            // If the category does not exist, return an empty CategoryDTO object
            return new CategoryDTO();
        }

        /*
         * This code defines a method called "GetAll" which returns an IEnumerable
         * of CategoryDTO objects. The purpose of this method is to retrieve all categories 
         * from the database and return them as CategoryDTO objects.
         */
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            // Map all category entities to CategoryDTO objects and return them
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        /*
         * This code defines a method called "Update" which takes a CategoryDTO object as input and 
         * returns a CategoryDTO object as output. The purpose of this method is to update a category 
         * in the database and return a CategoryDTO object representing the updated category.
         */
        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            // Find the category entity with the same ID as the input CategoryDTO
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(u => u.Id == objDTO.Id);

            // If the category entity exists, update its properties and save the changes to the database
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();

                // Map the updated category entity to a CategoryDTO and return it
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }

            // If the category entity does not exist, return the input CategoryDTO object as is
            return objDTO;
        }

    }
}

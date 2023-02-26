using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_DataAccess;
using Tangy_Models;

namespace Tangy_Business.Mapper
{
    public class MappingProfile: Profile  
    {
        /*
         * This means that AutoMapper can automatically map 
         * from a Category entity to a CategoryDTO and vice versa. 
         * This makes it easier to move data between layers of an application 
         * without having to manually map each field between the two objects.
         * Automapper is required to create this method 
         */
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
        
    }
}

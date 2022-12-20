using Shoper.BusinessLogic.Interface;
using Shoper.Data.Interface;
using Shoper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.BusinessLogic.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository category_Repository;
        public CategoryService(ICategoryService categoryRepository)
        {
            this.category_Repository = (ICategoryRepository?)categoryRepository;
        }
        public Category Add(Category entity)
        {
            return category_Repository.Add(entity); 
        }

        public Category Delete(Category entity)
        {
            return category_Repository.Delete(entity);
        }

        public Category Get(int id)
        {
            return category_Repository.GetbyId(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return category_Repository.GetAll();    
        }

        public IEnumerable<Category> GetExp(Expression<Func<Category, bool>> predicate)
        {
            return category_Repository.GetExp(predicate);
        }

        public Category Update(Category entity)
        {
            return category_Repository.Update(entity);  
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Repositories.Implementation;

namespace MidAssignment.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private CategoryRepository _categoryRepository;
        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Create(CategoryDTO category)
        {
            return await  _categoryRepository.Create(category);
        }

        public bool Delete(Category category)
        {
           return _categoryRepository.Delete(category);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetOne(int id)
        {
            return _categoryRepository.GetOne(id);
        }

         public async Task<Category> Update(CategoryDTO category)
        {
            return await _categoryRepository.Update(category);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Repositories;
using MidAssignment.Repositories.Implementation;

namespace MidAssignment.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> Create(CategoryDTO category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
            };

            return await _categoryRepository.Create(newCategory);
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
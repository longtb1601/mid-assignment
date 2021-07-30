using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;

namespace MidAssignment.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        protected readonly LibraryContext _libraryContext;

        public CategoryRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public Category GetOne(int id)
        {
            try
            {
                return _libraryContext.Categories.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public IEnumerable<Category> GetAll()
        {
            try
            {
                return _libraryContext.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Category> Create(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category entity must not be null");
            }

            try
            {
                await _libraryContext.Categories.AddAsync(category);

                await _libraryContext.SaveChangesAsync();

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception($"Category could not be saved: {ex.Message}");
            }
        }

        public async Task<Category> Update(CategoryDTO category)
        {
            var categoryEdit = this.GetOne(category.Id);

            if (category == null)
            {
                throw new ArgumentNullException("Category entity must not be null");
            }

            if(categoryEdit == null)
            {
                throw new ArgumentNullException("Category is not exist");
            }

            using var transaction = _libraryContext.Database.BeginTransaction();

            try
            {
                categoryEdit.Name = category.Name;

                await _libraryContext.SaveChangesAsync();

                transaction.Commit(); 

                return categoryEdit;
            }
            catch (Exception ex)
            {
                throw new Exception($"Category could not be updated: {ex.Message}");
            }
        }

        public bool Delete(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("Category entity must not be null");
            }

            using var transaction = _libraryContext.Database.BeginTransaction();

            try
            {
                _libraryContext.Categories.Remove(category);

                _libraryContext.SaveChanges();

                transaction.Commit(); 

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete category: {ex.Message}");
            }
        }
    }
}
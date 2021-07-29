using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Services.Implementation;

namespace MidAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/category")]
        public IEnumerable<Category> GetAll()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("/category/{id}")]
        public ActionResult<Category> GetOne(int id)
        {
            return _categoryService.GetOne(id);
        }

        [HttpPost("/category")]
        public async Task<Category> Create(CategoryDTO category)
        {
            return await _categoryService.Create(category);
        }

        [HttpPut("/category")]
        public async Task<Category> Update(CategoryDTO category)
        {
            return await _categoryService.Update(category);
        }

        [HttpDelete("/category/{id}")]
        public IActionResult Delete(int id)
        {
            var categoryDelete = _categoryService.GetOne(id);

            if(categoryDelete == null)
            {
                return NotFound();
            }

            try
            {
                _categoryService.Delete(categoryDelete);

                return Ok();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
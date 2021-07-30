using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidAssignment.Models.DTO;
using MidAssignment.Services;

namespace MidAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_categoryService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            try
            {
                return Ok(_categoryService.GetOne(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new {message = "The category is invalid"});
            }

            try
            {
                return Ok(await _categoryService.Create(category));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(CategoryDTO category)
        {
            try
            {
                return Ok(await _categoryService.Update(category));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var catDelete = _categoryService.GetOne(id);

                if(catDelete == null)
                {
                    return NotFound(new { message = "Category is not exist"});
                }

                _categoryService.Delete(catDelete);

                return Ok(new { message = "Category deleted successfully"});

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }
    }
}
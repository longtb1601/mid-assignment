using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MidAssignment.Models.DTO;
using MidAssignment.Services;

namespace MidAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_bookService.GetAll());
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
                return Ok(_bookService.GetOne(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "The book is invalid" });
            }

            try
            {
                return Ok(await _bookService.Create(book));
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(BookDTO book)
        {
            try
            {
                return Ok(await _bookService.Update(book));
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
                var bookDelete = _bookService.GetOne(id);

                if (bookDelete == null)
                {
                    return NotFound(new { message = "Book is not exist"});
                }

                _bookService.Delete(bookDelete);

                return Ok(new { message = "Book deleted successfully"});

            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message});
            }
        }
    }
}
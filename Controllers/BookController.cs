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
    public class BookController : ControllerBase
    {
        private BookService _bookService;
        
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("/book")]
        public IEnumerable<Book> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpGet("/book/{id}")]
        public ActionResult<Book> GetOne(int id)
        {
            return _bookService.GetOne(id);
        }

        [HttpPost("/book")]
        public async Task<Book> Create(BookDTO book)
        {
            return await _bookService.Create(book);
        }

        [HttpPut("/book")]
        public async Task<Book> Update(BookDTO book)
        {
            return await _bookService.Update(book);
        }

        [HttpDelete("/book/{id}")]
        public IActionResult Delete(int id)
        {
            var bookDelete = _bookService.GetOne(id);

            if(bookDelete == null)
            {
                return NotFound();
            }

            try
            {
                _bookService.Delete(bookDelete);

                return Ok();

            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
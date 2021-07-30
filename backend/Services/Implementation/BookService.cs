using System.Collections.Generic;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Repositories;
using MidAssignment.Repositories.Implementation;

namespace MidAssignment.Services.Implementation
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Create(BookDTO book)
        {
            var newBook = new Book
            {
                Name = book.Name,
                CategoryId = book.CategoryId,
            };

            return await _bookRepository.Create(newBook);
        }

        public bool Delete(Book book)
        {
            return _bookRepository.Delete(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Book GetOne(int id)
        {
            return _bookRepository.GetOne(id);
        }

        public async Task<Book> Update(BookDTO book)
        {
            return await _bookRepository.Update(book);
        }
    }
}
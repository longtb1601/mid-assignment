using System.Collections.Generic;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;
using MidAssignment.Repositories.Implementation;

namespace MidAssignment.Services.Implementation
{
    public class BookService : IBookService
    {
        private BookRepository _bookRepository;

        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Create(BookDTO book)
        {
            return await  _bookRepository.Create(book);
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
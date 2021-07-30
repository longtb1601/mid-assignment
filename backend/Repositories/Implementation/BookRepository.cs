using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MidAssignment.Models;
using MidAssignment.Models.DTO;

namespace MidAssignment.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        protected readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public Book GetOne(int id)
        {
            try
            {
                return _libraryContext.Books.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public IEnumerable<Book> GetAll()
        {
            try
            {
                return _libraryContext.Books.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Book> Create(Book book)
        {
            try
            {
                await _libraryContext.Books.AddAsync(book);

                await _libraryContext.SaveChangesAsync();

                return book;
            }
            catch (Exception ex)
            {
                throw new Exception($"Book could not be saved: {ex.Message}");
            }
        }

        public async Task<Book> Update(BookDTO book)
        {
            var bookEdit = this.GetOne(book.Id);

            if (book == null)
            {
                throw new ArgumentNullException("Book entity must not be null");
            }

            if(bookEdit == null)
            {
                throw new Exception("Book is not exist");
            }

            using var transaction = _libraryContext.Database.BeginTransaction();

            try
            {
                bookEdit.Name = book.Name;

                bookEdit.CategoryId = book.CategoryId;

                await _libraryContext.SaveChangesAsync();

                transaction.Commit(); 

                return bookEdit;
            }
            catch (Exception ex)
            {
                throw new Exception($"Book could not be updated: {ex.Message}");
            }
        }

        public bool Delete(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Book entity must not be null");
            }

            using var transaction = _libraryContext.Database.BeginTransaction();

            try
            {
                _libraryContext.Books.Remove(book);

                _libraryContext.SaveChanges();

                transaction.Commit(); 

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete book: {ex.Message}");
            }
        }
    }
}
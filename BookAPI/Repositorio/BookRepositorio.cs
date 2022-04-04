using BookAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Repositorio
{
    public class BookRepositorio : IBookRepositorio
    {
        public readonly BookContext _context;
        public BookRepositorio(BookContext context)
        {
            _context = context;
        }
        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int Id)
        {
            var BookToDelete = await _context.Books.FindAsync(Id);
            _context.Books.Remove(BookToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int Id)
        {
            return await _context.Books.FindAsync(Id);
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

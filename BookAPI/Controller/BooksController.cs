using BookAPI.Model;
using BookAPI.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepositorio _bookRepositorio;

        public BooksController(IBookRepositorio bookRepositorio)
        {
            _bookRepositorio = bookRepositorio;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookRepositorio.Get();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBooks(int Id)
        {
            return await _bookRepositorio.Get(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookRepositorio.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { Id = newBook.Id }, newBook);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var bookToDelete = await _bookRepositorio.Get(Id);
            if (bookToDelete == null)
            return NotFound();
            await _bookRepositorio.Delete(bookToDelete.Id);
            return NoContent(); 
        }
        [HttpPut]
        public async Task<ActionResult> PutBooks(int Id,[FromBody] Book book)
        {
            if (Id != book.Id)
            return BadRequest();
            await _bookRepositorio.Update(book);
            return NoContent();
        }
    }
}

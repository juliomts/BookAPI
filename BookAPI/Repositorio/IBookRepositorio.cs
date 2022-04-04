using BookAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Repositorio
{
    public interface IBookRepositorio
    {
        Task<IEnumerable<Book>> Get();//listar todo mundo

        Task<Book> Get(int Id);//Buscar pelo id

        Task<Book> Create(Book book);

        Task Update(Book book);

        Task Delete(int Id);
    }
}

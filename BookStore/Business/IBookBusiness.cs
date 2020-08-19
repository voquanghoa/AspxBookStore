using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Business
{
    public interface IBookBusiness
    {
        Task<List<Book>> GetList();

        Task<Book> GetBook(int id);

        Task Update(Book book);

        Task<Book> Create(Book book);

        Task Delete(int id);
    }
}

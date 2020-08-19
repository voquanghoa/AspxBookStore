using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Business
{
    public class BookBusiness: IBookBusiness
    {
        private readonly BookStoreContext context;

        public BookBusiness(BookStoreContext context)
        {
            this.context = context;
        }

        public async Task<List<Book>> GetList()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Book book)
        {
            if (await context.Books.FirstOrDefaultAsync(x => x.Id == book.Id) is {} existing)
            {
                existing.Name = book.Name;
                existing.Description = book.Description;

                context.Entry(existing).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task<Book> Create(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task Delete(int id)
        {
            if (await context.Books.FirstOrDefaultAsync(x => x.Id == id) is {} existing)
            {

                context.Entry(existing).State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
    }
}

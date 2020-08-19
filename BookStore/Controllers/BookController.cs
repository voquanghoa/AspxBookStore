using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Business;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/books")]
    public class BookController: ControllerBase
    {

        private readonly IBookBusiness business;

        public BookController(IBookBusiness business)
        {
            this.business = business;
        }


        [HttpGet]
        public async Task<List<Book>> Get()
        {
            return await business.GetList();
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<Book> Get(int id)
        {
            return await business.GetBook(id);
        }

        [HttpPost]
        public async Task<Book> Create([FromBody] Book newBook)
        {
            return await business.Create(newBook);
        }

        [HttpPut]
        public async Task Update([FromBody] Book newBook)
        {
            await business.Update(newBook);
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task  Delete(int id)
        {
            await business.Delete(id);
        }
    }
}

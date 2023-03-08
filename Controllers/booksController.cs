using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
        // GET: api/books
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Book> Get()
        {
            IGetAllBooks readObject = new ReadBookData();
            return readObject.GetAllBooks();
        }

        // GET: api/books/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Book Get(int id)
        {
            IGetBook readObject = new ReadBookData();
            return readObject.GetBook(id);
        }

        // POST: api/books
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            IInsertBook insertObject = new SaveBook();
            insertObject.InsertBook(value);
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

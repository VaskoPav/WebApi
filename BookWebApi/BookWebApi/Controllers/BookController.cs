using BookWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            return StatusCode(StatusCodes.Status200OK, StaticDb.Books);
        }

        //http://localhost:39683/api/book/queryIndex?book=it
        //http://localhost:39683/api/book/queryIndex?book=0
        [HttpGet("queryIndex")]
        public ActionResult GetByString(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Try again");
                }
                if (id >= StaticDb.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound,"Book not found");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDb.Books[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //http://localhost:39683/api/book/multipleQuery?author=Stephen%20King&%20title=It
        [HttpGet("multipleQuery")]
        public ActionResult<Book> GetMultipleQuery(string author, string title)
        {
            try
            {
                if(string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                if (string.IsNullOrEmpty(author))
                {
                    Book book = StaticDb.Books.FirstOrDefault(x => x.Title.Contains(title));
                    if (book == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "Book not found");
                    }
                    return StatusCode(StatusCodes.Status200OK, book);
                }
                if (string.IsNullOrEmpty(title))
                {
                    Book book = StaticDb.Books.FirstOrDefault(x => x.Author.Equals(author));
                    if (book == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "Book not found");
                    }
                    return StatusCode(StatusCodes.Status200OK, book);
                }
                Book books = StaticDb.Books.FirstOrDefault(x => x.Author.Equals(author) && x.Title.Equals(title));
                if (books == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Book not found");
                }
                return StatusCode(StatusCodes.Status200OK, books);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpPost("postBook")]

        ////http://localhost:39683/api/book/postbook 
        
        public IActionResult PostNote([FromBody] Book book)
        {
            try
            {
                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "Note added!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

      
        }

    }
}

using QronosBookTest.Models;
using QronosBookTest.SortingClasses;
using QronosBookTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QronosBookTest.Controllers
{
    // Tillåter CORS för olika frontend 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]/[action]")]

    public class BooksController : ApiController
    {
        Logic logic = new Logic();
        Book book = new Book();

        // Sortering
        SortById sortById = new SortById();
        SortByAuthor sortByAuthor = new SortByAuthor();
        SortByTitle sortByTitle = new SortByTitle();
        SortByGenre sortByGenre = new SortByGenre();
        SortByPrice sortByPrice = new SortByPrice();
        SortByPublishDate sortByPublishDate = new SortByPublishDate();
        SortByDescription sortByDescription = new SortByDescription();


        /* ------ ID delen ------ */

        // Hämta alla böcker 
        [HttpGet]
        [Route("Api/Books/GetBooks")]
        public IHttpActionResult GetBooks()
        {
            var books = logic.BooksList;

            if(book == null)
            {
                return NotFound();
            }

            return Ok(books.ToList());
        }

        // Hämta en bok efter Id inmatning
        [HttpGet]
        [Route("Api/Books/GetBook/{id}")]
        public IHttpActionResult GetBook(string id)
        {
            var book = logic.BooksList.Where(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            else if(id == null)
            {
                return BadRequest("Incorrect ID");
            }

            return Ok(book);
        }

        // Hämta en bok om Id:et innehåller sökningen eller del av sökningen
        [HttpGet]
        [Route("Api/Books/Id/{id}")]
        public IHttpActionResult Id(string id)
        {
            var books = logic.BooksList;
            List<Book> ContainsId = books.FindAll(b => b.Id.Contains(id));

            if(ContainsId == null)
            {
                return NotFound();
            }

            else if (ContainsId.Count() == 0)
            {
                return BadRequest("No ID matching the search");
            }

            else if(id == null)
            {
                return BadRequest("Incorrect ID");
            }

            ContainsId.Sort(sortById);

            return Ok(ContainsId);
        }




        /* ------ AUTHOR delen ------ */

        // Hämtar alla böcker sorterade efter author
        [HttpGet]
        [Route("Api/Books/Author")]
        public IHttpActionResult Author()
        {
            List<Book> BooksByAuthorName = logic.BooksList;

            if(BooksByAuthorName == null)
            {
                return NotFound();
            }

            BooksByAuthorName.Sort(sortByAuthor);

            return Ok(BooksByAuthorName);
        }

        // Hämtar böcker som innehåller author sökningen. Hela namnet eller del av det.
        [HttpGet]
        [Route("Api/Books/Author/{author}")]
        public IHttpActionResult Author(string author)
        {
            string authorInputToLower = author.ToLower();

            List<Book> ContainsAuthor = logic.BooksList.FindAll(b => b.Author.ToLower().Contains(authorInputToLower));

            if(ContainsAuthor == null)
            {
                return NotFound();
            }

            else if (ContainsAuthor.Count() == 0)
            {
                return BadRequest("No Author name matching the search");
            }

            else if(authorInputToLower == null)
            {
                return BadRequest("Incorrect author name");
            }

            ContainsAuthor.Sort(sortByAuthor);

            return Ok(ContainsAuthor);
        }




        /* ------ TITLE delen ------ */

        // Hämtar alla böcker sorterade efter title
        [HttpGet]
        [Route("Api/Books/Title")]
        public IHttpActionResult Title()
        {
            List<Book> BooksByTitle = logic.BooksList;

            if (BooksByTitle == null)
            {
                return NotFound();
            }

            BooksByTitle.Sort(sortByTitle);

            return Ok(BooksByTitle);
        }

        // Hämtar böcker som innehåller title sökningen. Hela title eller del av det.
        [HttpGet]
        [Route("Api/Books/Title/{title}")]
        public IHttpActionResult Title(string title)
        {
            string titleInputToLower = title.ToLower();

            List<Book> ContainsTitle = logic.BooksList.FindAll(b => b.Title.ToLower().Contains(titleInputToLower));

            if (ContainsTitle == null)
            {
                return NotFound();
            }

            else if (ContainsTitle.Count() == 0)
            {
                return BadRequest("No title matching the search");
            }

            else if (titleInputToLower == null)
            {
                return BadRequest("Incorrect author name");
            }

            ContainsTitle.Sort(sortByTitle);

            return Ok(ContainsTitle);
        }



        /* ------ Genre delen ------ */
        
        // Hämtar alla böcker sorterade efter Genre
        [HttpGet]
        [Route("Api/Books/Genre")]
        public IHttpActionResult Genre()
        {
            List<Book> BooksByGenre = logic.BooksList;

            if (BooksByGenre == null)
            {
                return NotFound();
            }

            BooksByGenre.Sort(sortByGenre);

            return Ok(BooksByGenre);
        }

        // Hämtar böcker som innehåller genre sökningen. Hela genre eller del av det.
        [HttpGet]
        [Route("Api/Books/Genre/{genre}")]
        public IHttpActionResult Genre(string genre)
        {
            string genreInputToLower = genre.ToLower();

            List<Book> ContainsGenre = logic.BooksList.FindAll(b => b.Genre.ToLower().Contains(genreInputToLower));

            if (ContainsGenre == null)
            {
                return NotFound();
            }

            else if (genreInputToLower == null)
            {
                return BadRequest("Incorrect author name");
            }

            ContainsGenre.Sort(sortByGenre);

            return Ok(ContainsGenre);
        }



        /* ------ Price delen ------ */

        // Hämtar alla böcker sorterade efter Price
        [HttpGet]
        [Route("Api/Books/Price")]
        public IHttpActionResult Price()
        {
            List<Book> BooksByPrice = logic.BooksList;

            if (BooksByPrice == null)
            {
                return NotFound();
            }

            BooksByPrice.Sort(sortByPrice);

            return Ok(BooksByPrice);
        }

        // Hämtar böcker som innehåller price sökningen. Hela price eller del av det.
        [HttpGet]
        [Route("Api/Books/Price/{price}")]
        public IHttpActionResult Price(double price)
        {
            var ContainsPrice = logic.BooksList.Where(b => b.Price == price).ToList();

            if (ContainsPrice == null)
            {
                return NotFound();
            }

            else if (ContainsPrice.Count == 0)
            {
                return BadRequest("There is no books in this price searching!");
            }

            else if (price == 0)
            {
                return BadRequest("Incorrect price");
            }

            ContainsPrice.Sort(sortByPrice);


            return Ok(ContainsPrice);
        }

        // Hämtar böcker som innehåller siffran mellan två price sökning.
        [HttpGet]
        [Route("Api/Books/Price/{startPrice}/{endPrice}")]
        public IHttpActionResult Price(double startPrice, double endPrice)
        {
            var ContainsPrice = logic.BooksList.Where(b => b.Price >= startPrice && b.Price <= endPrice).ToList();

            if (ContainsPrice == null)
            {
                return NotFound();
            }

            else if(ContainsPrice.Count == 0)
            {
                return BadRequest("There is no books in this price searching!");
            }

            else if (endPrice == 0)
            {
                return BadRequest("Incorrect end price");
            }

            ContainsPrice.Sort(sortByPrice);


            return Ok(ContainsPrice);
        }



        /* ------ Published delen ------ */

        // Hämtar alla böcker sorterade efter Published Date
        [HttpGet]
        [Route("Api/Books/Published")]
        public IHttpActionResult Published()
        {
            List<Book> BooksByPublishDate = logic.BooksList;

            if (BooksByPublishDate == null)
            {
                return NotFound();
            }

            BooksByPublishDate.Sort(sortByPublishDate);

            return Ok(BooksByPublishDate);
        }

        // Hämtar böcker som innehåller angivna året fram tills dagens datum.
        [HttpGet]
        [Route("Api/Books/Published/{year}")]
        public IHttpActionResult Published(int year)
        {
            DateTime startDate = new DateTime(year, 1, 1);
            DateTime endDate = DateTime.Now;

            var ContainsDate = logic.BooksList.Where(b => b.Publish_date >= startDate && b.Publish_date <= endDate).ToList();

            if (ContainsDate == null)
            {
                return NotFound();
            }

            else if (ContainsDate.Count == 0)
            {
                return BadRequest("There is no books in this price searching!");
            }

            ContainsDate.Sort(sortByPublishDate);


            return Ok(ContainsDate);
        }

        // Hämtar böcker som innehåller angivna året och månaden fram tills dagens datum.
        [HttpGet]
        [Route("Api/Books/Published/{year}/{month}")]
        public IHttpActionResult Published(int year, int month)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = DateTime.Now;

            var ContainsDate = logic.BooksList.Where(b => b.Publish_date >= startDate && b.Publish_date <= endDate).ToList();

            if (ContainsDate == null)
            {
                return NotFound();
            }

            else if (ContainsDate.Count == 0)
            {
                return BadRequest("There is no books in this price searching!");
            }

            ContainsDate.Sort(sortByPublishDate);


            return Ok(ContainsDate);
        }

        // Hämtar böcker som innehåller angivna året, månaden och dagen fram tills dagens datum.
        [HttpGet]
        [Route("Api/Books/Published/{year}/{month}/{day}")]
        public IHttpActionResult Published(int year, int month, int day)
        {
            DateTime startDate = new DateTime(year, month, day);
            DateTime endDate = DateTime.Now;

            var ContainsDate = logic.BooksList.Where(b => b.Publish_date >= startDate && b.Publish_date <= endDate).ToList();

            if (ContainsDate == null)
            {
                return NotFound();
            }

            else if (ContainsDate.Count == 0)
            {
                return BadRequest("There is no books in this price searching!");
            }

            ContainsDate.Sort(sortByPublishDate);


            return Ok(ContainsDate);
        }



        /* ------ Description delen ------ */

        // Hämtar alla böcker sorterade efter description
        [HttpGet]
        [Route("Api/Books/Description")]
        public IHttpActionResult Description()
        {
            List<Book> BooksByDescription = logic.BooksList;

            if (BooksByDescription == null)
            {
                return NotFound();
            }

            BooksByDescription.Sort(sortByDescription);

            return Ok(BooksByDescription);
        }

        // Hämtar böcker som innehåller description sökningen. Hela description eller del av det.
        [HttpGet]
        [Route("Api/Books/Description/{description}")]
        public IHttpActionResult Description(string description)
        {
            string descriptionInputToLower = description.ToLower();

            List<Book> ContainsGenre = logic.BooksList.FindAll(b => b.Description.ToLower().Contains(descriptionInputToLower));

            if (ContainsGenre == null)
            {
                return NotFound();
            }

            else if (descriptionInputToLower == null)
            {
                return BadRequest("Incorrect description");
            }

            ContainsGenre.Sort(sortByDescription);

            return Ok(ContainsGenre);
        }
    }
}

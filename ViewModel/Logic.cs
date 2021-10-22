using Newtonsoft.Json;
using QronosBookTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace QronosBookTest.ViewModel
{
    // Klassen innehåller logiken bakom kopplingen mellan JSOn filen och API klassen
    public class Logic
    {
        // Filadressen
        string booksPath = HttpContext.Current.Server.MapPath("~/DAL/Books.json");

        // Lista av typen Book för att motsvara JSOn filen
        public List<Book> BooksList { get; set; }


        public Logic()
        {
            // Hämtar JSON filen
            var jsonBooks = File.ReadAllText(HttpContext.Current.Server.MapPath("~/DAL/Books.json"));

            // Fyller i listan som sedan presenteras i API sökningen
            BooksList = JsonConvert.DeserializeObject<List<Book>>(jsonBooks);
        }
    }
}
using QronosBookTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QronosBookTest.SortingClasses
{
    public class SortByGenre : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Genre.CompareTo(y.Genre);
        }
    }
}
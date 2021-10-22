using QronosBookTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QronosBookTest.SortingClasses
{
    public class SortByPrice : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
using QronosBookTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QronosBookTest.SortingClasses
{
    public class SortByDescription : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Description.CompareTo(y.Description);
        }
    }
}
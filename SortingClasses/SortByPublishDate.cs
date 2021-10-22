using QronosBookTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QronosBookTest.SortingClasses
{
    public class SortByPublishDate : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Publish_date.CompareTo(y.Publish_date);
        }
    }
}
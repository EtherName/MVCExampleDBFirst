using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCExampleDBFirst.EntityDataModel;
using System.Data.Entity;

namespace MVCExampleDBFirst.Utilities
{
    public static class ExtensionMethods
    {
        public static void Add(this DbSet<BookStorage> bookStor, string name, string autor)
        {
            int id = 1;
            if(bookStor != null && bookStor.Count() > 0)
            {
                id = bookStor.Max(x => x.BookId) + 1;
            }
            bookStor.Add(new BookStorage() { BookId = id, Author = autor, Name = name, BookVisits = new BookVisits() { BookId = id, Visit = 0 } });
        }
    }
}
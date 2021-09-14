using BookWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebApi
{
    public class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Author="Stephen King",
                Title="Shining",
            },
            new Book()
            {
                Author="Stephen King",
                Title="Doctor Sleep",
            },
            new Book()
            {
                Author="Stephen King",
                Title="It"
                
            }

        };
    }
}

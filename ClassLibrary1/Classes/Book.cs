using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{

    public class Book : Library
    {
        public Book(Guid id, string name, string author, string publisher, DateTime publishedDate, Genres bookGenre, double rentPrice, double rentPriceAfterSale, DateTime rentDate) : base(id, name, author, publisher, publishedDate, bookGenre, rentPrice, rentPriceAfterSale, rentDate)
        {
        }

        public override string ToString()
        {
            return $" Type: Book \n Name: {Name} \n Author: {_author} \n Publisher: {_Publisher} \n Genre: {_bookGenre} \n Price: {_rentPrice.ToString()}$";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Classes;



namespace ClassLibrary1
{
    public abstract class Library
    {
        public Guid _id= Guid.NewGuid();
        public string _author;
        public string _Publisher;
        public DateTime _publishedDate;
        public Genres _bookGenre;
        public double _rentPrice;
        public double _rentPriceAfterSale;
        public DateTime _rentDate;
        public string Name;
        
        public DateTime getRentDate
        {
            get { return _rentDate; }
        }
        public Library(Guid id,string name, string author, string publisher, DateTime publishedDate, Genres bookGenre, double rentPrice, double rentPriceAfterSale, DateTime rentDate)
        {
            _id = id;
            _author = author;
            _Publisher = publisher;
            _publishedDate = publishedDate;
            _bookGenre = bookGenre;
            _rentPrice = rentPrice;
            _rentPriceAfterSale = rentPriceAfterSale;
            _rentDate = rentDate;
            Name = name;
            
        }

        
    }
}

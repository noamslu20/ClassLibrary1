using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Classes;


namespace ClassLibrary1.Classes
{
    public sealed class ItemsCollection
    {
       private List<Library> items = new List<Library>() {new Book(new Guid(),"Harry Potter","Ani","Bibi",DateTime.Now,Genres.Fantasy,22.0,2.0, DateTime.Now),
                                                          new Book(new Guid(),"100Thiefs","Ronaldo","Shlomo",DateTime.Now,Genres.Action,22.0,2.0, DateTime.Now),
                                                          new Journal(new Guid(),"100Thiefs","Ronaldo","Shlomo",DateTime.Now,Genres.Action,22.0,2.0, DateTime.Now)};

        private List<Library> BorrowdItems = new List<Library>() { new Book(new Guid(), "Harry Potter", "Ani", "Bibi", DateTime.Now, Genres.Fantasy, 22.0, 2.0, DateTime.Now) };
        private List<Library> SearchedItems = new List<Library>();
        private List<int> IDs = new List<int>();
        private bool isAdmin =false;
        /*
        private static ItemsCollection instance = null;
        public ItemsCollection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ItemsCollection();
                }
                return instance;
            }
        }*/
        private int itemsInStock;
        private int ItemsBorrowd;
        private int TotalItems;
        private int countBooks;
        private int countJournals;
        private int countID = 0;
        
        
        public int GetTotalItems { get { return TotalItems; } }
        public int GetCountBook { get { return countBooks; } }
        public int GetCountJournals { get { return countJournals; } }
        public int GetItemsInStock { get { return items.Count(); } }
        public int GetCountOfBorrowd { get { return BorrowdItems.Count(); } }

        public bool IsAdmin { get;}

        public ItemsCollection(bool isAdmin) 
        {
            IsAdmin = isAdmin;
        }
        public ItemsCollection()
        {

        }

        
        public void AddItem(Library item)
        {
            items.Add(item);
            countID++;

        }
        public void RemoveItem(int id)
        {
                 items.RemoveAt(id);
                 
        }
        public int NumOfItem()
        {
            if (BorrowdItems.Count == 0)
            {
                return 0;
            }
            return BorrowdItems.Count;
           
        }
        public void AddToBorrowd(int index)
        {
            BorrowdItems.Add(items[index]);
            items.Remove(items[index]);
        }
        public bool isLate(int index)
        {
            
            DateTime _today = DateTime.Now;
            TimeSpan diff = _today - BorrowdItems[index].getRentDate;

            if (diff.TotalDays > 14)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ReturnFromBorrowd(int index)
        {
            if (BorrowdItems.Count>0)
            {
                items.Add(BorrowdItems[index]);
                BorrowdItems.Remove(BorrowdItems[index]);
            }
            
        }
        public List<Library> ShowList()
        {
            return items.ToList();
        }
        public List<Library> ShowFilteredList()
        {
            return SearchedItems.ToList();
        }
        public List<Library> ShowBorrowdList()
        {
            return BorrowdItems.ToList();
        }
        public Library GetListFromIndex(int index)
        {
            return items[index];
        }
        
        public  string ShowItem(Library item)
        {
            string Type;
            if (item is Book)
            {
                Type = "Book";
            }
            else
            {
                Type = "Journal";
            }
            return $"Type:{Type} \n Name: {item.Name} \n Author: {item._author} \n Publisher: {item._Publisher} \n Genre: {item._bookGenre}";
        }

        public void EditItem(int index,string author,string publisher,Genres genre,string name,double rentPrice,double SaleRPrice,DateTime publisheddate,DateTime rentDate)
        {
            
            items[index]._author = author;
            items[index]._Publisher = publisher;
            items[index]._bookGenre = genre;
            items[index].Name = name;
            items[index]._rentPrice = rentPrice;
            items[index]._rentPriceAfterSale = SaleRPrice;
            items[index]._publishedDate = publisheddate;
            items[index]._rentDate = rentDate;
        }
        public void CountLiterature(int countbooks,int countjournals)
        {
            foreach (Library item in items)
            {
                if (item is Book)
                {
                    countbooks++;
                }
                else
                {
                    countjournals++;
                }
            }
            foreach (Library item in BorrowdItems)
            {
                if (item is Book)
                {
                    countbooks++;
                }
                else
                {
                    countjournals++;
                }
            }
            countBooks = countbooks;
            countJournals = countjournals;
            TotalItems = countJournals + countBooks; 
        }
        public void SearchByGenre(string Condition)
        {
            string Genre;
            
            foreach (Library item in items)
            {
                Genre = item._bookGenre.ToString();
                if (Genre.ToLower() == Condition.ToLower())
                {
                    SearchedItems.Add(item);
                    
                }

            }
        }
        public void SearchByPublisher(string Condition)
        {
            string Publisher;
            
            foreach (Library item in items)
            {
                Publisher = item._Publisher.ToString();
                if (Publisher.ToLower() == Condition.ToLower())
                {
                    SearchedItems.Add(item);
                    
                }

            }
        }
        public void SearchByAuther(string Condition)
        {
            string Auther;
            
            foreach (Library item in items)
            {
                Auther = item._author.ToString();
                if (Auther.ToLower() == Condition.ToLower())
                {
                    SearchedItems.Add(item);
                    
                }

            }
        }
        public void SearchByName(string Condition)
        {
            string Name;
            
            foreach (Library item in items)
            {
                Name = item.Name.ToString();
                if (Name.ToLower() == Condition.ToLower())
                {
                    SearchedItems.Add(item);
                   
                }

            }
        }

    }
    
}

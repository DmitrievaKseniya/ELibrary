using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Repository
{
    public class BookRepository
    {
        private AppContext db = new AppContext();
        public Books SelectByID(int id)
        {
            return db.Books.FirstOrDefault(b => b.Id == id);
        }

        public List<Books> SelectAll()
        {
            return db.Books.ToList();
        }

        public void Add(string name, int year, string author, string genre)
        {
            var book = new Books { Name = name, Year = year, Author = author, Genre = genre };
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = SelectByID(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public void Update(int id, string newName = "", int newYear = 0, string newAuthor = "", string newGenre = "")
        {
            var book = SelectByID(id);
            if (newName != "")
                book.Name = newName; 
            if (newYear != 0)
                book.Year = newYear;
            if (newAuthor != "")
                book.Author = newAuthor;
            if (newGenre != "")
                book.Genre = newGenre;
            db.SaveChanges();
        }

        public List<Books> ListOfBooksByGenreAndYear(string genre, int beginPeriod, int endPeriod)
        {
            var booksQuery = db.Books.Where(b => b.Genre == genre && b.Year >= beginPeriod && b.Year <= endPeriod);
            return booksQuery.ToList();
        }

        public int CountOfBokksByAuthor(string author)
        {
            var countBooks = db.Books.Where(b => b.Author == author).Count();
            return countBooks;
        }

        public int CountOfBoksByGenre(string genre)
        {
            var countBooks = db.Books.Where(b => b.Genre == genre).Count();
            return countBooks;
        }

        public bool ExistsBookByAuthorAndGenre(string author, string genre)
        {
            var countBooks = db.Books.Where(b => b.Author == author && b.Genre == genre).Count();
            if (countBooks > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Books LastPublishedBooks()
        {
            var lastPublishedBooks = db.Books.OrderByDescending(b => b.Year).FirstOrDefault();
            return lastPublishedBooks;
        }

        public List<Books> AllBooksOrderByName()
        {
            var booksQuery = db.Books.OrderBy(b => b.Name);
            return booksQuery.ToList();
        }

        public List<Books> AllBooksOrderByYearDesc()
        {
            var booksQuery = db.Books.OrderByDescending(b => b.Year);
            return booksQuery.ToList();
        }

        public int CountOfBooksHasUser(int idUser)
        {
            var countBooks = db.Books.Where(b => b.UserId == idUser).Count();
            return countBooks;
        }

        public bool ExistsUserHaveBook(int idBooks)
        {
            var counBooks = db.Books.Where(b => b.Id == idBooks && b.User != null).Count();
            if (counBooks > 0)
                return true;
            else
                return false;
        }
    }
}

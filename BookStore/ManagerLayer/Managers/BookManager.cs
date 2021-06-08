using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepo bookRepository ;

        public BookManager(IBookRepo bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Books AddBook(Books booksModel)
        {
            return this.bookRepository.AddBook(booksModel);
        }
        public bool DeleteBook(int bookId)
        {
            return this.bookRepository.DeleteBook(bookId);
        }

        public List<Books> GetAllBooks()
        {
            return this.bookRepository.GetAllBooks();
        }

        public Books UpdateBook(Books booksModel)
        {
            return this.bookRepository.UpdateBook(booksModel);
        }
    }
}

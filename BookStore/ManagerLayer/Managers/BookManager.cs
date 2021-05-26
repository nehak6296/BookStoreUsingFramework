using ManagerLayer.Interfaces;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepo bookRepository;
        public BookManager(IBookRepo bookRepository)
        {
            this.bookRepository = bookRepository;
        }        

        public Books AddBook(Books booksModel)
        {
            return this.bookRepository.AddBook(booksModel);
        }
    }
}

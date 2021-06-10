using Microsoft.AspNetCore.Http;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface IBookManager
    {
        Books AddBook(Books booksModel);
        Books UpdateBook(Books booksModel);
        bool DeleteBook(int bookId);
        List<Books> GetAllBooks();
        bool UploadImage(int BookId,string imageUpload);

    }
}

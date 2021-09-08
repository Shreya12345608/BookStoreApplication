using BookStoreModel.BooksModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository.IBookStoreRepository
{
    public interface IBookDetailsRL
    {
        /// <summary>
        /// Add Book Details
        /// </summary>
        /// <param name="booksDetail"></param>
        /// <returns></returns>
        object AddBookDetails(BooksModel booksDetail);
        /// <summary>
        /// Get all Book Details
        /// </summary>
        /// <returns></returns>
        List<BooksModel> GetAllBooksDetails();
    }
}

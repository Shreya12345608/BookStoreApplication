using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.BooksModel;
using BookStoreRepository.IBookStoreRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBussiness.BookStoreBussiness
{
    public class BookDetailsBL : IBookDetailsBL
    {
        private readonly IBookDetailsRL BookDetails;

        public BookDetailsBL(IBookDetailsRL BookDetails)
        {
            this.BookDetails = BookDetails;
        }
        /// <summary>
        /// Add Book Details In  Book
        /// </summary>
        /// <param name="booksDetail"></param>
        /// <returns></returns>
        public object AddBookDetails(BooksModel booksDetail)
        {
            return this.BookDetails.AddBookDetails(booksDetail);
        }
        /// <summary>
        /// Get all Books
        /// </summary>
        /// <returns></returns>
        public List<BooksModel> GetAllBooksDetails()
        {
            return this.BookDetails.GetAllBooksDetails();
        }
    }
}

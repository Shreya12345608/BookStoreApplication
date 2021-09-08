using BookStoreBussiness.IBookStoreBussiness;
using BookStoreModel.BooksModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public IBookDetailsBL BookDetailsBL;

        public BooksController(IBookDetailsBL BookDetailsBL)
        {
            this.BookDetailsBL = BookDetailsBL;
        }

        /// <summary
        /// This method is adding book details.
        /// </summary>
        /// <param name="booksDetail"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddBookDetails(BooksModel booksDetail)
        {
            string message;
            var result = this.BookDetailsBL.AddBookDetails(booksDetail);
            try
            {
                if (!result.Equals(null))
                {
                    message = "Book details added successfully.";

                    return this.Ok(new { message, result });
                }
                message = "Please insert correct book details.!!";
                return BadRequest(new { message });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }
        /// <summary>
        /// This method  is getting all book details from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllBooksDetails()
        {
            string message;
            try
            {
                List<BooksModel> result = this.BookDetailsBL.GetAllBooksDetails();
                if (result != null)
                {
                    message = "The book details of given bookId is..";
                    return this.Ok(new { message, result });
                }
                message = "Error while fetching book details.!!";
                return BadRequest(new { message });
            }
            catch (Exception ex)
            {
                return this.BadRequest(new { Success = false, Message = ex.Message, StackTrace = ex.StackTrace });
            }
        }
    }
}

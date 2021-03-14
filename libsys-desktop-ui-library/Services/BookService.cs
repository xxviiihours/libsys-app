using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Services
{

    public class BookService : IBookService
    {

        private readonly IAPIHelper _apiHelper;
        public BookService(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.HttpClient.GetAsync("/api/books"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<BookModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task<List<BookModel>> GetAllAvailableBooks()
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.HttpClient.GetAsync("/api/books/available"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<BookModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task<BookModel> GetByBookId(string bookId)
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.HttpClient.GetAsync($"/api/books/id/{bookId}"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<BookModel>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task<List<BookModel>> GetAvailableBooksByTitle(string bookTitle)
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.HttpClient.GetAsync($"/api/books/available/title?BookTitle={bookTitle}"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<BookModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task Save(BookModel bookModel)
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.HttpClient.PostAsJsonAsync("/api/books/save", bookModel))
            {
                if (responseMessage.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task Update(int id, BookModel bookModel)
        {
            using (HttpResponseMessage responseMessage = await _apiHelper.HttpClient.PutAsJsonAsync($"/api/books/update?id={id}", bookModel))
            {
                if (responseMessage.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}
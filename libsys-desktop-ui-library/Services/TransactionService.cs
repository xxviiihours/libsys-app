﻿using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Services
{
   public class TransactionService : ITransactionService
    {
        private readonly IAPIHelper apiHelper;
        public TransactionService(IAPIHelper apiHelper)
        {
            this.apiHelper = apiHelper;
        }
        public async Task Borrow(BorrowListModel borrowList)
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.PostAsJsonAsync("/api/v2/transactions/borrow/save", borrowList))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    //TODO Create notification
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task<List<TransactionModel>> GetBorrowedBooksByClassificationId(string id)
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.GetAsync($"/api/v2/transactions/classification-id?classificationId={id}"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<TransactionModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
        public async Task Return(int id, TransactionModel transactionModel)
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.PutAsJsonAsync($"/api/v2/transactions/return/update?id={id}", transactionModel))
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

using Caliburn.Micro;
using libsys_desktop_ui.Interfaces;
using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class ReportViewModel : Screen
    {

        private readonly IExcelReportService excelReportService;
        private readonly IDataTableConverterHelper dataTableConverterHelper;
        private readonly IReportService reportService;
        private readonly IWindowManager window;

        private readonly MessageViewModel Message;
        private BindingList<TransactionModel> BorrowedBooks;
        private BindingList<TransactionModel> OverduedBooks;

        public ReportViewModel(IExcelReportService excelReportService, IDataTableConverterHelper dataTableConverterHelper,
            IReportService reportService, MessageViewModel message, IWindowManager window)
        {
            this.excelReportService = excelReportService;
            this.dataTableConverterHelper = dataTableConverterHelper;
            this.reportService = reportService;
            this.Message = message;
            this.window = window;
        }
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadBorrowedBooks();
            await LoadOverduedBooks();
        }
        public async Task LoadBorrowedBooks()
        {
            try
            {
                var borrowedBookLists = await reportService.ReportGetAllBorrowedBooks();
                if (borrowedBookLists.Count <= 0)
                {
                    return;
                }
                BorrowedBooks = new BindingList<TransactionModel>(borrowedBookLists);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task LoadOverduedBooks()
        {
            try
            {
                var overduedBookLists = await reportService.ReportGetAllOverduedBooks();
                if(overduedBookLists.Count <= 0)
                {
                    return;
                }
                OverduedBooks = new BindingList<TransactionModel>(overduedBookLists);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //private string message;
        //public string Message
        //{
        //    get { return message; }
        //    set
        //    {
        //        message = value;
        //        NotifyOfPropertyChange(() => Message);
        //        NotifyOfPropertyChange(() => IsMessageVisible);
        //    }
        //}

        //private string messageColor;

        //public string MessageColor
        //{
        //    get { return messageColor; }
        //    set
        //    {
        //        messageColor = value;
        //        NotifyOfPropertyChange(() => MessageColor);
        //    }
        //}

        //public bool IsMessageVisible
        //{
        //    get
        //    {
        //        bool output = false;
        //        if (Message?.Length > 0)
        //        {
        //            output = true;
        //            return output;
        //        }
        //        return output;
        //    }
        //}
        public async Task GenerateBorrowedBooksReport()
        {
            try
            {
                excelReportService.GenerateExcel(await dataTableConverterHelper.ConvertToDataTable(BorrowedBooks), "Borrowed Books Report");
                Message.UpdateMessage("Generate Borrowed Books", "Generate Report successful.", "#00c853");
                await window.ShowDialogAsync(Message, null, null);
            }
            catch (Exception ex)
            {
                Message.UpdateMessage("Generate Borrowed Books", ex.Message, "#ef5350");
                await window.ShowDialogAsync(Message, null, null);
                //MessageColor = "#ef5350";
                //Message = ex.Message;
            }
        }
        public async Task GenerateOverduedBooksReport()
        {
            try
            {
                //Message = "";
                excelReportService.GenerateExcel(await dataTableConverterHelper.ConvertToDataTable(OverduedBooks), "Overdued Books Report");
                Message.UpdateMessage("Generate Overdued Books", "Generate Report successful.", "#00c853");
                await window.ShowDialogAsync(Message, null, null);
            }
            catch (Exception ex)
            {
                Message.UpdateMessage("Generate Borrowed Books", ex.Message, "#ef5350");
                await window.ShowDialogAsync(Message, null, null);
            }
        }
    }
}

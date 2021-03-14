using Caliburn.Micro;
using libsys_desktop_ui.Helpers;
using libsys_desktop_ui.Interfaces;
using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class ReturnViewModel : Screen
    {
        private readonly IStudentService studentService;
        private readonly ITransactionService transactionService;
        private readonly IPDFHelper pdfHelper;

        private string selectedClassification;
        private string idNumber;
        private string fullName;
        private string department;

        private BindingList<TransactionModel> borrowedBooks;
        private TransactionModel selectedBorrowedBook = new TransactionModel();

        private DateTime dateBorrowed;
        private DateTime dueDate;
        private string violationMessage;


        private string receipt;

        public ReturnViewModel(IStudentService studentService, ITransactionService transactionService,
            IPDFHelper pdfHelper)
        {
            this.studentService = studentService;
            this.transactionService = transactionService;
            this.pdfHelper = pdfHelper;
        }

        public BindingList<string> Classifications
        {
            get 
            {
                return new BindingList<string>(
                  new string[] { "STUDENT", "TEACHER" });
                
            }
        }

        public string SelectedClassification
        {
            get { return selectedClassification; }
            set 
            { selectedClassification = value;
                NotifyOfPropertyChange(() => SelectedClassification);
                NotifyOfPropertyChange(() => CanSearchID);
            }
        }


        public string IdNumber
        {
            get { return idNumber; }
            set 
            { 
                idNumber = value;
                NotifyOfPropertyChange(() => IdNumber);
                NotifyOfPropertyChange(() => CanSearchID);
            }
        }


        public string FullName
        {
            get { return fullName; }
            set 
            { 
                fullName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }

        public string Department
        {
            get { return department; }
            set 
            { 
                department = value;
                NotifyOfPropertyChange(() => Department);
            }
        }


        public BindingList<TransactionModel> BorrowedBooks
        {
            get { return borrowedBooks; }
            set 
            { 
                borrowedBooks = value;
                NotifyOfPropertyChange(() => BorrowedBooks);
            }
        }

        public TransactionModel SelectedBorrowedBook
        {
            get { return selectedBorrowedBook; }
            set 
            { 
                selectedBorrowedBook = value;
                FillDateTimeValue();
                NotifyOfPropertyChange(() => SelectedBorrowedBook);
                NotifyOfPropertyChange(() => IsViolated);
                NotifyOfPropertyChange(() => ViolationMessage);
                NotifyOfPropertyChange(() => CanGenerate);
                NotifyOfPropertyChange(() => CanReturn);
            }
        }

        public void FillDateTimeValue()
        {
            if (SelectedBorrowedBook == null)
                return;
            DateBorrowed = SelectedBorrowedBook.DateBorrowed;
            DueDate = SelectedBorrowedBook.DueDate;
        }

        public DateTime DateBorrowed
        {
            get { return dateBorrowed; }
            set 
            { 
                dateBorrowed = value;
                NotifyOfPropertyChange(() => DateBorrowed);
            }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set 
            { 
                dueDate = value;
                NotifyOfPropertyChange(() => DueDate);
                NotifyOfPropertyChange(() => CanGenerate);
                NotifyOfPropertyChange(() => CanReturn);
            }
        }


        public string ViolationMessage
        {
            get { return violationMessage; }
            set 
            { 
                violationMessage = value;
                NotifyOfPropertyChange(() => ViolationMessage);
            }
        }


        public string Receipt
        {
            get { return receipt; }
            set 
            { 
                receipt = value;
                NotifyOfPropertyChange(() => Receipt);
                NotifyOfPropertyChange(() => CanExport);
            }
        }

        public bool IsViolated
        {
            get
            {
                bool output = false;
                if (DueDate != DateTime.MinValue &&
                    DueDate < DateTime.Now)
                {
                    output = true;
                    ViolationMessage = "This book is already past it's due date.";
                    return output;
                }
                return output;
            }
        }

        public async Task LoadBorrowedBooks()
        {
            var borrowedBookList = await transactionService.GetBorrowedBooksByClassificationId(IdNumber);
            BorrowedBooks = new BindingList<TransactionModel>(borrowedBookList);
        }

        public bool CanSearchID
        {
            get
            {
                if(SelectedClassification != null && IdNumber?.Length > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CanGenerate
        {
            get
            {
                if((SelectedBorrowedBook != null && DueDate != DateTime.MinValue)
                    && DueDate < DateTime.Now)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CanReturn
        {
            get
            {
                if(SelectedBorrowedBook != null && DueDate > DateTime.Now)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CanExport
        {
            get
            {
                if(Receipt?.Length > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public async Task SearchID()
        {
            if (SelectedClassification == null)
                return;

            if (SelectedClassification == "STUDENT")
            {
                var result = await studentService.GetByStudentId(IdNumber);
                FullName = $"{result.LastName}, {result.FirstName}";
                Department = result.Department;
                
                await LoadBorrowedBooks();
            }
        }
        public void Generate()
        {
            // TODO: Create Generate report and show it to Receipt textbox
            Receipt = "COLEGIO DE SAN GABRIEL ARCANGEL\n"
                    + "     eLMS Violation Reciept\n"
                    + "--------------------------------\n"
                    + "Borrower's Information\n"
                    + "--------------------------------\n"
                    + $"Student ID: {IdNumber}\n"
                    + $"Fullname: {FullName}\n"
                    + $"Department: {Department}\n"
                    + "--------------------------------\n"
                    + "Book Information\n"
                    + "--------------------------------\n"
                    + $"Call Number: {SelectedBorrowedBook.CallNumber}\n"
                    + $"Book Title: {SelectedBorrowedBook.BookTitle}\n"
                    + "--------------------------------\n"
                    + "Violation Fines\n"
                    + "--------------------------------\n"
                    + $"Date Borrowed: {SelectedBorrowedBook.DateBorrowed}\n"
                    + $"Due Date: {SelectedBorrowedBook.DueDate}\n"
                    + "Total Days: \n"
                    + "Total Fine: \n"
                    + "Cashier's Signature: ___________\n"
                    + "--------------------------------\n"
                    + "          © 2020 eMLS\n"
                    + "      All Rights Reserved.\n";
        }

        public async Task Return()
        {
            // TODO: Save returning book to API
            TransactionModel transaction = new TransactionModel();
            transaction.BookId = SelectedBorrowedBook.BookId;
            transaction.CallNumber = SelectedBorrowedBook.CallNumber;
            transaction.ClassificationId = SelectedBorrowedBook.ClassificationId;
            transaction.Status = "RETURNED";
            await transactionService.Return(SelectedBorrowedBook.Id, transaction);
            ClearBorrowedData();
            await LoadBorrowedBooks();
        }

        public void Export()
        {
            // TODO: Export Receipt file
            pdfHelper.GenerateReport(Receipt);
        }

        public void ClearBorrowedData()
        {
            BorrowedBooks = new BindingList<TransactionModel>();
            DateBorrowed = DateTime.MinValue;
            DueDate = DateTime.MinValue;
        }

        public void Clear()
        {
            BorrowedBooks = new BindingList<TransactionModel>();
            DateBorrowed = DateTime.MinValue;
            DueDate = DateTime.MinValue;

            IdNumber = "";
            FullName = "";
            Department = "";
            Receipt = "";
            ViolationMessage = "";
        }
    }
}

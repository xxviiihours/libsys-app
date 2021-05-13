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
        private readonly IUserLoggedInModel userLoggedInModel;
        private readonly IViolationService violationService;
        private readonly IPDFHelper pdfHelper;
        private readonly IConfigHelper configHelper;
        private readonly IWindowManager window;

        private string selectedClassification;
        private string idNumber;
        private string fullName;
        private string gradeLevel;
        private string department;

        private readonly MessageViewModel Message;
        private BindingList<TransactionModel> borrowedBooks;
        private TransactionModel selectedBorrowedBook = new TransactionModel();

        private DateTime dateBorrowed;
        private DateTime dueDate;
        private string violationMessage;


        private string receipt;


        private string orNumber;
        private string cashierName;

        private int totalDays = 0;
        private decimal totalFine = 0;


        private string notificationMessage;
        private string errorMessage;



        public ReturnViewModel(IStudentService studentService, ITransactionService transactionService,
            IPDFHelper pdfHelper, IViolationService violationService,
            IConfigHelper configHelper, IUserLoggedInModel userLoggedInModel,
            IWindowManager window, MessageViewModel message)
        {
            this.studentService = studentService;
            this.transactionService = transactionService;
            this.pdfHelper = pdfHelper;
            this.violationService = violationService;
            this.configHelper = configHelper;
            this.userLoggedInModel = userLoggedInModel;
            this.window = window;
            Message = message;
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
        public string GradeLevel
        {
            get { return gradeLevel; }
            set
            {
                gradeLevel = value;
                NotifyOfPropertyChange(() => GradeLevel);
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
                ViolationMessage = "";
                selectedBorrowedBook = value;
                NotifyOfPropertyChange(() => SelectedBorrowedBook);
                FillDateTimeValue();
                NotifyOfPropertyChange(() => IsViolationMessageVisible);
                NotifyOfPropertyChange(() => ViolationMessage);
                NotifyOfPropertyChange(() => CanGenerate);
                NotifyOfPropertyChange(() => CanClearViolation);
                NotifyOfPropertyChange(() => CanReturn);
            }
        }
        public int GetWorkingDays(DateTime from, DateTime to)
        {
            var dayDifference = (int)to.Subtract(from).TotalDays;
            return Enumerable
                .Range(1, dayDifference)
                .Select(x => from.AddDays(x))
                .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
        }

        public void FillDateTimeValue()
        {
            if (SelectedBorrowedBook == null)
                return;
            DateBorrowed = SelectedBorrowedBook.DateBorrowed;
            DueDate = SelectedBorrowedBook.DueDate;

            if (DueDate != DateTime.MinValue && DueDate < DateTime.Now)
            {
                ViolationMessage = "This book is already past it's due date.";
                totalDays = GetWorkingDays(DueDate, DateTime.Now);
                totalFine = Math.Abs(Convert.ToDecimal(totalDays * configHelper.GetActualFine()));
            }
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

        public string NotificationMessage
        {
            get
            {
                return notificationMessage;
            }
            set
            {
                notificationMessage = value;
                NotifyOfPropertyChange(() => NotificationMessage);
                NotifyOfPropertyChange(() => IsNotificationMessageVisible);
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            { 
                errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorMessageVisible);
            }
        }


        public string ViolationMessage
        {
            get { return violationMessage; }
            set 
            { 
                violationMessage = value;
                NotifyOfPropertyChange(() => ViolationMessage);
                NotifyOfPropertyChange(() => IsViolationMessageVisible);
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

        public string OrNumber
        {
            get { return orNumber; }
            set 
            {
                orNumber = value;
                NotifyOfPropertyChange(() => OrNumber);
                NotifyOfPropertyChange(() => CanSaveViolation);
            }
        }

        public string CashierName
        {
            get { return cashierName; }
            set 
            { 
                cashierName = value;
                NotifyOfPropertyChange(() => CashierName);
                NotifyOfPropertyChange(() => CanSaveViolation);
            }
        }

        public bool IsNotificationMessageVisible
        {
            get 
            { 
                if(NotificationMessage?.Length > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsErrorMessageVisible
        {
            get
            {
                if(ErrorMessage?.Length > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsViolationMessageVisible
        {
            get
            {
                bool output = false;
                if (ViolationMessage?.Length > 0)
                {
                    output = true;
                    return output;
                }
                return output;
            }
        }

        public bool IsViolationFormVisible 
        {
            get
            {
                if(SelectedBorrowedBook != null && IsViolationMessageVisible)
                {
                    return true;
                }
                return false;
            }
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

        public bool CanClearViolation
        {
            get
            {
                if(SelectedBorrowedBook != null && IsViolationMessageVisible)
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
                if(BorrowedBooks != null && SelectedBorrowedBook != null && !IsViolationMessageVisible)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CanSaveViolation
        {
            get
            {
                if(OrNumber?.Length > 0 && CashierName?.Length > 0)
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

        public async Task LoadBorrowedBooks()
        {
            var borrowedBookList = await transactionService.GetBorrowedBooksByClassificationId(IdNumber);
            if(borrowedBookList.Count <= 0)
            {
                ErrorMessage = "No list of books found for this ID.";
            }
            BorrowedBooks = new BindingList<TransactionModel>(borrowedBookList);
        }

        public async Task SearchID()
        {
           try
           {
                ViolationMessage = "";
                ErrorMessage = "";
                NotifyOfPropertyChange(() => IsViolationMessageVisible);
                NotifyOfPropertyChange(() => IsViolationFormVisible);

                if (SelectedClassification == null)
                    return;

                if (SelectedClassification == "STUDENT")
                {
                    var result = await studentService.GetByStudentId(IdNumber);

                    FullName = $"{result.LastName}, {result.FirstName}";
                    GradeLevel = result.GradeLevel;
                    Department = "";

                    await LoadBorrowedBooks();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        // LAZY CODE LMAO
        public void Generate()
        {
            Receipt = "COLEGIO DE SAN GABRIEL ARCANGEL\n"
                    + "    Libsys Violation Reciept\n"
                    + "--------------------------------\n"
                    + $"OR Number: {SelectedBorrowedBook.Id}\n"
                    + "--------------------------------\n"
                    + "Borrower's Information\n"
                    + "--------------------------------\n"
                    + $"Student ID: {IdNumber}\n"
                    + $"Fullname: {FullName}\n"
                    + $"Grade Level: {GradeLevel}\n"
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
                    + $"Total Days: {totalDays}\n"
                    + $"Total Fine: {totalFine}\n"
                    + "--------------------------------\n"
                    + "Cashier Information\n"
                    + "--------------------------------\n"
                    + "Name of the Cashier: ___________\n\n"
                    + "Cashier's Signature: ___________\n"
                    + "--------------------------------\n"
                    + "         © 2021 Libsys\n"
                    + "      All Rights Reserved.\n";
        }

        public void ClearViolation()
        {
            NotifyOfPropertyChange(() => IsViolationFormVisible);
        }

        public async Task Return()
        {
            try
            {
                TransactionModel transaction = new TransactionModel
                {
                    BookId = SelectedBorrowedBook.BookId,
                    CallNumber = SelectedBorrowedBook.CallNumber,
                    ClassificationId = SelectedBorrowedBook.ClassificationId,
                    UserId = userLoggedInModel.Id,
                    Status = "RETURNED"
                };
                await transactionService.Return(SelectedBorrowedBook.Id, transaction);
                ClearBorrowedData();
                await LoadBorrowedBooks();
                Message.UpdateMessage("Return a book", "Return success.", "#00c853");
                await window.ShowDialogAsync(Message, null, null);
                NotifyOfPropertyChange(() => IsViolationFormVisible);
            }
            catch (Exception ex)
            {
                Message.UpdateMessage("Return a book", $"Return failed. {ex.Message}.", "#ef5350");
                await window.ShowDialogAsync(Message, null, null);
            }
        }

        public async Task SaveViolation()
        {
            try
            {
                NotificationMessage = "";
                ViolationModel violationModel = new ViolationModel
                {
                    ClassificationId = IdNumber,
                    BookId = SelectedBorrowedBook.BookId,
                    UserId = userLoggedInModel.Id,
                    OrNumber = OrNumber,
                    CashierName = CashierName,
                    TotalDays = totalDays,
                    TotalFine = totalFine,
                    ModifiedAt = DateTime.Now
                };

                await violationService.Save(violationModel);
                NotificationMessage = "Violation has been successfully lifted.";
                ViolationMessage = "";
                Receipt = "";
                ClearViolationForm();
                NotifyOfPropertyChange(() => CanReturn);
            }
            catch (Exception ex)
            {
                NotificationMessage = ex.Message;
            }
        }

        public void Export()
        {
            pdfHelper.GenerateReport(Receipt);
            Message.UpdateMessage("Generate receipt", "Generate success.", "#00c853");
            window.ShowDialogAsync(Message, null, null);
            Receipt = "";
        }

        public void ClearBorrowedData()
        {
            BorrowedBooks = new BindingList<TransactionModel>();
            SelectedBorrowedBook = null;
            DateBorrowed = DateTime.MinValue;
            DueDate = DateTime.MinValue;
        }

        public void ClearViolationForm()
        {
            OrNumber = "";
            CashierName = "";
            totalDays = 0;
            totalFine = 0;
        }

        public void ClearAll()
        {
            IdNumber = "";
            FullName = "";
            GradeLevel = "";
            Department = "";
            Receipt = "";
            ViolationMessage = "";
            ErrorMessage = "";
            NotificationMessage = "";
            ClearBorrowedData();
            ClearViolationForm();
            NotifyOfPropertyChange(() => IsViolationMessageVisible);
            NotifyOfPropertyChange(() => IsViolationFormVisible);
        }
    }
}

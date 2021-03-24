﻿using Caliburn.Micro;
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
    public class BorrowViewModel : Screen
    {
        private readonly IUserLoggedInModel userLoggedIn;
        private readonly IStudentService studentService;
        private readonly IBookService bookService;
        private readonly ITransactionService transactionService;

        private string studentId;
        private string errorMessage;
        private string fullName;
        private string department;
        private string phoneNumber;
        private string emailAddress;

        private int borrowLimit;

        private string bookTitle;

        private BindingList<BookModel> books;
        private BindingList<BorrowBookModel> borrowBooks = new BindingList<BorrowBookModel>();
        private BookModel selectedBook;

        public BorrowViewModel(IStudentService studentService, IBookService bookService,
            IUserLoggedInModel userLoggedIn, ITransactionService transactionService)
        {
            this.studentService = studentService;
            this.bookService = bookService;
            this.userLoggedIn = userLoggedIn;
            this.transactionService = transactionService;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadAvailableBooks();
        }

        private async Task LoadAvailableBooks()
        {
            var bookList = await bookService.GetAllAvailableBooks();
            Books = new BindingList<BookModel>(bookList);
        }

        public BindingList<BookModel> Books
        {
            get { return books; }
            set 
            { 
                books = value;
                NotifyOfPropertyChange(() => Books);
            }
        }

        public BindingList<BorrowBookModel> BorrowBooks
        {
            get { return borrowBooks; }
            set 
            { 
                borrowBooks = value;
                NotifyOfPropertyChange(() => BorrowBooks);
            }
        }


        public BookModel SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                selectedBook = value;
                NotifyOfPropertyChange(() => SelectedBook);
                NotifyOfPropertyChange(() => CanAddBooks);
            }
        }

        private BorrowBookModel _selectedAddedBook;

        public BorrowBookModel SelectedAddedBook
        {
            get { return _selectedAddedBook; }
            set 
            {
                _selectedAddedBook = value;
                NotifyOfPropertyChange(() => SelectedAddedBook);
                NotifyOfPropertyChange(() => CanCheckout);
                NotifyOfPropertyChange(() => CanRemove);
            }
        }


        public string StudentId
        {
            get { return studentId; }
            set 
            {
                studentId = value;
                NotifyOfPropertyChange(() => StudentId);
                NotifyOfPropertyChange(() => IsBookListEnabled);
                NotifyOfPropertyChange(() => CanSearchStudentId);
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }
       
        public string FullName 
        { 
            get { return fullName; } 
            set
            {
                fullName = value;
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => IsBookListEnabled);
            }
        }

        public string Department
        {
            get { return department; }
            set
            {
                department = value;
                NotifyOfPropertyChange(() => Department);
                NotifyOfPropertyChange(() => IsBookListEnabled);
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
                NotifyOfPropertyChange(() => IsBookListEnabled);
            }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set
            {
                emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => IsBookListEnabled);
            }
        }

        public int BorrowLimit
        {
            get { return borrowLimit; }
            set 
            { 
                borrowLimit = value;
                NotifyOfPropertyChange(() => BorrowLimit);
                NotifyOfPropertyChange(() => IsBookListEnabled);
                NotifyOfPropertyChange(() => CanAddBooks);
            }
        }

        public string BookTitle
        {
            get { return bookTitle; }
            set 
            { 
                bookTitle = value;
                NotifyOfPropertyChange(() => BookTitle);
                NotifyOfPropertyChange(() => CanSearchBookTitle);
            }
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                    return output;
                }
                return output;
            }
        }

        public bool IsBookListEnabled
        {
            get
            {
                bool output = false;
                if(IsErrorVisible == false &&
                   StudentId?.Length > 0 &&
                   FullName?.Length > 0 &&
                   Department?.Length > 0 &&
                   PhoneNumber?.Length > 0 &&
                   EmailAddress?.Length > 0 &&
                   BorrowLimit > 0 )
                {
                    output = true;
                    return output;
                }

                if(BorrowLimit <= 0)
                {
                    //TODO Create Error Handling / Validation for 0 borrow limit
                    return output;
                }
                return output;
            }
        }

        public bool CanSearchStudentId
        {
            get
            {
                if (StudentId?.Length > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CanSearchBookTitle
        {
            get
            {
                if(BookTitle?.Length > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public bool CanAddBooks
        {
            get
            {
                bool output = false;
                if(SelectedBook != null &&
                    BorrowLimit > 0)
                {
                    output = true;
                    return output;
                }

                if(BorrowLimit <= 0)
                {
                    //TODO Create Error Handling / Validation for 0 borrow limit
                    return output;
                }
                return output;
            }
        }

        public bool CanCheckout
        {
            get
            {
                if(BorrowBooks.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CanRemove
        {
            get
            {
                if(SelectedAddedBook != null)
                {
                    return true;
                }
                return false;
            }
        }

        public async void SearchStudentId()
        {
            try
            {
                ErrorMessage = "";
                var student = await studentService.GetByStudentId(StudentId);

                var result = await transactionService.GetBorrowedBooksByClassificationId(StudentId);
                foreach(var item in result)
                {
                    if(item.DueDate < DateTime.Now)
                    {
                        ErrorMessage = "This student has an over-dued books. Please return the book first in order to proceed.";
                        
                    }
                }
                FullName = $"{student.LastName}, {student.FirstName}";
                Department = student.Department;
                PhoneNumber = student.PhoneNumber;
                EmailAddress = student.EmailAddress;
                BorrowLimit = student.BorrowLimit;
                BorrowBooks = new BindingList<BorrowBookModel>();
            }
            catch (Exception ex)
            {
                //Create error message if no student id found.
                ErrorMessage = $"ID Number {ex.Message.ToLower()}.";
                await Clear();
            }
        }

        public async void SearchBookTitle()
        {
            var searchedBookList = await bookService.GetAvailableBooksByTitle(BookTitle);
            if(searchedBookList.Count > 0)
            {
                Books = new BindingList<BookModel>(searchedBookList);
            }
            else
            {
                //TODO: Throw error if can't find any available books
                await LoadAvailableBooks();
            }
        }

        public void AddBooks()
        {
            //TODO: Add selected books to checkout list
            if(BorrowLimit > 0)
            {
                BorrowLimit -= 1;
                BorrowBookModel item = new BorrowBookModel
                {

                    Book = SelectedBook,
                    Status = "PENDING",

                };

                BorrowBooks.Add(item);
                Books.Remove(SelectedBook);

                NotifyOfPropertyChange(() => CanCheckout);
            }
        }

        public async Task Checkout()
        {
            // TODO: Add save to api endpoint service
            BorrowListModel addedBooks = new BorrowListModel();
            foreach(var item in BorrowBooks)
            {
                addedBooks.BorrowedBookDetails.Add(new TransactionModel
                {
                    BookId = item.Book.Id,
                    CallNumber = item.Book.CallNumber,
                    BookTitle = item.Book.Title,
                    UserId = userLoggedIn.Id,
                    ClassificationId = StudentId,
                    ClassificationType = "STUDENT",
                    Status = item.Status,
                    DateBorrowed = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
                    CreatedAt = DateTime.Now
                });
            }
            await transactionService.Borrow(addedBooks);
            await Clear();
        }

        public void Remove()
        {
            Books.Add(SelectedAddedBook?.Book);
            BorrowBooks.Remove(SelectedAddedBook);
            BorrowLimit += 1;
        }

        public async Task Clear()
        {
            BorrowBooks = new BindingList<BorrowBookModel>();
            await LoadAvailableBooks();
            StudentId = "";
            FullName = "";
            Department = "";
            PhoneNumber = "";
            EmailAddress = "";
            BorrowLimit = 0;
        }
    }
}

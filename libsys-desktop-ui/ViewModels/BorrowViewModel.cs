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
        private IUserLoggedInModel _userLoggedIn;
        private IStudentService _studentService;
        private IBookService _bookService;
        private ITransactionService _transactionService;
        private string _studentId;
        private string _fullName;
        private string _department;
        private string _phoneNumber;
        private string _emailAddress;

        private int _borrowLimit;

        private string _bookTitle;

        private BindingList<BookModel> _books;
        private BindingList<BorrowBookModel> _borrowBooks = new BindingList<BorrowBookModel>();
        private BookModel _selectedBook;

        public BorrowViewModel(IStudentService studentService, IBookService bookService,
            IUserLoggedInModel userLoggedIn, ITransactionService transactionService)
        {
            _studentService = studentService;
            _bookService = bookService;
            _userLoggedIn = userLoggedIn;
            _transactionService = transactionService;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadAvailableBooks();
        }

        private async Task LoadAvailableBooks()
        {
            var bookList = await _bookService.GetAllAvailableBooks();
            Books = new BindingList<BookModel>(bookList);
        }

        public BindingList<BookModel> Books
        {
            get { return _books; }
            set 
            { 
                _books = value;
                NotifyOfPropertyChange(() => Books);
            }
        }

        public BindingList<BorrowBookModel> BorrowBooks
        {
            get { return _borrowBooks; }
            set 
            { 
                _borrowBooks = value;
                NotifyOfPropertyChange(() => BorrowBooks);
            }
        }


        public BookModel SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
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
            get { return _studentId; }
            set 
            {
                _studentId = value;
                NotifyOfPropertyChange(() => StudentId);
                NotifyOfPropertyChange(() => IsBookListEnabled);
                NotifyOfPropertyChange(() => CanSearchStudentId);
            }
        }

        public string FullName 
        { 
            get { return _fullName; } 
            set
            {
                _fullName = value;
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => IsBookListEnabled);
            }
        }

        public string Department
        {
            get { return _department; }
            set
            {
                _department = value;
                NotifyOfPropertyChange(() => Department);
                NotifyOfPropertyChange(() => IsBookListEnabled);
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
                NotifyOfPropertyChange(() => IsBookListEnabled);
            }
        }

        public string EmailAddress
        {
            get { return _emailAddress; }
            set
            {
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => IsBookListEnabled);
            }
        }

        public int BorrowLimit
        {
            get { return _borrowLimit; }
            set 
            { 
                _borrowLimit = value;
                NotifyOfPropertyChange(() => BorrowLimit);
                NotifyOfPropertyChange(() => IsBookListEnabled);
                NotifyOfPropertyChange(() => CanAddBooks);
            }
        }

        public string BookTitle
        {
            get { return _bookTitle; }
            set 
            { 
                _bookTitle = value;
                NotifyOfPropertyChange(() => BookTitle);
                NotifyOfPropertyChange(() => CanSearchBookTitle);
            }
        }


        public bool IsBookListEnabled
        {
            get
            {
                bool output = false;
                if(StudentId?.Length > 0 &&
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
                var result = await _studentService.GetByStudentId(StudentId);

                FullName = $"{result.LastName}, {result.FirstName}";
                Department = result.Department;
                PhoneNumber = result.PhoneNumber;
                EmailAddress = result.EmailAddress;
                BorrowLimit = result.BorrowLimit;
                BorrowBooks = new BindingList<BorrowBookModel>();
            }
            catch (Exception ex)
            {
                //Create error message if no student id found.
                throw new NullReferenceException(ex.Message);
            }
        }

        public async void SearchBookTitle()
        {
            var searchedBookList = await _bookService.GetAvailableBooksByTitle(BookTitle);
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
                    UserId = _userLoggedIn.Id,
                    ClassificationId = StudentId,
                    ClassificationType = "STUDENT",
                    Status = item.Status,
                    DateBorrowed = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
                    CreatedAt = DateTime.Now
                });
            }
            await _transactionService.Borrow(addedBooks);
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

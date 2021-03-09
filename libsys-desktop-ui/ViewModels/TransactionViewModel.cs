using Caliburn.Micro;
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
    public class TransactionViewModel : Screen
    {
        private IStudentService _studentService;
        private IBookService _bookService;
        private string _studentId;
        private string _fullName;
        private string _department;
        private string _phoneNumber;
        private string _emailAddress;

        private int _borrowLimit;

        private BindingList<BookModel> _books;
        private BookModel _selectedBook;

        public TransactionViewModel(IStudentService studentService, IBookService bookService)
        {
            _studentService = studentService;
            _bookService = bookService;
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

        public string StudentId
        {
            get { return _studentId; }
            set 
            {
                _studentId = value;
                NotifyOfPropertyChange(() => StudentId);
                NotifyOfPropertyChange(() => IsBookListEnabled);
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

        public async void SearchStudentId()
        {
            var result = await _studentService.GetByStudentId(StudentId);
            FullName = $"{result.LastName}, {result.FirstName}";
            Department = result.Department;
            PhoneNumber = result.PhoneNumber;
            EmailAddress = result.EmailAddress;
            BorrowLimit = result.BorrowLimit;
            await LoadAvailableBooks();
        }


        public void AddBooks()
        {
            //TODO: Add selected books to checkout list
           
        }
    }
}

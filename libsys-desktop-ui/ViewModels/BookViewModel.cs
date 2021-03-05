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
    public class BookViewModel : Screen
    {
        private IAPIHelper _apiHelper;
        private IUserLoggedInModel _userLoggedIn;
        private IBookService _bookService;
        private IBookClassificationService _bookClassificationService;

        private string _callNumber;
        private string _bookTitle;
        private string _author;


        private string _publisher;
        private string _edition;
        private string _volume;
        private int _pages;
        private int _year;

        private string _location;
        private string _source;
        private double _price;
        private string _description;

        private string _search;

        private BindingList<BookClassificationModel> _bookClassification;
        private BindingList<BookModel> _books;

        private BookModel _selectedBookItem;

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadBookClassification();
            await LoadBooks();
        }
        public BookViewModel(IAPIHelper apiHelper, IUserLoggedInModel userLoggedIn, 
            IBookService bookService, IBookClassificationService bookClassificationService)
        {
            _apiHelper = apiHelper;
            _userLoggedIn = userLoggedIn;
            _bookService = bookService;
            _bookClassificationService = bookClassificationService;
        }

        private async Task LoadBooks()
        {
            var bookList = await _bookService.GetAll();
            Books = new BindingList<BookModel>(bookList);
        }

        private async Task LoadBookClassification()
        {
            var bookClassificationList = await _bookClassificationService.GetAll();
            Classifications = new BindingList<BookClassificationModel>(bookClassificationList);
        }

        public BindingList<BookClassificationModel> Classifications
        {
            get 
            {
                return _bookClassification;
            }
            set 
            {
                _bookClassification = value;
                NotifyOfPropertyChange(() => Classifications);
            } 
        }
        public string CallNumber
        {
            get
            {
                return _callNumber;
            }
            set
            {
                _callNumber = value;
                NotifyOfPropertyChange(() => CallNumber);
            }
        }
        public string BookTitle
        {
            get
            {
                return _bookTitle;
            }
            set
            {
                _bookTitle = value;
                NotifyOfPropertyChange(() => BookTitle);
            }
        }
        public string Author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                NotifyOfPropertyChange(() => Author);
            }
        }

        public string Publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                _publisher = value;
                NotifyOfPropertyChange(() => Publisher);
            }
        }
        public string Edition
        {
            get
            {
                return _edition;
            }
            set
            {
                _edition = value;
                NotifyOfPropertyChange(() => Edition);
            }
        }
        public string Volume
        {
            get
            {
                return _volume;
            }
            set
            {
                _volume = value;
                NotifyOfPropertyChange(() => Volume);
            }
        }
        public int Year
        {
            get 
            { 
                return _year; 
            }
            set 
            { 
                _year = value;
                NotifyOfPropertyChange(() => Year);
            }
        }
        public int Pages
        {
            get
            {
                return _pages;
            }
            set
            {
                _pages = value;
                NotifyOfPropertyChange(() => Pages);
            }
        }
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                NotifyOfPropertyChange(() => Location);
            }
        }
        public string Source
        {
            get
            {
                return _source;
            }
            set
            {
                _source = value;
                NotifyOfPropertyChange(() => Source);
            }
        }
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
                NotifyOfPropertyChange(() => Search);
            }
        }
        public BindingList<BookModel> Books 
        { 
            get 
            {
                return _books;
            }
            set 
            {
                _books = value;
                NotifyOfPropertyChange(() => Books);
            } 
        }
        public BookModel SelectedBookItem 
        {
            get
            {
                return _selectedBookItem;
            }
            set
            {
                if (_selectedBookItem == value) return;
                _selectedBookItem = value;
                NotifyOfPropertyChange(() => SelectedBookItem);
                CallNumber = _selectedBookItem.CallNumber;
                BookTitle = _selectedBookItem.Title;
                Description = _selectedBookItem.Description;
                Edition = _selectedBookItem.Edition;
                Volume = _selectedBookItem.Volumes;
                Pages = _selectedBookItem.Pages;
                Source = _selectedBookItem.Source;
                Price = _selectedBookItem.Price;
                Publisher = _selectedBookItem.Publisher;
                Location = _selectedBookItem.Location;
                Year = _selectedBookItem.Year;
                Author = _selectedBookItem.Author;

            }
        }
    }
}

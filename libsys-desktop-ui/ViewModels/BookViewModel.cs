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



        private string _classificationItem;

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

        private bool IsBookSelected;
        private bool IsClassificationSelected;

        private bool _canSave;
        private bool _canUpdate;

        private BindingList<BookClassificationModel> _bookClassification;
        private BindingList<BookModel> _books;


        private BookClassificationModel _selectedClassification;
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
            var bookList = await _bookService.GetAllBooks();
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

        public BookClassificationModel SelectedClassification
        {
            get { return _selectedClassification; }
            set 
            {
                if (_selectedClassification == value) return;
                _selectedClassification = value;
                IsClassificationSelected = true;
                //IsBookSelected = true;
                FillClassificationItem();
                NotifyOfPropertyChange(() => SelectedClassification);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }

        public void FillClassificationItem()
        {
            if (SelectedClassification == null) return;
            ClassificationItem = _selectedClassification.Classification;
        }
        public string ClassificationItem
        {
            get { return _classificationItem; }
            set
            {
                _classificationItem = value;
                //_classificationItem = SelectedClassificationItem.Classification;
                NotifyOfPropertyChange(() => ClassificationItem);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string CallNumber
        {
            get { return _callNumber; }
            set
            {
                _callNumber = value;
                NotifyOfPropertyChange(() => CallNumber);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string BookTitle
        {
            get { return _bookTitle; }
            set
            {
                _bookTitle = value;
                NotifyOfPropertyChange(() => BookTitle);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                NotifyOfPropertyChange(() => Author);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }

        public string Publisher
        {
            get { return _publisher; }
            set
            {
                _publisher = value;
                NotifyOfPropertyChange(() => Publisher);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Edition
        {
            get { return _edition; }
            set
            {
                _edition = value;
                NotifyOfPropertyChange(() => Edition);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;
                NotifyOfPropertyChange(() => Volume);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public int Year
        {
            get { return _year; }
            set 
            { 
                _year = value;
                NotifyOfPropertyChange(() => Year);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public int Pages
        {
            get { return _pages; }
            set
            {
                _pages = value;
                NotifyOfPropertyChange(() => Pages);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                NotifyOfPropertyChange(() => Location);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Source
        {
            get { return _source; }
            set
            {
                _source = value;
                NotifyOfPropertyChange(() => Source);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                NotifyOfPropertyChange(() => Search);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
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
                //if (_selectedBookItem == value) return;
                _selectedBookItem = value;
                SelectedClassification = null;
                IsBookSelected = true;
                //IsClassificationSelected = false;
                FillData();
                NotifyOfPropertyChange(() => SelectedBookItem);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }

        public void FillData()
        {
            if (SelectedBookItem == null) return;
            ClassificationItem = SelectedBookItem?.Classification;
            CallNumber = SelectedBookItem?.CallNumber;
            BookTitle = SelectedBookItem?.Title;
            Description = SelectedBookItem?.Description;
            Edition = SelectedBookItem?.Edition;
            Volume = SelectedBookItem?.Volumes;
            Pages = SelectedBookItem.Pages;
            Source = SelectedBookItem?.Source;
            Price = SelectedBookItem.Price;
            Publisher = SelectedBookItem?.Publisher;
            Location = SelectedBookItem?.Location;
            Year = SelectedBookItem.Year;
            Author = SelectedBookItem?.Author;
        }
        public bool CanSave
        {
            get
            {
                bool option = false;
                if (IsClassificationSelected &&
                    //!IsBookSelected &&
                    SelectedBookItem == null &&
                    CallNumber?.Length > 0 &&
                    BookTitle?.Length > 0 &&
                    Description?.Length > 0 &&
                    Edition?.Length > 0 &&
                    Volume?.Length > 0 &&
                    Pages > 0 &&
                    Source?.Length > 0 &&
                    Price > 0 &&
                    Publisher?.Length > 0 &&
                    Location?.Length > 0 &&
                    Year > 0 &&
                    Author?.Length > 0)
                {
                    option = true;
                    return option;
                }

                return option;
            }
            //set
            //{
            //    _canSave = value;
            //}
        }

        public bool CanUpdate
        {
            get
            {
                bool option = false;
                if (IsBookSelected &&
                    SelectedBookItem != null &&
                    ClassificationItem?.Length > 0 &&
                    CallNumber?.Length > 0 &&
                    BookTitle?.Length > 0 &&
                    Description?.Length > 0 &&
                    Edition?.Length > 0 &&
                    Volume?.Length > 0 &&
                    Pages > 0 &&
                    Source?.Length > 0 &&
                    Price > 0 &&
                    Publisher?.Length > 0 &&
                    Location?.Length > 0 &&
                    Year > 0 &&
                    Author?.Length > 0)
                {
                    option = true;
                    return option;
                }
            
                return option;
            }
        }

        public async Task Save()
        {
            BookModel book = new BookModel();
            book.Classification = ClassificationItem;
            book.CallNumber = CallNumber.ToUpper();
            book.Title = BookTitle;
            book.Description = Description;
            book.Edition = Edition;
            book.Volumes = Volume;
            book.Pages = Pages;
            book.Source = Source;
            book.Price = Price;
            book.Publisher = Publisher;
            book.Location = Location;
            book.Year = Year;
            book.Author = Author;
            book.ModifiedBy = _userLoggedIn.FirstName;
            //book.CreatedAt = DateTime.UtcNow;
            Console.WriteLine();
            await _bookService.Save(book);
            await LoadBooks();
            Clear();
        }

        public void Update()
        {
            //ClassificationItem = SelectedBookItem.Classification;
            BookModel book = new BookModel();
            book.Classification = ClassificationItem;
            book.CallNumber = CallNumber;
            book.Title = BookTitle;
            book.Description = Description;
            book.Edition = Edition;
            book.Volumes = Volume;
            book.Pages = Pages;
            book.Source = Source;
            book.Price = Price;
            book.Publisher = Publisher;
            book.Location = Location;
            book.Year = Year;
            book.Author = Author;
            book.ModifiedBy = _userLoggedIn.FirstName;
            book.LastModified = DateTime.UtcNow;
            Clear();
        }

        public void Clear()
        {
            IsClassificationSelected = false;
            IsBookSelected = false;
            SelectedClassification = null;
            SelectedBookItem = null;
            ClassificationItem = "";
            CallNumber = "";
            BookTitle = "";
            Description = "";
            Edition = "";
            Volume = "";
            Pages = 0;
            Source = "";
            Price = 0;
            Publisher = "";
            Location = "";
            Year = 0;
            Author = "";
        }
    }
}

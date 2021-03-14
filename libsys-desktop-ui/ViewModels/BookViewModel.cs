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
        private readonly IUserLoggedInModel userLoggedIn;
        private readonly IBookService bookService;
        private readonly IBookClassificationService bookClassificationService;



        private string classificationItem;

        private string callNumber;
        private string bookTitle;
        private string author;


        private string publisher;
        private string edition;
        private string volume;
        private int pages;
        private int year;

        private string location;
        private string source;
        private double price;
        private string description;

        private string search;

        private bool IsBookSelected;
        private bool IsClassificationSelected;

        private BindingList<BookClassificationModel> classifications;
        private BindingList<BookModel> books;


        private BookClassificationModel selectedClassification;
        private BookModel selectedBookItem;

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadBookClassification();
            await LoadBooks();
        }
        public BookViewModel(IUserLoggedInModel userLoggedIn, IBookService bookService, 
            IBookClassificationService bookClassificationService)
        {
            this.userLoggedIn = userLoggedIn;
            this.bookService = bookService;
            this.bookClassificationService = bookClassificationService;
        }

        private async Task LoadBooks()
        {
            var bookList = await bookService.GetAllBooks();
            Books = new BindingList<BookModel>(bookList);
        }

        private async Task LoadBookClassification()
        {
            var bookClassificationList = await bookClassificationService.GetAll();
            Classifications = new BindingList<BookClassificationModel>(bookClassificationList);
        }

        public BindingList<BookClassificationModel> Classifications
        {
            get 
            {
                return classifications;
            }
            set 
            {
                classifications = value;
                NotifyOfPropertyChange(() => Classifications);
            } 
        }

        public BookClassificationModel SelectedClassification
        {
            get { return selectedClassification; }
            set 
            {
                if (selectedClassification == value) return;
                selectedClassification = value;
                IsClassificationSelected = true;
                FillClassificationItem();
                NotifyOfPropertyChange(() => SelectedClassification);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }

        public void FillClassificationItem()
        {
            if (SelectedClassification == null) return;
            ClassificationItem = selectedClassification.Classification;
        }
        public string ClassificationItem
        {
            get { return classificationItem; }
            set
            {
                classificationItem = value;
                NotifyOfPropertyChange(() => ClassificationItem);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string CallNumber
        {
            get { return callNumber; }
            set
            {
                callNumber = value;
                NotifyOfPropertyChange(() => CallNumber);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string BookTitle
        {
            get { return bookTitle; }
            set
            {
                bookTitle = value;
                NotifyOfPropertyChange(() => BookTitle);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                NotifyOfPropertyChange(() => Author);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }

        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                NotifyOfPropertyChange(() => Publisher);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Edition
        {
            get { return edition; }
            set
            {
                edition = value;
                NotifyOfPropertyChange(() => Edition);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Volume
        {
            get { return volume; }
            set
            {
                volume = value;
                NotifyOfPropertyChange(() => Volume);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public int Year
        {
            get { return year; }
            set 
            { 
                year = value;
                NotifyOfPropertyChange(() => Year);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public int Pages
        {
            get { return pages; }
            set
            {
                pages = value;
                NotifyOfPropertyChange(() => Pages);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Location
        {
            get { return location; }
            set
            {
                location = value;
                NotifyOfPropertyChange(() => Location);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Source
        {
            get { return source; }
            set
            {
                source = value;
                NotifyOfPropertyChange(() => Source);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                NotifyOfPropertyChange(() => Price);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyOfPropertyChange(() => Description);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                NotifyOfPropertyChange(() => Search);
                NotifyOfPropertyChange(() => CanSave);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }
        public BindingList<BookModel> Books 
        { 
            get 
            {
                return books;
            }
            set 
            {
                books = value;
                NotifyOfPropertyChange(() => Books);
            } 
        }
        public BookModel SelectedBookItem 
        {
            get
            {
                return selectedBookItem;
            }
            set
            {
                selectedBookItem = value;
                SelectedClassification = null;
                IsBookSelected = true;
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
            BookModel book = new BookModel
            {
                Classification = ClassificationItem,
                CallNumber = CallNumber.ToUpper(),
                Title = BookTitle,
                Description = Description,
                Edition = Edition,
                Volumes = Volume,
                Pages = Pages,
                Source = Source,
                Price = Price,
                Publisher = Publisher,
                Location = Location,
                Year = Year,
                Author = Author,
                ModifiedBy = userLoggedIn.FirstName,
                LastModified = DateTime.Now
            };


            await bookService.Save(book);
            await LoadBooks();
            Clear();
        }

        public async Task Update()
        {
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
            book.ModifiedBy = userLoggedIn.FirstName;
            book.LastModified = DateTime.Now;
            await bookService.Update(SelectedBookItem.Id, book);
            await LoadBooks();
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

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
    public class ReturnViewModel : Screen
    {
        private IStudentService _studentService;
        private ITransactionService _transactionService;

        private string _selectedClassification;
        private string _idNumber;
        private string _fullName;
        private BindingList<TransactionModel> _borrowedBooks;

        private DateTime _dateBorrowed;
        private DateTime _dueDate;
        private string _violationMessage;


        private string _receipt;

        public ReturnViewModel(IStudentService studentService, ITransactionService transactionService)
        {
            _studentService = studentService;
            _transactionService = transactionService;
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
            get { return _selectedClassification; }
            set 
            { _selectedClassification = value;
                NotifyOfPropertyChange(() => SelectedClassification);
                NotifyOfPropertyChange(() => CanSearchID);
            }
        }


        public string IdNumber
        {
            get { return _idNumber; }
            set 
            { 
                _idNumber = value;
                NotifyOfPropertyChange(() => IdNumber);
                NotifyOfPropertyChange(() => CanSearchID);
            }
        }


        public string FullName
        {
            get { return _fullName; }
            set 
            { 
                _fullName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string _department;

        public string Department
        {
            get { return _department; }
            set 
            { 
                _department = value;
                NotifyOfPropertyChange(() => Department);
            }
        }


        public BindingList<TransactionModel> BorrowedBooks
        {
            get { return _borrowedBooks; }
            set 
            { 
                _borrowedBooks = value;
                NotifyOfPropertyChange(() => BorrowedBooks);
            }
        }

        private TransactionModel _selectedBorrowedBook;

        public TransactionModel SelectedBorrowedBook
        {
            get { return _selectedBorrowedBook; }
            set 
            { 
                _selectedBorrowedBook = value;
                DateBorrowed = _selectedBorrowedBook.DateBorrowed;
                DueDate = _selectedBorrowedBook.DueDate;

                NotifyOfPropertyChange(() => SelectedBorrowedBook);
                NotifyOfPropertyChange(() => CanGenerate);
                NotifyOfPropertyChange(() => CanReturn);
            }
        }



        public DateTime DateBorrowed
        {
            get { return _dateBorrowed; }
            set 
            { 
                _dateBorrowed = value;
                NotifyOfPropertyChange(() => DateBorrowed);
            }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set 
            { 
                _dueDate = value;
                NotifyOfPropertyChange(() => DueDate);
                NotifyOfPropertyChange(() => CanGenerate);
                NotifyOfPropertyChange(() => CanReturn);
            }
        }


        public string ViolationMessage
        {
            get { return _violationMessage; }
            set 
            { 
                _violationMessage = value;
                NotifyOfPropertyChange(() => ViolationMessage);
            }
        }


        public string Receipt
        {
            get { return _receipt; }
            set 
            { 
                _receipt = value;
                NotifyOfPropertyChange(() => Receipt);
            }
        }

        public async Task LoadBorrowedBooks()
        {
            var borrowedBookList = await _transactionService.GetBorrowedBooksByClassificationId(IdNumber);
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
                if(SelectedBorrowedBook != null && DueDate < DateTime.Now)
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
        public async Task SearchID()
        {
            if (SelectedClassification == null)
                return;

            if (SelectedClassification == "STUDENT")
            {
                var result = await _studentService.GetByStudentId(IdNumber);
                FullName = $"{result.LastName}, {result.FirstName}";
                Department = result.Department;
                
                await LoadBorrowedBooks();
            }
        }
        public void Generate()
        {
            // TODO: Create Generate report and show it to Receipt textbox
        }

        public async Task Return()
        {
            // TODO: Save returning book to API
            TransactionModel transaction = new TransactionModel();
            transaction.BookId = SelectedBorrowedBook.BookId;
            transaction.CallNumber = SelectedBorrowedBook.CallNumber;
            transaction.ClassificationId = SelectedBorrowedBook.ClassificationId;
            transaction.Status = "RETURNED";
            await _transactionService.Return(SelectedBorrowedBook.Id, transaction);
        }

        public void Export()
        {
            // TODO: Export Receipt file
        }

        public void Clear()
        {
            //TODO: Clear all the fileds after.
        }
    }
}

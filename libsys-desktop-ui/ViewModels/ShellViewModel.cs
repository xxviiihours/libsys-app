﻿using Caliburn.Micro;
using libsys_desktop_ui.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private MainViewModel _mainViewModel;
        private BookViewModel _bookViewModel;
        private StudentViewModel _studentViewModel;
        private TransactionViewModel _transactionModel;

        private IEventAggregator _events;
        public ShellViewModel(IEventAggregator events, MainViewModel mainViewModel,
            BookViewModel bookViewModel, StudentViewModel studentViewModel, TransactionViewModel transactionModel)
        {
            _events = events;
            _mainViewModel = mainViewModel;
            _bookViewModel = bookViewModel;
            _studentViewModel = studentViewModel;
            _transactionModel = transactionModel;

            _events.Subscribe(this);

            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_transactionModel);
        }
    }
}

using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace libsys_desktop_ui.ViewModels
{
    public class MessageViewModel : Screen
    {

        public string Header { get; private set; }
        public string Message { get; private set; }

        public string FontColor { get; private set; }

        public void UpdateMessage(string header, string message, string fontColor)
        {
            Header = header;
            Message = message;
            FontColor = fontColor;

            NotifyOfPropertyChange(() => Header);
            NotifyOfPropertyChange(() => Message);
            NotifyOfPropertyChange(() => FontColor);
        }

        public void Close()
        {
            TryCloseAsync();
        }
    }
}

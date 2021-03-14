using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui.Models
{
    public class StudentDisplayModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        
        private int borrowLimit;

        public int BorrowLimit
        {
            get { return borrowLimit; }
            set 
            { 
                borrowLimit = value;
                OnPropertyChanged(nameof(BorrowLimit)); 
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

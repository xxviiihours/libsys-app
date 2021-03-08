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
    public class StudentViewModel : Screen
    {

        private IStudentService _studentService;

        private string _studentId;
        private string _firstName;
        private string _lastName;
        private string _gender;
        private string _yearLevel;
        private string _course;
        private string _department;
        private string _phoneNumber;
        private string _emailAddress;


        private string _search;

        private BindingList<StudentModel> _students;
        public StudentViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task LoadStudents()
        {
            var studentList = await _studentService.GetAll();
            Students = new BindingList<StudentModel>(studentList);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadStudents();
        }

        public string StudentId
        {
            get { return _studentId; }
            set 
            { 
                _studentId = value;
                NotifyOfPropertyChange(() => StudentId);
            }
        }


        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set 
            { 
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }


        public string Gender
        {
            get { return _gender; }
            set 
            { 
                _gender = value;
                NotifyOfPropertyChange(() => Gender);
            }
        }


        public string YearLevel
        {
            get { return _yearLevel; }
            set 
            { 
                _yearLevel = value;
                NotifyOfPropertyChange(() => YearLevel);
            }
        }


        public string Course
        {
            get { return _course; }
            set 
            {
                _course = value;
                NotifyOfPropertyChange(() => Course);
            }
        }


        public string Department
        {
            get { return _department; }
            set 
            { 
                _department = value;
                NotifyOfPropertyChange(() => Department);
            }
        }


        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set 
            { 
                _phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
            }
        }


        public string EmailAddress
        {
            get { return _emailAddress; }
            set 
            { 
                _emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
            }
        }

        public string Search
        {
            get { return _search; }
            set 
            { 
                _search = value;
                NotifyOfPropertyChange(() => Search);
            }
        }

        //Datagridview

        public BindingList<StudentModel> Students
        {
            get { return _students; }
            set 
            { 
                _students = value;
                NotifyOfPropertyChange(() => Students);
            }
        }

        public async Task Save()
        {
            StudentModel student = new StudentModel
            {
                StudentId = StudentId,
                FirstName = FirstName,
                LastName = LastName,
                Gender = Gender,
                YearLevel = YearLevel,
                Course = Course,
                Department = Department,
                PhoneNumber = PhoneNumber,
                EmailAddress = EmailAddress
            };
            await _studentService.Save(student);
            await LoadStudents();
        }
    }
}

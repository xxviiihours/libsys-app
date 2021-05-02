using Caliburn.Micro;
using libsys_desktop_ui.Interfaces;
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

        private readonly IStudentService studentService;
        private readonly IExcelReportService excelReportService;
        private readonly IDataTableConverterHelper dataTableConverterHelper;
        private string studentId;
        private string firstName;
        private string lastName;
        private string gender;
        private string yearLevel;
        private string course;
        private string department;
        private string phoneNumber;
        private string emailAddress;

        private string search;

        private string errorMessage;

        private BindingList<StudentModel> students;

        private StudentModel selectedStudent;

        public StudentViewModel(IStudentService studentService, IExcelReportService excelReportService, IDataTableConverterHelper dataTableConverterHelper)
        {
            this.studentService = studentService;
            this.excelReportService = excelReportService;
            this.dataTableConverterHelper = dataTableConverterHelper;
        }

        public async Task LoadStudents()
        {
            try
            {
                ErrorMessage = "";
                var studentList = await studentService.GetAll();
                if (studentList.Count <= 0)
                {
                    return;
                }
                Students = new BindingList<StudentModel>(studentList);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadStudents();
        }

        public string StudentId
        {
            get { return studentId; }
            set 
            { 
                studentId = value;
                NotifyOfPropertyChange(() => StudentId);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set 
            { 
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string LastName
        {
            get { return lastName; }
            set 
            { 
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string Gender
        {
            get { return gender; }
            set 
            { 
                gender = value;
                NotifyOfPropertyChange(() => Gender);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string YearLevel
        {
            get { return yearLevel; }
            set 
            { 
                yearLevel = value;
                NotifyOfPropertyChange(() => YearLevel);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string Course
        {
            get { return course; }
            set 
            {
                course = value;
                NotifyOfPropertyChange(() => Course);
                NotifyOfPropertyChange(() => CanSave);
            }
        }


        public string Department
        {
            get { return department; }
            set 
            { 
                department = value;
                NotifyOfPropertyChange(() => Department);
                NotifyOfPropertyChange(() => CanSave);
            }
        }


        public string PhoneNumber
        {
            get { return phoneNumber; }
            set 
            { 
                phoneNumber = value;
                NotifyOfPropertyChange(() => PhoneNumber);
                NotifyOfPropertyChange(() => CanSave);
            }
        }


        public string EmailAddress
        {
            get { return emailAddress; }
            set 
            { 
                emailAddress = value;
                NotifyOfPropertyChange(() => EmailAddress);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string Search
        {
            get { return search; }
            set 
            { 
                search = value;
                NotifyOfPropertyChange(() => Search);
            }
        }

        //Datagridview

        public BindingList<StudentModel> Students
        {
            get { return students; }
            set 
            { 
                students = value;
                NotifyOfPropertyChange(() => Students);
            }
        }

        public StudentModel SelectedStudent
        {
            get { return selectedStudent; }
            set 
            { 
                selectedStudent = value;
                FillStudentData();
                NotifyOfPropertyChange(() => SelectedStudent);
                NotifyOfPropertyChange(() => CanUpdate);
            }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
                NotifyOfPropertyChange(() => IsErrorVisible);
            }
        }

        public bool CanSave
        {
            get
            {
                if(SelectedStudent == null &&
                    StudentId?.Length > 0 &&
                    FirstName?.Length > 0 &&
                    LastName?.Length > 0 &&
                    Gender?.Length > 0 &&
                    YearLevel?.Length > 0 &&
                    Course?.Length > 0 &&
                    Department?.Length > 0 &&
                    PhoneNumber?.Length > 0 &&
                    EmailAddress?.Length > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public bool CanUpdate
        {
            get
            {
                if(SelectedStudent != null)
                {
                    return true;
                }
                return false;
            }
        }
        public bool IsErrorVisible
        {
            get
            {
                if (ErrorMessage?.Length > 0)
                {
                    return true;
                }
                return false;
            }
        }
        public void FillStudentData()
        {
            StudentId = SelectedStudent?.StudentId;
            FirstName = SelectedStudent?.FirstName;
            LastName = SelectedStudent?.LastName;
            Gender = SelectedStudent?.Gender;
            YearLevel = SelectedStudent?.YearLevel;
            Course = SelectedStudent?.Course;
            Department = SelectedStudent?.Department;
            PhoneNumber = SelectedStudent?.PhoneNumber;
            EmailAddress = SelectedStudent?.EmailAddress;
        }

        public async Task Save()
        {
            try
            {
                ErrorMessage = "";
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
                    EmailAddress = EmailAddress,
                    BorrowLimit = 2
                };
                await studentService.Save(student);
                await LoadStudents();
                Clear();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public async Task Update()
        {
            try
            {
                ErrorMessage = "";
                StudentModel studentModel = new StudentModel
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

                await studentService.Update(SelectedStudent.Id, studentModel);
                await LoadStudents();
                Clear();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        public void Clear()
        {
            SelectedStudent = null;
            StudentId = "";
            FirstName = "";
            LastName = "";
            Gender = "";
            YearLevel = "";
            Course = "";
            Department = "";
            PhoneNumber = "";
            EmailAddress = "";
            ErrorMessage = "";
            //excelReportService.GenerateExcel(dataTableConverterHelper.ConvertToDataTable(Students), "");
        }
    }
}

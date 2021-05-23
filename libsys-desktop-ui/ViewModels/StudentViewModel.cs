using Caliburn.Micro;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using libsys_desktop_ui.Interfaces;
using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace libsys_desktop_ui.ViewModels
{
    public class StudentViewModel : Screen
    {

        private readonly IStudentService studentService;
        private readonly IPDFHelper pdfHelper;
        private readonly IUserLoggedInModel userLoggedInModel;
        private readonly IWindowManager window;
        private string studentId;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string emailAddress;

        private string search;

        private string errorMessage;

        private readonly MessageViewModel Message;
        private BindingList<StudentModel> students;
        private StudentModel selectedStudent;

        public StudentViewModel(IStudentService studentService, IUserLoggedInModel userLoggedInModel,
            IWindowManager window, MessageViewModel message, IPDFHelper pdfHelper)
        {
            this.studentService = studentService;
            this.userLoggedInModel = userLoggedInModel;
            this.window = window;
            this.pdfHelper = pdfHelper;
            Message = message;
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
                var result = Regex.Replace(value, @"\d+$", "");
                firstName = result;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string LastName
        {
            get { return lastName; }
            set 
            {
                var result = Regex.Replace(value, @"\d+$", "");
                lastName = result;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public BindingList<string> GenderTypes
        {
            get
            {
                return new BindingList<string>(
                  new string[] { "MALE", "FEMALE", "OTHERS" });

            }
        }

        private string selectedGenderType;
        public string SelectedGenderType
        {
            get { return selectedGenderType; }
            set
            {
                selectedGenderType = value;
                NotifyOfPropertyChange(() => SelectedGenderType);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public BindingList<string> GradeLevels
        {
            get
            {
                return new BindingList<string>(
                  new string[] 
                  { 
                      "GRADE 7",
                      "GRADE 8", 
                      "GRADE 9",
                      "GRADE 10",
                      "GRADE 11",
                      "GRADE 12"
                  });

            }
        }

        private string selectedGradeLevel;
        public string SelectedGradeLevel
        {
            get { return selectedGradeLevel; }
            set
            {
                selectedGradeLevel = value;
                NotifyOfPropertyChange(() => SelectedGradeLevel);
                NotifyOfPropertyChange(() => CanSave);
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set 
            {
                var result = Regex.Replace(value, @"[^0-9]", "");
                phoneNumber = result;
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
                NotifyOfPropertyChange(() => CanGoSearch);
            }
        }

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
                NotifyOfPropertyChange(() => CanGenerateCard);
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
        public bool CanGenerateCard 
        {
            get 
            {
                if(SelectedStudent == null)
                {
                    return false;
                }
                return true;
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
                    SelectedGenderType?.Length > 0 &&
                    SelectedGradeLevel?.Length > 0 &&
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

        public bool CanGoSearch
        {
            get
            {
                if(Search?.Length > 0)
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
            if (SelectedStudent == null)
                return;
            StudentId = SelectedStudent?.StudentId;
            FirstName = SelectedStudent?.FirstName;
            LastName = SelectedStudent?.LastName;
            SelectedGenderType = SelectedStudent?.Gender;
            SelectedGradeLevel = SelectedStudent?.GradeLevel;
            PhoneNumber = SelectedStudent.PhoneNumber;
            EmailAddress = SelectedStudent?.EmailAddress;
        }

        
        public void GenerateCard()
        {
            string cardTemplate = $"Student ID: {SelectedStudent?.StudentId}\n" +
                                  $"Full Name: {SelectedStudent?.FirstName} {SelectedStudent?.LastName}\n" +
                                  $"Gender: {SelectedStudent?.Gender} \n" +
                                  $"Grade Level: {SelectedStudent?.GradeLevel}\n\n" +
                                  $"Phone Number: {SelectedStudent?.PhoneNumber}\n" +
                                  $"Email Address: {SelectedStudent?.EmailAddress}\n\n" +
                                  $"Issued By: {userLoggedInModel.FirstName}\n" +
                                  $"Valid until: {DateTime.Now.AddYears(1):MM/dd/yyyy}";
            var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            pdfHelper.GenerateReport(cardTemplate, $"{selectedStudent?.StudentId}_LibraryCard_{DateTime.Now:MM/dd/yyyy}", font);
            Message.UpdateMessage("Generate Library Card", "Generate success.", "#00c853");
            window.ShowDialogAsync(Message, null, null);
        }

        public async Task GoSearch()
        {
            try
            {
                ErrorMessage = "";
                var student = await studentService.GetByStudentId(Search);

                Students = new BindingList<StudentModel>(student);
            }
            catch (Exception ex)
            {
                //Create error message if no student id found.
                ErrorMessage = $"ID Number {ex.Message.ToLower()}.";
                Clear();
            }
        }
        public async Task Save()
        {
            try
            {
                ErrorMessage = "";
                if(PhoneNumber?.Length > 11)
                {
                    ErrorMessage = "Phone number format is not recognized. Please check the number again.";
                    return;
                }
                StudentModel student = new StudentModel
                {
                    StudentId = StudentId,
                    FirstName = FirstName.ToUpper(),
                    LastName = LastName.ToUpper(),
                    Gender = SelectedGenderType.ToUpper(),
                    GradeLevel = SelectedGradeLevel.ToUpper(),
                    PhoneNumber = PhoneNumber,
                    EmailAddress = EmailAddress.ToUpper(),
                    BorrowLimit = 2,
                    ModifiedBy = userLoggedInModel.FirstName.ToUpper(),
                    LastModified = DateTime.Now
                    
                };
                await studentService.Save(student);
                await LoadStudents();
                Message.UpdateMessage("Save student information", "Save success.", "#00c853");
                await window.ShowDialogAsync(Message, null, null);
                Clear();
            }
            catch (Exception ex)
            {
                Message.UpdateMessage("Save student information", $"Save failed. {ex.Message}.", "#ef5350");
                await window.ShowDialogAsync(Message, null, null);
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
                    FirstName = FirstName.ToUpper(),
                    LastName = LastName.ToUpper(),
                    Gender = SelectedGenderType.ToUpper(),
                    GradeLevel = SelectedGradeLevel.ToUpper(),
                    PhoneNumber = PhoneNumber,
                    EmailAddress = EmailAddress.ToUpper(),
                    ModifiedBy = userLoggedInModel.FirstName.ToUpper(),
                    LastModified = DateTime.Now
                };

                await studentService.Update(SelectedStudent.Id, studentModel);
                await LoadStudents();
                Message.UpdateMessage("Update student information", "Update success.", "#00c853");
                await window.ShowDialogAsync(Message, null, null);
                Clear();
            }
            catch (Exception ex)
            {
                Message.UpdateMessage("Update student information", $"Update failed. {ex.Message}.", "#ef5350");
                await window.ShowDialogAsync(Message, null, null);
            }
        }

        public void Clear()
        {
            SelectedStudent = null;
            StudentId = "";
            FirstName = "";
            LastName = "";
            SelectedGenderType = null;
            SelectedGradeLevel = null;
            PhoneNumber = "";
            EmailAddress = "";
            ErrorMessage = "";
            //excelReportService.GenerateExcel(dataTableConverterHelper.ConvertToDataTable(Students), "");
        }
    }
}

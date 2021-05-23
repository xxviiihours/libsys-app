using libsys_desktop_ui_library.Interfaces;
using libsys_desktop_ui_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace libsys_desktop_ui_library.Services
{
    public class StudentService : IStudentService
    {
        private readonly IAPIHelper apiHelper;

        public StudentService(IAPIHelper apiHelper)
        {
            this.apiHelper = apiHelper;
        }

        public async Task<List<StudentModel>> GetAll()
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.GetAsync("/api/v2/students"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<StudentModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task<List<StudentModel>> GetByStudentId(string studentId)
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.GetAsync($"/api/v2/students/student-id?studentId={studentId}"))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = await responseMessage.Content.ReadAsAsync<List<StudentModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task Save(StudentModel studentModel)
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.PostAsJsonAsync("/api/v2/students/save", studentModel))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    //TODO: Create a response message or something.
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }

        public async Task Update(int id, StudentModel studentModel)
        {
            using (HttpResponseMessage responseMessage = await apiHelper.HttpClient.PutAsJsonAsync($"/api/v2/students/update?id={id}", studentModel))
            {
                if (responseMessage.IsSuccessStatusCode)
                {
                    //TODO: Create a logger
                }
                else
                {
                    throw new Exception(responseMessage.ReasonPhrase);
                }
            }
        }
    }
}

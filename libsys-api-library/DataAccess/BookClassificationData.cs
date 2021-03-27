using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAccess
{
    public class BookClassificationData
    {
        private readonly IConfiguration configuration;

        public BookClassificationData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public List<BookClassificationModel> GetAllBookClassification()
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);

            var output = sql.LoadData<BookClassificationModel, dynamic>("dbo.spGetAllBookClassification", new { }, "libsys-data");
            return output;
        }
    }
}

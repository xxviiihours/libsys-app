using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAccess
{
    public class BookClassificationData
    {
        public List<BookClassificationModel> GetAllBookClassification()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<BookClassificationModel, dynamic>("dbo.spGetAllBookClassification", new { }, "libsys-data");
            return output;
        }
    }
}

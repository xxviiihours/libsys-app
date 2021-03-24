using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAccess
{
    public class ViolationData
    {
        public void SaveViolation(ViolationModel violationModel)
        {
            SqlDataAccess sql = new SqlDataAccess();
            sql.SaveData("dbo.spInsertViolationDetails", violationModel, "libsys-data");
        }
    }
}

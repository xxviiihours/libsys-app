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
    public class ViolationData
    {
        private readonly IConfiguration configuration;

        public ViolationData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void SaveViolation(ViolationModel violationModel)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);
            sql.SaveData("dbo.spInsertViolationDetails", violationModel, "libsys_data");
        }
    }
}

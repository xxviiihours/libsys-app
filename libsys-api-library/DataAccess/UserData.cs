using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.DataAcess
{
    public class UserData
    {
        private readonly IConfiguration configuration;

        public UserData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);

            var param = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", param, "libsys-data");
            
            return output;
        }
    }
}

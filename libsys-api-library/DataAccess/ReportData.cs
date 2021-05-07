using libsys_api_library.Internal.DataAccess;
using libsys_api_library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace libsys_api_library.DataAccess
{
    public class ReportData
    {
        private readonly IConfiguration configuration;
        public ReportData(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<TransactionModel> GetAllBorrowedBooks()
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);

            var output = sql.LoadData<TransactionModel, dynamic>("dbo.spReportGetAllBorrowedBooks", new { }, "libsys_data");
            return output;
        }

        public List<TransactionModel> GetAllOverDuedBooks()
        {
            SqlDataAccess sql = new SqlDataAccess(configuration);

            var output = sql.LoadData<TransactionModel, dynamic>("dbo.spReportGetAllOverduedBooks", new { }, "libsys_data");
            foreach(var item in output)
            {
                if(item.DueDate > DateTime.Now)
                {
                    return output;
                }
            }
            return output;
        }
    }
}

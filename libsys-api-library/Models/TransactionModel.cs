﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libsys_api_library.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public string CallNumber { get; set; }

        public string BookTitle { get; set; }

        public string UserId { get; set; }

        public string ClassificationId { get; set; }

        public string ClassificationType { get; set; }

        public string Status { get; set; }

        public DateTime DateBorrowed { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}

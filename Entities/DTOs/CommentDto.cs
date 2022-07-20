using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CommentDto:IDto
    {
        public int CommentID { get; set; }
        public int ProductId { get; set; }
        public int UserID { get; set; }
        public int Score { get; set; }
        public string CommentHeading { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }
        public string ProductName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
    }
}

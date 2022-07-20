using Core.Entities;
using System;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int CommentID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int Score { get; set; }
        public string CommentHeading { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }
    }
}

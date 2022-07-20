using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class SellerAnswer:IEntity
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string Answer { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}

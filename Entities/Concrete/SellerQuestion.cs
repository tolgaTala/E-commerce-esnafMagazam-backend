using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class SellerQuestion:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Question { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }    


    }
}

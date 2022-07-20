using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Order :IEntity
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public string AddressHead { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressDetail { get; set; }
        public bool  Status { get; set; }
        public double Amount { get; set; }
    }
}

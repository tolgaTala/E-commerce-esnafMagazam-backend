using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Address:IEntity
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressHead { get; set; }
        public string AddressDetail { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public bool Status { get; set; }
    }
}

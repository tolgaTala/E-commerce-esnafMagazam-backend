using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class esnafOrdersDto : IDto
    {
        public int userId { get; set; }
        public int productID { get; set; }
        public int orderId { get; set; }
        public int EsnafId { get; set; }
        public string companyName { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public Boolean status { get; set; }
        public int quantity { get; set; }
        public string PhoneNumber { get; set; }
        public string ProductName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public string AddressHead { get; set; }

    }
}

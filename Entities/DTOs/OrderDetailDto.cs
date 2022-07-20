using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class OrderDetailDto:IDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OrderDetailId { get; set; }
        public DateTime OrderDate { get; set; }
        public string AddressHead { get; set; }        
        public int ProductId { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Boolean Status { get; set; }
    }
}

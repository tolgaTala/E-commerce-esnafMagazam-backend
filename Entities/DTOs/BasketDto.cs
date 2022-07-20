using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BasketDto:IDto
    {
        public int BasketId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string CompanyName { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}

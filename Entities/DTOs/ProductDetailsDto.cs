using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailsDto:IDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int UnitInStock { get; set; }
        public double Price { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string UserCompany { get; set; }
        public string ImagePath { get; set; }
        public string ProductDescription { get; set; }
        public DateTime AddedTime { get; set; }
        public int LikeNumber { get; set; }
        public bool Status { get; set; }
        public int StarRating { get; set; }

    }
}

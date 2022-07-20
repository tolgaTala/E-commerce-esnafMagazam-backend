using Core.Entities;
using Entities.Concrete;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int ProductID { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }       
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int UnitInStock { get; set; }
        public DateTime AddedTime { get; set; }
        public string ImagePath { get; set; }
        public string ProductDescription { get; set; }
        public int LikeNumber { get; set; }
        public bool Status { get; set; }
        public int StarRating { get; set; }
    }
}

using Core.Entities;
using System;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
   public class Category:IEntity
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
    }
}

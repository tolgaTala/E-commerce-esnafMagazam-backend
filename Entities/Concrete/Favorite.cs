using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Favorite : IEntity
    {
        public int FavoriteID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Artisan:IEntity
    {
        public int ArtisanId { get; set; }
        public string TaxNo { get; set; }
        public string CompanyName { get; set; }
    }
}

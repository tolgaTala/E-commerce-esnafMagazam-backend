using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class esnafAnswerDto : IDto
    {
        public int Id { get; set; }
        public int sellerId { get; set; }
        public int productId { get; set; }
        public int customerId { get; set; }
        public string Quastion { get; set; }
        public DateTime QuastionDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Boolean status { get; set; }

    }
}

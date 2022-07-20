using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class QuestionAndAnswerDto:IDto
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public int SellerId { get; set; }
        public int ProductId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public DateTime QuestionDate { get; set; }
        public DateTime AnswerDate { get; set; }


    }
}

using Domain.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ViewModels
{
     public class SubTaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoStatus SubTodoStatus { get; set; }
        public int TaskId { get; set; }
    }
}

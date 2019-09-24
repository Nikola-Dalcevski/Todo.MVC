using Domain.Enumerators;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ViewModels
{
    public class TodoTaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public TodoStatus TodoStatus { get; set; }
        public string Type { get; set; }
    }
}

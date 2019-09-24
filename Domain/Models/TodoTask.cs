using Domain.Enumerators;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Models
{
    public class TodoTask 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public TodoStatus TodoStatus { get; set; }

        //navigation property

        public List<SubTodoTask> SubTasks { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int TaskTypeId { get; set; }
        public TodoTaskType TaskType { get; set; }
    }
}

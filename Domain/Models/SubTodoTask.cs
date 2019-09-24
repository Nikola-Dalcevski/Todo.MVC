using Domain.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class SubTodoTask 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoStatus SubTodoStatus { get; set; }

        //navigation properties

       
        public int TaskId { get; set; }
        public TodoTask Task { get; set; }
    }
}

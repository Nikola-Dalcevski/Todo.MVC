using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class User  : IdentityUser
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //navigation properties
        public List<TodoTask> Tasks { get; set; }
    }
}

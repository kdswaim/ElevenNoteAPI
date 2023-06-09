using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set;}
        public string Email {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime DateCreated {get; set;}
    }
}
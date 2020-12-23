using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Person : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateTimeOfBirth { get; set; }
        public ICollection<Quality> Reviews { get; set; }

        /*public Person(string name, string surname, Gender gender, DateTime dateTimeOfBirth)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Gender = gender;
            DateTimeOfBirth = dateTimeOfBirth;
        }*/

    }

    public enum Gender
    {
        None,
        Male,
        Female,
        Other
    }
}

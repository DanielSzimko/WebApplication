using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication_Common
{
    public class Person
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {DateOfBirth}";
        }

    }
}

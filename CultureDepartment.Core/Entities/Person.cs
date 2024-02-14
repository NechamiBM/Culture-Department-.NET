<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Entities
{
    public class Person
    {
        public string TZ { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private DateOnly _birthDate;
        public int Age { get => DateTime.Now.Year - _birthDate.Year; }

        public Person()
        {

        }
        public Person(string tz, DateOnly birthDate)
        {
            TZ = tz;
            _birthDate = birthDate;
        }
        public Person(string tz, string firstName, string lastName, DateOnly birthDate):this(tz,birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureDepartment.Core.Entities
{
    public class Person
    {
        public string TZ { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private DateOnly _birthDate;
        public int Age { get => DateTime.Now.Year - _birthDate.Year; }

        public Person()
        {

        }
        public Person(string tz, DateOnly birthDate)
        {
            TZ = tz;
            _birthDate = birthDate;
        }
        public Person(string tz, string firstName, string lastName, DateOnly birthDate):this(tz,birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
>>>>>>> d3497faa34be117e593f27b4df61939f9e55a9fd

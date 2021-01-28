using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Model
{
    public class Patient
    {
        public Patient(int id, string firstName, string middleName, string lastName, string contactNo, DateTime birthday, char sex)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            ContactNo = contactNo;
            Birthday = birthday;
            Sex = sex;
        }

        public void UpdatePatient(int id, string firstName, string middleName, string lastName, string contactNo, DateTime birthday, char sex)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            ContactNo = contactNo;
            Birthday = birthday;
            Sex = sex;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string ContactNo { get; private set; }
        public DateTime Birthday { get; private set; }
        public char Sex { get; private set; }

    }
}

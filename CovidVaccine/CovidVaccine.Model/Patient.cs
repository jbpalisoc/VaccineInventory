using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get;set; }
        public DateTime Birthday { get;set; }
        public char Sex { get; set; }
    }
}

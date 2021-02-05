using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccine.Model
{
    public class Vaccine
    {
        public Vaccine(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public void UpdateVaccine(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}

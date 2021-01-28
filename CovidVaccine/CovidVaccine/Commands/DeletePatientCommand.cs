using CovidVaccine.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Commands
{
    public class DeletePatientCommand : IRequest<Patient>
    {
        public int Id { get; }

        public DeletePatientCommand(int id)
        {
            Id = id;
        }

    }
}

using CovidVaccine.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidVaccine.Commands
{
    public class DeleteVaccineCommand : IRequest<Vaccine>
    {
        public int Id { get; }

        public DeleteVaccineCommand(int id)
        {
            Id = id;
        }
    }
}

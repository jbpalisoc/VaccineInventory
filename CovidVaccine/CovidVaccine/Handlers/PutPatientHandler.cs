﻿using CovidVaccine.Commands;
using CovidVaccine.Models;
using CovidVaccine.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CovidVaccine.Handlers
{
    public class PutPatientHandler : IRequestHandler<PutPatientCommand, Patient>
    {
        private readonly IRepository _repository;
        public PutPatientHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> Handle(PutPatientCommand request, CancellationToken cancellationToken)
        {
            var model = await _repository.SelectById<Patient>(request.Id);

            if(model == null)
            {
                return null;
            }
            else
            {
                model.FirstName = request.FirstName;
                model.MiddleName = request.MiddleName;
                model.LastName = request.LastName;
                model.Birthday = request.Birthday;
                model.ContactNo = request.ContactNo;
                model.Sex = request.Sex;

                await _repository.UpdateAsync<Patient>(model);
                return model;

            }

            //var model = patient != null ? await _repository.SelectById<Patient>(request.Id) : null;
            
            
            //return model == null ? null : model;
        }
    }
}
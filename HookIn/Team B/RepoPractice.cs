using Domain.Models;
using Services.Repositories;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_B
{
    public class RepoPractice
    {
        private HRMSDBContext db = new HRMSDBContext();

        public Person CreatePerson (int companyID, string firstName, string lastname, DateTime dateOfBirth, string phone, string email)
        {
            IPersonRepository personRepo = new PersonRepository(db);

            var person = new Person
            {
                CompanyId = companyID,
                Firstname = firstName,
                Lastname = lastname,
                DateOfBirth = dateOfBirth,
                Phone = phone,
                Email = email
            };
            personRepo.Add(person);

            return person;
        }

        public Position CreatePosition (string name, string description)
        {
            IPositionRepository positionRepo = new PositionRepository(db);

            var position = new Position_Sales
            {
                Name = name,
                Description = description
            };
                                 
            positionRepo.Add(position);
            
            return position;
        }
    }
}

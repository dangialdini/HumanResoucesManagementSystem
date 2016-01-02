using Domain.Models;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace UI.Api
{
    public class PositionController : ApiController
    {
        private readonly IPositionService _servicePosition;

        public class EmployeeInPositionVM {

            private int _id;
            private int _employeeId;
            private int _positionId;
            private bool _active;

            public EmployeeVM Employee { get; set; }
            public PositionVM Position { get; set; }

            public int Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }
            public int EmployeeId
            {
                get
                {
                    return _employeeId;
                }
                set
                {
                    _employeeId = value;
                }
            }             
            public int PositionId
            {
                get
                {
                    return _positionId;
                }
                set
                {
                    _positionId = value;
                }
            }        
          
            public bool Active
            {
                get
                {
                    return _active;
                }
                set
                {
                    _active = value;
                }
            }
        }

        public class PositionVM
        {
            private int _id;
            private string _name;
            public int Id {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }


        }
        public class EmployeeVM
        {
            private int _id;
            private string _firstName;
            private string _lastName;

            public int Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }
            public string FirstName
            {
                get
                {
                    return _firstName;
                }
                set
                {
                    _firstName = value;
                    
                }
            }
            public string LastName
            {
                get
                {
                    return _lastName;
                }
                set
                {
                    _lastName = value;
                }
            }
        }
 

        public PositionController(IPositionService servicePosition)
        {
            _servicePosition = servicePosition;
        }
        
        [HttpGet]
        [Route("api/Positions/GetPositions")]
        public IHttpActionResult GetPositions()
        {
            var result = _servicePosition.Positions
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description

                })
                .ToList().OrderBy(p=> p.Name);
            return Ok(result);

        } 

        [HttpGet]
        [Route("api/Positions/Read")]
        public IHttpActionResult Read()
        {
            var result = _servicePosition.GetAllEmployeeInPosition()
                .Select(e => new EmployeeInPositionVM
                {
                    Id = e.Id,
                    EmployeeId = e.EmployeeId,
                    Employee = new EmployeeVM(){Id=e.Employee.Id, FirstName= e.Employee.Firstname, LastName=e.Employee.Lastname},
                    PositionId = e.PositionId,
                    Position = new PositionVM(){Id= e.Position.Id, Name= e.Position.Name},
                    Active = e.Active,
                   
                }).ToList().OrderBy(e => e.Id);
                return Ok(result);                
        }
                                

        [ResponseType(typeof(EmployeeInPositionVM)),HttpPost]
        [Route("api/Positions/RegisterEmployeeInPosition")]
        public IHttpActionResult RegisterEmployeeInPosition(EmployeeInPositionVM m)
        {
            m.Employee.Id = m.EmployeeId;
            m.Position.Id = m.PositionId;
            var eip = _servicePosition.RegisterEmployeeInPosition(m.EmployeeId, m.PositionId, m.Active);

            m.Id = eip.Id;
            m.Employee.FirstName = eip.Employee.Firstname;
            m.Employee.LastName = eip.Employee.Lastname;
            m.Position.Name = eip.Position.Name;

            return Created<EmployeeInPositionVM>(Request.RequestUri + m.Id.ToString(), m);           
        }

        [ResponseType(typeof(EmployeeInPositionVM)), HttpPut]
        [Route("api/Positions/Update")]
        public IHttpActionResult Update(EmployeeInPositionVM m)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            m.Employee.Id = m.EmployeeId; 
            m.Position.Id = m.PositionId;
             
            _servicePosition.Update(m.Id, m.EmployeeId, m.PositionId, m.Active);
             
            //return Ok(m);
            return Update(m);
        }

        [ResponseType(typeof(EmployeeInPositionVM)), HttpDelete]
        [Route("api/Positions/Delete")]
        public IHttpActionResult Delete(EmployeeInPositionVM m)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _servicePosition.Delete(m.Id);         
            return Ok();
        }   

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
} 
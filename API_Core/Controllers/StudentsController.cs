using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// ADDED NAMESPACES
using API_Core.Models;
using API_Core.repository;
//

namespace API_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentRepository stRepo;

        public StudentsController(IStudentRepository _stRepo)
        {
            stRepo = _stRepo;
        }

        
        [HttpGet]
        public ActionResult getStudents()
        {
            return Ok(stRepo.getall());
        }
 
        
        [HttpGet("{StId}")]
        public ActionResult<Student> getStudentbyId(int StId)
        {
            var std = stRepo.getbyid(StId);

            if (std == null)            
                return NotFound();            

            return std;
        }


        [HttpPut("{StId}")]
        public ActionResult editStudent(int StId, Student std)
        {
            if (StId != std.StId)
            {
                return BadRequest();
            }

            try
            {
                stRepo.edit(std);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (stRepo.getbyid(StId) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public ActionResult<Student> addStudent(Student std)
        {
            stRepo.add(std);

            return std;
        }


        [HttpDelete("{StId}")]
        public ActionResult DeleteStudent(int StId)
        {
            var std = stRepo.getbyid(StId);
            if (std == null)
            {
                return NotFound();
            }

            stRepo.delete(std);

            return NoContent();
        }

    }
}

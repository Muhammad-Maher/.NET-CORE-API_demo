using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ADDED NAMESPACES
using API_Core.Models;
using Microsoft.EntityFrameworkCore;
//

namespace API_Core.repository
{
    public class studentRepository:IStudentRepository
    {
        TestContext db;
        public studentRepository(TestContext _db)
        {
            db = _db;
        }

        
        // GET ALL STUDENTS
        public List<Student> getall()
        {
            return db.Students.ToList();
        }


        // GET STUDENT BY ID
         public Student getbyid(int id)
        {
            return db.Students.Where(n => n.StId == id).FirstOrDefault();
        }


        // ADD STUDENT
        public void add(Student std)
        {
            db.Students.Add(std);
            db.SaveChangesAsync();            
        }

        // EDIT STUDENT
        public void edit(Student std)
        {
             db.Entry(std).State = EntityState.Modified;
             db.SaveChanges();
             
        }

        // DELETE STUDENT
        public void delete(Student std)
        {
            db.Students.Remove(std);
            db.SaveChanges();
        }
    }
}

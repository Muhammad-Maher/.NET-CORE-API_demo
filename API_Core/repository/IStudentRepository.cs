using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ADDED NAMESPACES
using API_Core.Models;
//


namespace API_Core.repository
{
   public interface IStudentRepository
    {
        List<Student> getall();
        Student getbyid(int id);
        void add(Student std);
        void edit(Student std);
        void delete(Student std);


    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithIssuesCore.Models
{
    public static class StudentDb
    {
        public async static Task<Student> Add(Student p, SchoolContext db)
        {
            //Add student to context
            db.Students.Add(p);
            await db.SaveChangesAsync();
            return p;
        }

        public async static Task<List<Student>> GetStudents(SchoolContext context)
        {
            return await (from s in context.Students
                          orderby s.Name ascending
                          select s).ToListAsync();
        }

        public async static Task<Student> GetStudent(SchoolContext context, int id)
        {
            Student p2 = await (from students in context.Students
                          where students.StudentId == id
                          select students).SingleAsync();
            return p2;
        }
    }
}

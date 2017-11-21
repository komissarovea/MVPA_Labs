using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Lab9.DataLayer.Repositories
{
    class StudentRepository : IRepository<Student>
    {
        CoursesContext context;

        public StudentRepository(CoursesContext context)
        {
            this.context = context;
        }

        public void Create(Student t)
        {
            context.Students.Add(t);
        }

        public void Delete(int id)
        {
            var student = context.Students.Find(id);
            context.Students.Remove(student);
        }

        public IEnumerable<Student> Find(Func<Student, bool> predicate)
        {
            return context.Students
                    .Include("Group")
                    .Where(predicate)
                    .ToList();
        }

        public Student Get(int id)
        {
            return context.Students.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students.Include("Group");
        }

        public void Update(Student t)
        {
            context.Entry<Student>(t).State = EntityState.Modified;
        }
    }
}

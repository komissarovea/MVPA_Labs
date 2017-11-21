using Lab9.DataLayer.EFContext;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9.DataLayer.Repositories
{
    public class EntityUnitOfWork : IUnitOfWork
    {
        CoursesContext context;
        GroupsRepository groupsRepository;
        StudentRepository studentsRepository;
        public EntityUnitOfWork(string name)
        {
            context = new CoursesContext(name);
        }
        public IRepository<Group> Groups
        {
            get
            {
                if (groupsRepository == null)
                    groupsRepository = new GroupsRepository(context);
                return groupsRepository;
            }
        }
        public IRepository<Student> Students
        {
            get
            {
                if (studentsRepository == null)
                    studentsRepository =
                    new StudentRepository(context);
                return studentsRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        //
        // Реализация интерфейса IDisposable
        // см. https://msdn.microsoft.com/ruru/library/system.idisposable(v=vs.110).aspx
        //
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

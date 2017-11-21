using System;
using System.Collections.Generic;
using System.Linq;
using Lab9.DataLayer.Interfaces;
using Lab9.DataLayer.Entities;
using Lab9.DataLayer.EFContext;
using System.Data.Entity;

namespace Lab9.DataLayer.Repositories
{
    class GroupsRepository : IRepository<Group>
    {
        CoursesContext context;

        public GroupsRepository(CoursesContext context)
        {
            this.context = context;
        }

        public void Create(Group t)
        {
            context.Groups.Add(t);
        }

        public void Delete(int id)
        {
            var group = context.Groups.Find(id);
            context.Groups.Remove(group);
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return context.Groups
                    .Include(g => g.Students)
                    .Where(predicate)
                    .ToList();
        }

        public Group Get(int id)
        {
            return context.Groups.Find(id);
        }

        public IEnumerable<Group> GetAll()
        {
            return context.Groups.Include(g => g.Students);
        }

        public void Update(Group t)
        {
            context.Entry<Group>(t).State = EntityState.Modified;
        }
    }
}

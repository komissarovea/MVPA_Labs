﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab9.DataLayer.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T t);
        void Update(T t);
        void Delete(int id);
    }
}

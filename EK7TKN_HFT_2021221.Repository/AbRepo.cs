using EK7TKN_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EK7TKN_HFT_2021221.Repository
{
    public abstract class AbRepo<T> : IRepository<T> where T : class
    {
        protected DbContext context;
        public AbRepo(DbContext Context)
        {
            context = Context;
        }
        public void Create(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Read(id));
            context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public abstract T Read(int id);

        public IQueryable<T> ReadAll()
        {
            return context.Set<T>();
        }

        public abstract void Update(T item);
    }
}

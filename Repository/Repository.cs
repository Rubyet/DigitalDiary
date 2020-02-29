using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalDiary.Repository
{
    public class Repository<TEntiry> : IRepository<TEntiry> where TEntiry:class
    {
        DigitalDiaryContext context;

        public Repository()
        {
            context = new DigitalDiaryContext();
        }

        public void Delete(int id)
        {
            context.Set<TEntiry>().Remove(this.Get(id));
            context.SaveChanges();
        }

        public TEntiry Get(int id)
        {
            return context.Set<TEntiry>().Find(id);
        }

        public IEnumerable<TEntiry> GetAll()
        {
            return context.Set<TEntiry>().ToList();
        }

        public void Insert(TEntiry entity)
        {
            context.Set<TEntiry>().Add(entity);
            context.SaveChanges();
        }

        //public TEntiry Search(int name)
        //{
        //    return context.Set<TEntiry>().Where(x=> x.Name == name);
        //}

        public void Update(TEntiry entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

        }
    }
}
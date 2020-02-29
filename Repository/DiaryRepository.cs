using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDiary.Repository
{
    public class DiaryRepository : Repository<Diary>, IDiaryRepository
    {
        DigitalDiaryContext context;

        public DiaryRepository()
        {
            context = new DigitalDiaryContext();
        }

        public IEnumerable<Diary> GetDiaries(int id)
        {
            return context.Set<Diary>().Where(x => x.UserID == id).ToList();
        }
    }
}
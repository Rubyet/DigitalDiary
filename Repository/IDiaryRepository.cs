using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalDiary.Repository
{
    interface IDiaryRepository:IRepository<Diary>
    {
        IEnumerable<Diary> GetDiaries(int id);
    }
}

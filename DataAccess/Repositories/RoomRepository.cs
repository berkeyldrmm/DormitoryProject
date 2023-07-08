using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(Context context) : base(context)
        {
        }

        public IQueryable<Room> GetRoomsWithStudents()
        {
            return Entity.Include(r => r.Students).AsQueryable();
        }

    }
}

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IRoomService : IGenericService<Room>
    {
        public void IncreaseandCheckNumberofStudent(Room room);
        public void DecreaseNumberofStudent(Room room);
        public void AddStudentToRoom(Room room, AppUser student);
        public Room GetOneWithStudents(int id);
        public IEnumerable<Room> GetAllWithStudents();
    }
}

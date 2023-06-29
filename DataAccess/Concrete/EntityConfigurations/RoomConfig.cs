using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntityConfigurations
{
    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            List<Room> rooms= new List<Room>();
            for (int i = 101; i <= 820; i++)
            {
                Room room= new Room() { 
                    Id=i,
                    RoomNo= i,
                    NumberOfStudents= 0,
                    Availability=true
                };
                room.Quota = i % 5 == 0 ? 7 : 4;
                rooms.Add(room);
                i = i % 100 == 20 ? i + 81 : i;
            }
            builder.HasData(rooms);
        }
    }
}

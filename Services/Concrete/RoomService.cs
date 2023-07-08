using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Components;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<bool> Create(Room entity)
        {
            return await _roomRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<Room> entity)
        {
            await _roomRepository.AddRangeAsync(entity);
        }

        public bool DeleteAsync(Room entity)
        {
            return _roomRepository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<Room> entity)
        {
            _roomRepository.DeleteRange(entity);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll().ToList();
        }

        public IEnumerable<Room> GetAllWithStudents() 
        {
            return _roomRepository.GetRoomsWithStudents().ToList();
        }

        public IEnumerable<Room> GetByCondition(Expression<Func<Room, bool>> expression)
        {
            return _roomRepository.GetByCondition(expression).ToList();
        }

        public async Task<Room> GetOne(int id)
        {
            return await _roomRepository.GetOneById(id);
        }

        public Room GetOneWithStudents(int id)
        {
            return _roomRepository.GetRoomsWithStudents().SingleOrDefault(r=>r.Id==id);
        }

        public bool Update(Room entity)
        {
            return _roomRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<Room> entity)
        {
            _roomRepository.UpdateRange(entity);
        }
        public void IncreaseandCheckNumberofStudent(Room room)
        {
            room.NumberOfStudents++;
            if(room.NumberOfStudents == room.Quota)
            {
                room.Availability = false;
            }
        }
        public void DecreaseNumberofStudent(Room room)
        {
            room.NumberOfStudents--;
            room.Availability = true;
        }
        public void AddStudentToRoom(Room room, AppUser student)
        {
            room.Students.Add(student);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.UpdateDTOs
{
    public class StudentUpdateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ParentName_Surname { get; set; }
        public string ParentPhoneNumber { get; set; }
        public int RoomId { get; set; }
        public string School { get; set; }
        public string Department { get; set; }
    }
}

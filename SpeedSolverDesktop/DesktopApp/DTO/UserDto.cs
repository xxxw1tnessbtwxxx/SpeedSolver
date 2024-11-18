using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverCore.DTO.User
{
    public class UserDto
    {

        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? PhoneNumber { get; set; }

    }
}

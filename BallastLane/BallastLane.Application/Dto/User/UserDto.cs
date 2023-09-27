using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Application.Dto.User
{
    public class UserDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }

    public class UserCreateDto : UserDto
    {
    }

    public class UserReadDto : UserDto
    {
        public int Id { get; set; }
    }

    public class UserUpdateDto : UserReadDto
    {
    }
}

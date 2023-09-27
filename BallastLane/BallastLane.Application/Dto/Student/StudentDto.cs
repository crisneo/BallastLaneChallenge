using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Application.Dto.Student
{
    public class StudentDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Code { get; set; }
    }

    public class StudentCreateDto : StudentDto
    {
    }

    public class StudentReadDto : StudentDto
    {
        public int Id { get; set; }
    }

    public class StudentUpdateDto : StudentReadDto
    { }
}

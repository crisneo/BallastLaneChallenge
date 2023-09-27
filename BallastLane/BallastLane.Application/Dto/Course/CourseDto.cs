using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallastLane.Application.Dto.Course
{
    public class CourseDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }
    }

    public class CourseCreateDto : CourseDto
    {

    }

    public class CourseReadDto : CourseDto
    {
        public int Id { get; set; }
    }

    public class CourseUpdateDto : CourseReadDto
    {
    }

    public class CourseCreateAndAddStudents
    {
        public CourseCreateDto Course { get; set; }
        public IList<int> StudendsIds { get; set; }
    }
}

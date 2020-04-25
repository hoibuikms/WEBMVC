﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEBMVC.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [DisplayName("Course Name")]
        [Required(ErrorMessage = "Course Name is Required.")]
        [StringLength(10)]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Credits is Required.")]
        [StringLength(10)]
        public string Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
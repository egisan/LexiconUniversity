using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CourseId { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        // Egidio is here
        //navigational properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}

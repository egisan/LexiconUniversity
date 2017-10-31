using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconUniversity.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
       // public string FullName(string sep = " ") => (FirstName + sep + LastName); //{ get { return string.Format("{0} {1}", FirstName, LastName); } }

        //navigational properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
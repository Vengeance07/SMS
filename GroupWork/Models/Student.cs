using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Contact { get; set; }
        public String Email { get; set; }
        public String EnrollDate { get; set; }
        public int AddressId { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Addresses { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Courses { get; set; }

        [NotMapped]
        public String Street { get; set; }
        [NotMapped]
        public String CourseName { get; set; }

        List<Student> list = new List<Student>();
        public List<Student> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student stud = new Student();
                stud.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                if (dt.Columns.Contains("Street"))
                {
                    stud.Street = dt.Rows[i]["Street"].ToString();
                }
                if (dt.Columns.Contains("CourseName"))
                {
                    stud.CourseName = dt.Rows[i]["CourseName"].ToString();
                }
                stud.Name = dt.Rows[i]["Name"].ToString();
                stud.Contact = dt.Rows[i]["Contact"].ToString();
                stud.Email = dt.Rows[i]["Email"].ToString();
                stud.EnrollDate = dt.Rows[i]["EnrollDate"].ToString();

                list.Add(stud);
            }
            return list;
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public String CourseName { get; set; }

        List<Course> list = new List<Course>();
        public List<Course> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Course cour = new Course();
                cour.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                if (dt.Columns.Contains("CourseName"))
                {
                    cour.CourseName = dt.Rows[i]["CourseName"].ToString();
                }
                list.Add(cour);
            }
            return list;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class Attendence
    {
        [Key]
        public int Id { get; set; }

        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teachers { get; set; }

        [NotMapped]
        public string TeacherName { get; set; }

        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Courses { get; set; }

        [NotMapped]
        public string CourseName { get; set; }

        public int? ModuleTypeId { get; set; }
        [ForeignKey("ModuleTypeId")]
        public virtual ModuleType ModuleTypes { get; set; }

        [NotMapped]
        public string ModuleTypeName { get; set; }

        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Students { get; set; }

        [NotMapped]
        public string Name { get; set; }

        public int? TimeTableId {get; set;}
        [ForeignKey("TimeTableId")]
        public virtual TimeTable TimeTables {get; set;}

        [NotMapped]
        public string Day { get; set; }


        public string Date { get; set; }

        [Required]
        public string Status { get; set; }

        List<Attendence> list = new List<Attendence>();
        public List<Attendence> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Attendence att = new Attendence();
                att.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                if (dt.Columns.Contains("TeacherName"))
                {
                    att.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                }
                if (dt.Columns.Contains("CourseName"))
                {
                    att.CourseName = dt.Rows[i]["CourseName"].ToString();
                }
                if (dt.Columns.Contains("ModuleTypeName"))
                {
                    att.ModuleTypeName = dt.Rows[i]["ModuleTypeName"].ToString();
                }
                if (dt.Columns.Contains("Name"))
                {
                    att.Name = dt.Rows[i]["Name"].ToString();

                }
                if (dt.Columns.Contains("Day"))
                {
                    att.Day = dt.Rows[i]["Day"].ToString();
                }
                att.StudentId = Convert.ToInt32(dt.Rows[i]["StudentId"]);
                att.Date = dt.Rows[i]["Date"].ToString();
                att.Status = dt.Rows[i]["Status"].ToString();

                list.Add(att);
            }
            return list;
        }
        
        
    }
}
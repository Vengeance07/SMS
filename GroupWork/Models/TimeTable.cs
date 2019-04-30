using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroupWork.Models
{
    public class TimeTable
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course courses { get; set; }

        [NotMapped]
        public String CourseName { get; set; }

        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teachers { get; set; }

        [NotMapped]
        public String TeacherName { get; set; }

        public int? ModuleId { get; set; }
        [ForeignKey("ModuleId")]
        public virtual Module Modules { get; set; }

        [NotMapped]
        public String ModuleName { get; set; }

        [Required]
        public String StartTime { get; set; }

        [Required]
        public String EndTime { get; set; }

        [Required]
        public String Day { get; set; }

        List<TimeTable> list = new List<TimeTable>();
        public List<TimeTable> List(System.Data.DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TimeTable tt = new TimeTable();
                tt.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                if (dt.Columns.Contains("CourseName"))
                {
                    tt.CourseName = dt.Rows[i]["CourseName"].ToString();
                }
                if (dt.Columns.Contains("TeacherName"))
                {
                    tt.TeacherName = dt.Rows[i]["TeacherName"].ToString();
                }
                if (dt.Columns.Contains("ModuleName"))
                {
                    tt.ModuleName = dt.Rows[i]["ModuleName"].ToString();
                }
                tt.StartTime = dt.Rows[i]["StartTime"].ToString();
                tt.EndTime = dt.Rows[i]["EndTime"].ToString();
                tt.Day = dt.Rows[i]["Day"].ToString();

                list.Add(tt);

            }
            return list;
        }
    }
}